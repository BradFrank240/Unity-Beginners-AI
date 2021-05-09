using System.Collections.Generic;
using UnityEngine;

public class DroneMother : MonoBehaviour
{

    //Store all the waypoints for the mother drone 
    private List<GameObject> _Waypoints = new List<GameObject>();
    //Cache current waypoint pos
    private Vector3 _CurrentWaypointPos = Vector3.zero;

    //What smaller drones are stroed in 
    public GameObject dronePrefab;
    //List of children drones
    public List<GameObject> _Drones = new List<GameObject>();

    [Header("Mother Drone")]
    [Range(1, 25)]
    public int numberOfChildren = 10;
    public float accuracy = 3f;
    public float speed = 10f;

    [Header("Child Drones")]
    [Range(5, 10)]
    public float minDroneSpeed = 10f;
    [Range(10, 25)]
    public float maxDroneSpeed = 25f;
    [Range(1.0f, 10f)]
    public float neighbourDistance = 5f;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed = 2.5f;

    public Vector3 droneFlyArea = new Vector3(10, 10, 10);

    private void Start()
    {
        _Waypoints = WaypointManager.waypointManager.waypoints;
       
    }

    private void Update()
    {
        ManageChildren(); 
    }


    private void FixedUpdate()
    {
        RoamWaypoints();
    }



    #region Drone Children


    /// <summary>
    /// Check if above or under the drone children threshold.
    /// </summary>
    private void ManageChildren()
    {

        if(_Drones.Count < numberOfChildren)
        {
            //Add children
            SpawnChildDrone();
        }
        else if (_Drones.Count > numberOfChildren)
        {
            //destroy child
            DestroyChildDrone();
        }
    }

    /// <summary>
    /// Spawn a child and set it's mother
    /// </summary>
    private void SpawnChildDrone()
    {
        Vector3 spawnPoint = this.transform.position + new Vector3(Random.Range(-droneFlyArea.x, droneFlyArea.x), Random.Range(-droneFlyArea.y, droneFlyArea.y), Random.Range(-droneFlyArea.z, droneFlyArea.z));
        _Drones.Add(Instantiate(dronePrefab, spawnPoint, Quaternion.identity, this.transform.parent));
        _Drones[_Drones.Count - 1].GetComponent<Drone>().motherShip = this;        
    }


    /// <summary>
    /// Destroy random child drone. 
    /// </summary>
    /// <param></param>
    private void DestroyChildDrone()
    {
        int chosenDroneNum = Random.Range(0, _Drones.Count - 1);
        Drone drone = _Drones[chosenDroneNum].GetComponent<Drone>();
        drone.DestroyThisDrone();
        _Drones.RemoveAt(chosenDroneNum);
    }



    #endregion




    #region Movement

    /// <summary>
    /// Choose a random waypoint and fly to it repeativly
    /// </summary>
    private void RoamWaypoints()
    {

        if (MoveToWaypoint(_CurrentWaypointPos))
        {
            //Get next waypoint
            _CurrentWaypointPos = _Waypoints[Random.Range(0, _Waypoints.Count - 1)].transform.position;
        }
    }

    /// <summary>
    /// Has drone fly torwards goal and if reached accuracy returns true.
    /// </summary>
    /// <param name="goal"></param>
    /// <returns></returns>
    private bool MoveToWaypoint(Vector3 goal)
    {
        //check distance from goal
        if(Vector3.Distance(this.transform.position, goal) > accuracy)
        {
            //Move torwards goal
            this.transform.Translate((goal - this.transform.position).normalized * speed * Time.deltaTime);
            //Not close enought to return true
            return false;
        }
        

        return true;
    }



    #endregion


}
