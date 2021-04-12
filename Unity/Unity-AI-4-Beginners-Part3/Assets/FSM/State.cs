using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//State machien base class
public class State 
{
    //An enum holding all the states, can have states added on later
    public enum STATE
    {
        IDEL, PATROL, PURSUE, ATTACK, SLEEP
    };

    //What state the player is currently in
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE stateName;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform playerPosistion;
    //holds what state to go from here 
    protected State nextState;
    protected NavMeshAgent agent;

    float visDistance = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    //contructor class of states
    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        playerPosistion = _player;
        stage = EVENT.ENTER;
    }

    //This method runs first and then go to the next event in the state
    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    
    public virtual void Exit()
    {
        stage = EVENT.EXIT; 
    }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

}
