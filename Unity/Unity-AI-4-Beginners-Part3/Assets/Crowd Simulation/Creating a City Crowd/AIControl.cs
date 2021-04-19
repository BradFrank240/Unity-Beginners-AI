using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{

    GameObject[] goalLocations;

    NavMeshAgent agent;

    private void Start()
    {
        
        goalLocations = GameObject.FindGameObjectsWithTag("CheckPoint");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        agent.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        agent.speed = Random.Range(5, 15);

    }


    private void Update()
    {
        if(agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
