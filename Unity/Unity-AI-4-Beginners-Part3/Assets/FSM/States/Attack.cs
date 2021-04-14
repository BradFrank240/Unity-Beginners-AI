using UnityEngine;
using UnityEngine.AI;


public class Attack : State
{

    float rotationSpeed = 5.0f;
    AudioSource shoot;

    public Attack(GameObject _npc, NavMeshAgent _agent, Transform _player)
        : base(_npc, _agent, _player)
    {

        //shoot noise
        shoot = npc.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        //Start shoot look
        npc.GetComponent<MeshRenderer>().material.color = Color.black;
        agent.isStopped = true;
        shoot.Play();


        base.Enter();
    }

    public override void Update()
    {
        //rotate npc to look in direction of player
        Vector3 direction = playerPosistion.position - npc.transform.position;

        float angle = Vector3.Angle(direction, npc.transform.forward);

        direction.y = 0;

        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        
        if (!CanAttackPlayer())
        {
            
            if (!CanSeePlayer())
            {
                //
                nextState = new IDLE(npc, agent, playerPosistion);
                stage = EVENT.EXIT;
            }
            else
            {
                nextState = new Pursue(npc, agent, playerPosistion);
                stage = EVENT.EXIT;
            }
        }


    }

    public override void Exit()
    {

        shoot.Stop();
        base.Exit();
    }

}
