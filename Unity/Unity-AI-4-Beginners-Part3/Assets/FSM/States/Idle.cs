using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Idle : State
{
    //Constructor for idle state
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform _player)
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

        float random = Random.Range(0, 100);
        Debug.Log("Random chance : "+ random);
        if (random < 10)
        {
            
            nextState = new Patrol(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }
        
        base.Update();
    }

    public override void Exit()
    {
        
        base.Exit();
    }




}
