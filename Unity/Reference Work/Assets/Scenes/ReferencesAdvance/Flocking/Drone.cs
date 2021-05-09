using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{

    //Keep track of mother object
    public DroneMother motherShip;

    //This drone's speed
    float speed;

    //Keep track if drone should look at mother drone again
    bool leftDroneArea = false;

    Bounds DroneRange;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(motherShip.minDroneSpeed, motherShip.maxDroneSpeed); 
    }

    // Update is called once per frame
    void Update()
    {
        NormalFly();



    }

    private void NormalFly()
    {
        //Keep track of area of mother ship
        DroneRange = new Bounds(motherShip.transform.position, motherShip.droneFlyArea * 2);

        Vector3 direction = Vector3.zero;

        //check drone hasn't left limits
        if (!DroneRange.Contains(transform.position))
        {
            leftDroneArea = true;
            direction = motherShip.transform.position - transform.position;
        }
        else
        {
            leftDroneArea = false;
        }

        if (leftDroneArea)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), motherShip.rotationSpeed * Time.deltaTime);

        }
        else
        {
            if (Random.Range(0, 100) < 10)
            {
                speed = Random.Range(motherShip.minDroneSpeed, motherShip.maxDroneSpeed);
            }

            if (Random.Range(0, 100) < 20)
            {

            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    void FlyRules()
    {
        List<GameObject> group;
        group = motherShip._Drones;

        Vector3 vCentre = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        float gSpeed = 0.0f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject drone in group)
        {
            if (drone != this.gameObject)
            {
                nDistance = Vector3.Distance(drone.transform.position, this.transform.position);
                if (nDistance <= motherShip.neighbourDistance)
                {
                    vCentre += drone.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vAvoid = vAvoid + (this.transform.position - drone.transform.position);
                    }

                    Drone anotherDrone = drone.GetComponent<Drone>();
                    gSpeed = gSpeed + anotherDrone.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            //set goal as mother ship
            vCentre = vCentre / groupSize + (motherShip.transform.position - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vCentre + vAvoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), motherShip.rotationSpeed * Time.deltaTime);
            }
        }
    
    }    
        
        
        
        
        
    public void DestroyThisDrone()
    {

        Destroy(this.gameObject, Random.Range(0f, 1f));
    }








}
