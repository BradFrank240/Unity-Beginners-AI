using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealDrive : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public GameObject fuel;

    private void Update()
    {

        BasicDrive();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance();
        }

    }

    private void CalculateDistance()
    {

        //store the two positions
        Vector3 tankPosition = this.transform.position;
        Vector3 fuelPosition = fuel.transform.position;

        float distance = Mathf.Sqrt(Mathf.Pow(tankPosition.x - fuelPosition.x, 2) + Mathf.Pow(tankPosition.y - fuelPosition.y, 2) + Mathf.Pow(tankPosition.z - fuelPosition.z, 2));

        //These do the smae thing, but top one is the equation performed. 
        float unityDistance = Vector3.Distance(tankPosition, fuelPosition);

        Debug.Log("Distance " + distance);
        Debug.Log("Unity distance " + unityDistance);

    }

    private void BasicDrive()
    {
        //Get the horizontal and vertical axis.
        //They are mapped to arrow keys and wasd
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        //make speeds per second instead of per frame.
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //Move translation along the z axis.
        transform.Translate(0, translation, 0);

        //Roate around y axis
        transform.Rotate(0, 0, -rotation);

    }





}
