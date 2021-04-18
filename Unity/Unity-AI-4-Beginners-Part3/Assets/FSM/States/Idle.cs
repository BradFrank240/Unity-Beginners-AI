using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IDLE : State
{
    //Constructor for idle state
    public IDLE(GameObject _npc, NavMeshAgent _agent, Transform _player)
        : base(_npc, _agent, _player)
    {

        stateName = STATE.IDEL;
    }

    public override void Enter()
    {

        npc.GetComponent<MeshRenderer>().material.color = Color.green;

        base.Enter();
    }

    public override void Update()
    {

        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }

        float random = Random.Range(0, 100);
        
        if (random < 10)
        {
            nextState = new Patrol(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }


        
         
    }

    public override void Exit()
    {
        base.Exit();
    }




}
