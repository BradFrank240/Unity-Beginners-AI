using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Singletone for manageing the waypoints on a map that can be accessed by all scripts
public class WaypointManager 
{

    //Hold the singoleton
    private static WaypointManager _instance;

    //keep a list of waypoints
    private List<GameObject> _waypoints = new List<GameObject>();

    //a list of waypoint with public access
    public List<GameObject> waypoints { get { return _waypoints;  } }




    
    //Create and and set properties of singleton
    public static WaypointManager waypointManager
    {
        get
        {
            //check singleton exist
            if(_instance == null)
            {
                //create new manager
                _instance = new WaypointManager();
                //set properties
                _instance._waypoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));


            }

            //return self
            return _instance;
        }

    }
   





} 