using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    
    public Pursue(GameObject _npc, NavMeshAgent _agent, Transform _player) 
        : base(_npc, _agent, _player)
    {
        stateName = STATE.PURSUE;
        agent.speed = 8;
        agent.isStopped = false;
    }

    public override void Enter()
    {

        npc.GetComponent<MeshRenderer>().material.color = Color.yellow;

        base.Enter();
    }

    public override void Update()
    {

        agent.SetDestination(playerPosistion.position);
        
        //check if AI can attack
        if (CanAttackPlayer())
        {
            nextState = new Attack(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }
        else if (!CanSeePlayer())
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
