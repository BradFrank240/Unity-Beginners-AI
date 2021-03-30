using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{

    public GameObject fuel;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateAngle();
        }
    }

    void CalculateAngle()
    {
        //Find the angle between two objects using dot product

        //tank forward direction
        Vector3 tankForward = transform.up;
        //See where the tank is faceing 
        //Debug.DrawRay(transform.position , tF * 10 , Color.blue, 2);

        //fuel direction
        Vector3 fuelDirection = fuel.transform.position - transform.position;
        //See direction of fuel
        //Debug.DrawRay(transform.position, fD, Color.green, 2);

        //dot product divided by distance and inverse of cos = angle you should be looking 

        float dot = tankForward.x * fuelDirection.x + tankForward.y * fuelDirection.y;

        float angle = Mathf.Acos(dot / (tankForward.magnitude * fuelDirection.magnitude));
        //My calculation
        print("Angle " + angle * Mathf.Rad2Deg);

        //unity calculations 
        print("Unity angle " + Vector3.Angle(tankForward, fuelDirection));

        /* The clockwise system can be replaced by the unity method Vector3.SignedAngle();
        int clockwise = 1;
        if(Cross(tankForward, fuelDirection).z < 0)
        {
            clockwise = -1;
        }
        */
        

        float unityAngle = Vector3.SignedAngle(tankForward, fuelDirection, transform.forward);


        this.transform.Rotate(0, 0, angle * Mathf.Rad2Deg * unityAngle);


    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        //essentaily what happens is every cordinate is multplied by the rest of cordinates. 
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.z * w.x - v.x * w.z;
        float zMult = v.x * w.y - v.y * w.x;

        //Vector3 crossProduct 
        return new Vector3(xMult, yMult, zMult);
    }


}
