using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AIController : MonoBehaviour
{

    public GameObject goal;
    NavMeshAgent _agent;

    private void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _agent.SetDestination(goal.transform.position);
    }



}


