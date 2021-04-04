using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //Transform goal;
    //float speed = 10.0f;
    //float accuracy = 1.0f;
    //float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    //GameObject currentNode;
    //int currentWP = 0;
    //Graph g;

    UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        //g = wpManager.GetComponent<WPManager>().graph;
        //currentNode = wps[7];

        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void GoToStart()
    {
        agent.SetDestination(wps[0].transform.position);
        //g.AStar(currentNode, wps[0]);
        //currentWP = 0;
    }

    public void GoToEnd()
    {
        agent.SetDestination(wps[wps.Length - 1].transform.position);
        //g.AStar(currentNode, wps[wps.Length -1]);
        //currentWP = 0;
    }

    private void LateUpdate()
    {
        /*
        if(g.getPathLength() == 0 || currentWP == g.getPathLength())
        {
            return;
        }

        //the node we are closest to at the moment
        currentNode = g.getPathPoint(currentWP);

        //if we are close enough to the current waypoint move to the next
        if(Vector3.Distance(g.getPathPoint(currentWP).transform.position, this.transform.position) < accuracy)
        {
            currentWP++;
        }

        //if we are not at the end of the path
        if(currentWP < g.getPathLength())
        {
            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        */

    }



}
