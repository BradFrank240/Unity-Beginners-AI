using UnityEngine;
using UnityEngine.AI;

//State machien base class
public class State 
{
    //An enum holding all the states, can have states added on later
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP
    };

    //What state the player is currently in
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };
    
    //store name of current state
    public STATE stateName;
    //store the tage the event is in now
    protected EVENT stage;
    //store the npc's object
    protected GameObject npc;
    //pplaers position
    protected Transform playerPosistion;
    //holds what state to go from here 
    protected State nextState;
    protected NavMeshAgent agent;

    float visDistance = 20.0f;
    float visAngle = 50.0f;
    float shootDist = 7.0f;

    //contructor class of states
    public State(GameObject _npc, NavMeshAgent _agent, Transform _player)
    {
        npc = _npc;
        playerPosistion = _player;
        agent = _agent;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; } // Runs first whenever you come into a state and sets the stage to whatever is next, so it will know later on in the process where it's going.
    public virtual void Update() { stage = EVENT.UPDATE; } // Once you are in UPDATE, you want to stay in UPDATE until it throws you out.
    public virtual void Exit() { stage = EVENT.EXIT; } // Uses EXIT so it knows what to run and clean up after itself.

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

    //Helper methods


    //Method for AI to check if player in view cone
    public bool CanSeePlayer()
    {
        Vector3 playerDirection = playerPosistion.position - npc.transform.position;
        
        //Direction of pllayer 
        float angle = Vector3.Angle(playerDirection, npc.transform.forward);

        //Check if in vissible distance, 
        if(playerDirection.magnitude < visDistance && angle < visAngle)
        {
            return true;
        }
        return false;
    }

    //check if AI is in range
    public bool CanAttackPlayer()
    {
        Vector3 direction = playerPosistion.position - npc.transform.position;
    
        if(direction.magnitude < shootDist)
        {
            return true;
        }
        return false;
    }

}
