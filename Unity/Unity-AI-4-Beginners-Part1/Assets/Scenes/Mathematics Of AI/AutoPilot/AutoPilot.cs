using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPilot : MonoBehaviour
{

    //Goal, where it's going
    public GameObject goal;

    //Speed, how fast object can move
    public float speed = 10.0f;

    // Tank rotation speed
    public float rotationSpeed = 100.0f;

    //Accuracy, how close it needs to get
    public float accuracy = 0.9f;

    //turn off and on autopilton
    public bool autoPilot = false;


    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);

        // Check for the spacebar being pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // If pressed then cal CalculateDistance method
            CalculateDistance();
            // Call CalculateAngle method
            CalculateAngle();
        }

        // Check if the T key has been pressed
        if (Input.GetKeyDown(KeyCode.T))
        {

            // Flip the value of autoPilot
            autoPilot = !autoPilot;
        }

        // Check if autoPilot is enabled
        if (autoPilot)
        {

            // If yes and distance is greater than 5 then execute AutoPilot method
            if (CalculateDistance() > 5.0f)
            {

                AutoPilotObject();
            }
        }
    }

    private void LateUpdate()
    {


        
        
    }

    float CalculateDistance()
    {

        // Tank position
        Vector3 tP = this.transform.position;
        // Fuel position
        Vector3 fP = goal.transform.position;

        // Calculate the distance using pythagoras
        float distance = Mathf.Sqrt(Mathf.Pow(tP.x - fP.x, 2.0f) +
                         Mathf.Pow(tP.y - fP.y, 2.0f) +
                         Mathf.Pow(tP.z - fP.z, 2.0f));

        // Calculate the distance using Unitys vector distance function
        float unityDistance = Vector3.Distance(tP, fP);

        // Print out the two results to the console
        Debug.Log("Distance: " + distance);
        Debug.Log("Unity Distance: " + unityDistance);

        // Return the calculated distance
        return distance;
    }

    void CalculateAngle()
    {
        // Objects forward facing direction
        Vector3 objectForward = this.transform.up;
        // Vector to the goal
        Vector3 goalDirection = goal.transform.position - this.transform.position;

        // Calculate the dot product
        float dot = objectForward.x * goalDirection.x + objectForward.y * goalDirection.y;
        float angle = Mathf.Acos(dot / (objectForward.magnitude * goalDirection.magnitude));

        // Output the angle to the console
        Debug.Log("Angle: " + angle * Mathf.Rad2Deg);

        // Draw a ray showing the objects forward facing vector
        Debug.DrawRay(this.transform.position, objectForward * 10.0f, Color.green, 2.0f);
        // Draw a ray showing the vector to the fuel
        Debug.DrawRay(this.transform.position, goalDirection, Color.red, 2.0f);

        int clockwise = 1;
        if (Cross(objectForward, goalDirection).z < 0.0f)
            clockwise = -1;

        // Have object face the goal
        this.transform.Rotate(0.0f, 0.0f, (angle * clockwise * Mathf.Rad2Deg) * 0.02f) ;

    }

    

    /// <summary>
    /// Calculate the Cross Product
    /// </summary>
    /// <param name="v"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.z * w.x - v.x * w.z;
        float zMult = v.x * w.y - v.y * w.x;

        Vector3 crossProd = new Vector3(xMult, yMult, zMult);
        return crossProd;
    }

    float autoSpeed = 0.1f;

    void AutoPilotObject()
    {
        //face the goal
        CalculateAngle();
        // move the object forward
        this.transform.Translate(this.transform.up * autoSpeed, Space.World);
    }



}
