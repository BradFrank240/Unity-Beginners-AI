using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{



    public GameObject fuel;

    
    void Update()
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
        Vector3 tankForward = this.transform.up;
        //See where the tank is faceing 
        Debug.DrawRay(transform.position , tankForward * 10 , Color.blue, 2);

        //fuel direction
        Vector3 fuelDirection = fuel.transform.position - this.transform.position;
        //See direction of fuel
        Debug.DrawRay(transform.position, fuelDirection, Color.green, 2);

        //dot product divided by distance and inverse of cos = angle you should be looking 

        float dot = tankForward.x * fuelDirection.x + tankForward.y * fuelDirection.y;

        float b = Mathf.Acos(dot / (tankForward.magnitude * fuelDirection.magnitude));
        //My calculation
        print("Angle " + b * Mathf.Rad2Deg);

        //unity calculations 
        print("Unity angle " + Vector3.Angle(tankForward, fuelDirection));

        
    }



}
