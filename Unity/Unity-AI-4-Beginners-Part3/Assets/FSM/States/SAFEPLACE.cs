using UnityEngine;
using UnityEngine.AI;

public class SAFEPLACE : State
{
    public SAFEPLACE(GameObject _npc, NavMeshAgent _agent, Transform _player)
        : base(_npc, _agent, _player)
    {
        stateName = STATE.SLEEP;
        agent.speed = 10;
        agent.isStopped = false;
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 0.5)
        {
            //enter new state 
            nextState = new IDLE(npc, agent, playerPosistion);
            stage = EVENT.EXIT;
        }
        else
        {
            agent.SetDestination(GameEnviroment.Singleton.SafePoint.transform.position);
        }
        
        
    }

    public override void Exit()
    {


        base.Exit();
    }


}
