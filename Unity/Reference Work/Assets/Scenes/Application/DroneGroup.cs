using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGroup : MonoBehaviour
{

    public GameObject motherDrone;
    public GameObject dronePrefab;
    public int maxDrones = 10;
    public int numDrones = 0;
    public GameObject[] allDrones;
    public Vector3 flightZone = new Vector3(5, 5, 5);
    public Vector3 groupGoal;
    public Vector3 spawnLocation;

    public float minSpeed;
    public float maxSpeed;
    public float neighbourDistance;
    public float rotationSpeed;

    public int droneSpawnChance = 10;


    private void Start()
    {
        
        allDrones = new GameObject[maxDrones];

        SpawnLeaderDrone();




    }

    private void Update()
    {
        
        if(numDrones < maxDrones - 1)
        {
            if (Random.Range(0, 100) < droneSpawnChance)
            {
                SpawnDrone();
            }
        }





    }



    /// <summary>
    /// Spawns a drone leader
    /// </summary>
    /// <returns></returns>
    private void SpawnLeaderDrone()
    {
        numDrones += 1;
        
        allDrones[0] = Instantiate(motherDrone, spawnLocation, Quaternion.identity, this.transform);
        allDrones[0].GetComponent
        

    }


    /// <summary>
    /// Spawns a normal drone
    /// </summary>
    /// <returns></returns>
    private void SpawnDrone()
    {
        //Add a new drone
        numDrones += 1;
        
        allDrones[numDrones]  = (GameObject)Instantiate(dronePrefab, spawnLocation, Quaternion.identity, this.transform);

        allDrones[numDrones].GetComponent<Drone>().myGroup = this;
    }



}
