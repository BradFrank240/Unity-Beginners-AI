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
            //LooknSeek(_Waypoint.transform.position);    
            MoveTorwardsGoal(_Waypoint.transform.position);
        }
        else
        {
            //check if next goal exceeds limit
            _CurrentWaypoint++;
            if (_CurrentWaypoint > waypoints.Count - 1)
            {
                _CurrentWaypoint = 0;
            }
            
            _Waypoint = waypoints[_CurrentWaypoint];
        }

        
    }

    
    /// <summary>
    /// Look at goal and move torwards it
    /// </summary>
    /// <param name="goal"></param>
    private void LooknSeek(Vector3 goal)
    {
        //finds rotation goal
        Quaternion rotationGoal = Quaternion.LookRotation(goal - this.transform.position);
        //rotates towards
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotationGoal, rotationSpeed * Time.deltaTime);

        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


    }

    /// <summary>
    /// Just move torwards goal, don't look at it
    /// </summary>
    /// <param name="goal"></param>
    private void MoveTorwardsGoal(Vector3 goal)
    {
        
        transform.Translate((goal - this.transform.position).normalized * moveSpeed * Time.deltaTime);
    }







}
