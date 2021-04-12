using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Idle : State
{
    //Constructor for idle state
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {

        stateName = STATE.IDEL;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");

        base.Enter();
    }

    public override void Update()
    {
        if(Random.Range(0, 100) < 10)
        {
            nextState = new Patrol(npc, agent, anim, playerPosistion);
            stage = EVENT.EXIT;
        }
        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");

        base.Exit();
    }




}
