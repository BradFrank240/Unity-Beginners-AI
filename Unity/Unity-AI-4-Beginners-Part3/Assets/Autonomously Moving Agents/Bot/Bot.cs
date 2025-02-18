﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Bot : MonoBehaviour
{

    NavMeshAgent agent;

    public GameObject target;

    

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }



    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    
    
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

    void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));
        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));


        if((toTarget > 90 && relativeHeading < 20) || target.GetComponent<PlayerMove>().currentSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }

        float futurePosition = targetDir.magnitude / agent.speed + target.GetComponent<PlayerMove>().currentSpeed;

        Seek(target.transform.position + target.transform.forward * futurePosition);
    }

    private void Update()
    {
        Pursue();
    }




}
