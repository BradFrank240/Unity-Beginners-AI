using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RobberBehaviour : MonoBehaviour
{
    public GameObject van;
    public GameObject diamond;

    BehaviourTree tree;

    private NavMeshAgent _agent;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    private void Start()
    {
        tree = new BehaviourTree();
        _agent = this.GetComponent<NavMeshAgent>();
        
        BNode steal = new BNode("Steal Something");
        Leaf goToDiamond = new Leaf("Go to Diamond", GoToDiamond);
        Leaf goToVan = new Leaf("Go to Van", GoToVan);

        //Creates the tree in reverse, from bottom to top
        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);
        tree.AddChild(steal);

        
       
        tree.PrintTree();

        tree.Process();
    
    }

    public BNode.Status GoToDiamond()
    {
        return GoToLocation(diamond.transform.position);  
    }

    public BNode.Status GoToVan()
    {
        return GoToLocation(van.transform.position);
    }

    BNode.Status GoToLocation(Vector3 destination)
    {
        float distance = Vector3.Distance(destination, this.transform.position);

        if(state == ActionState.IDLE)
        {
            _agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(_agent.pathEndPosition, destination) >= 2f)
        {
            //bot hasn't reached goal
            state = ActionState.IDLE;
            return BNode.Status.FAILURE;
        }
        else if(distance < 2)
        {
            state = ActionState.IDLE;
            return BNode.Status.SUCCESS;
        }
        return BNode.Status.RUNNING;

    }
    

}
