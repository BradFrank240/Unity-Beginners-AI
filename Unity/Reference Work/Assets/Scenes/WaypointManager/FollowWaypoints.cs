using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    
    //Store waypoints
    List<GameObject> waypoints = new List<GameObject>();

    private GameObject _Waypoint;

    private int _CurrentWaypoint = 0;

    public float accuracy = 2f;
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;


    private void Start()
    {
        waypoints.AddRange(WaypointManager.waypointManager.waypoints);
        //set first waypoint
        _Waypoint = waypoints[_CurrentWaypoint];
    }


    private void FixedUpdate()
    {

        //check if close enough to waypoint
        if (Vector3.Distance(this.transform.position, _Waypoint.transform.position) > 2f)
        {
            //find the roation value to look at goal
            Quaternion lookAtGoal = Quaternion.LookRotation(_Waypoint.transform.position - this.transform.position);
            
            //Look at goal
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtGoal, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        }
        else
        {
            //check if next goal exceeds limit
            _CurrentWaypoint++;
            if (_CurrentWaypoint > waypoints.Count)
            {
                _CurrentWaypoint = 0;
            }
            
            _Waypoint = waypoints[_CurrentWaypoint];
        }

        
    }




}
