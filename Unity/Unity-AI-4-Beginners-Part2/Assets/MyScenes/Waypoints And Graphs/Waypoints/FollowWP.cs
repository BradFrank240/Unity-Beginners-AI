using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{

    //Stores the series of waypoints
    public GameObject[] waypoints;
    //Keeps track of the current waypoint being followed
    int currentWP = 0;
    //Requirement for getting near the object
    public int accuracy = 3;

    //Stores movement speed of tank
    public float speed = 10f;

    //roation speed
    public float lookSpeed = 10f;

    GameObject tracker;
    //trackers speed
    public float trackerSpeed = 11f;

    //how far can the tracker get from the tank
    public float lookAhead = 10f;
    private void Start()
    {
        //create visual to see tracker
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //destroy the collider
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        //Check distance between tracker and tank
        if(Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead)
        {
            //cut tracker early 
            return;
        }
        //check if close enough to the target to get next target
        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < accuracy)
        {

            //Set to next target
            currentWP++;

            //Making sure that current waypoint doesnt go above the amount of waypoints in list and resets to zero.
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        //Finds the look direction in a quaternion
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - tracker.transform.position);
        //rotation is a quatertion,
        tracker.transform.rotation = Quaternion.Slerp(tracker.transform.rotation, lookatWP, 20 * Time.deltaTime);

        //moves user towards current waypoint
        tracker.transform.Translate(0, 0, trackerSpeed * Time.deltaTime);
    }

    private void Update()
    {
        ProgressTracker();

        

        //Instead smoothy look at waypoint using quaternion
        //Finds the look direction in a quaternion
        Quaternion lookatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        //rotation is a quatertion,
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, lookSpeed * Time.deltaTime);

        //moves user towards current waypoint
        this.transform.Translate(0, 0, speed * Time.deltaTime);


    }




}
