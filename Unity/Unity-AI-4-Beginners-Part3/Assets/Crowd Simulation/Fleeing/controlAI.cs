using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class controlAI : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent _agent;
    float detectionRadius = 20;
    float fleeRadius = 2f;


    void ResetAgent()
    {
        _agent.speed = Random.Range(5, 10);
        _agent.angularSpeed = 120;
        _agent.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _agent.ResetPath();
    }


    private void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("CheckPoint");
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        ResetAgent();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 1)
        {
            Debug.Log("reached goal");
            ResetAgent();
            _agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    public void DetectNewObstacle(Vector3 position)
    {
        


        if (Vector3.Distance(position, this.transform.position) < detectionRadius)
        {
            _agent.GetComponent<MeshRenderer>().material.color = Color.red;
            Vector3 fleeDirection = (this.transform.position - position).normalized;
            Vector3 newgoal = this.transform.position + fleeDirection * fleeRadius;
            Debug.Log(newgoal);

            NavMeshPath path = new NavMeshPath();
           
            _agent.CalculatePath(newgoal, path);
            Debug.Log(path.status);
            
            
            if (path.status != NavMeshPathStatus.PathInvalid)
            
            {
                _agent.GetComponent<MeshRenderer>().material.color = Color.cyan;
                _agent.SetDestination(path.corners[path.corners.Length - 1]);
                _agent.speed = 15;
                _agent.angularSpeed = 100;
            }
        }
    }
}
