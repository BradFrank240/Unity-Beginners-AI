using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{

    int currentIndex = -1;

     

    public Patrol(GameObject _npc, NavMeshAgent _agent,  Transform _player)
        : base(_npc, _agent,  _player)
    {
        stateName = STATE.PATROL;
        agent.speed = 5;
        agent.isStopped = false;

    }

    public override void Enter()
    {
        currentIndex = 0;
        npc.GetComponent<MeshRenderer>().material.color = Color.red;
        //Get the list of waypoints
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnviroment.Singleton.Checkpoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            agent.SetDestination(GameEnviroment.Singleton.Checkpoints[currentIndex].transform.position);
        }

        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
       

        base.Exit();
    }

}

