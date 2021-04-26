using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RobberBehaviour : MonoBehaviour
{
    public GameObject van;
    public GameObject diamond;
    public GameObject frontDoor;
    public GameObject backDoor;

    BehaviourTree tree;

    private NavMeshAgent _agent;

    [Range(0, 1000)]
    public int money = 500;

    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;


    BNode.Status treeStatus = BNode.Status.RUNNING;

    private void Start()
    {
        tree = new BehaviourTree();
        _agent = this.GetComponent<NavMeshAgent>();
        
        Sequence steal = new Sequence("Steal Something");


        Leaf goToBackDoor = new Leaf("Go to Back Door", GoToBackDoor);
        Leaf goToVan = new Leaf("Go to Van", GoToVan);
        Leaf goToFrontDoor = new Leaf("Go to front door", GoToFrontDoor);
        Leaf goToDiamond = new Leaf("Go to Diamond", GoToDiamond);
        Leaf hasMoney = new Leaf("Does thy have cash", HasMoney);

        //Choise of front or back door
        Selector openDoor = new Selector("Open Door");
        openDoor.AddChild(goToBackDoor);
        openDoor.AddChild(goToFrontDoor);


        //Creates the tree in reverse, from bottom to top
        steal.AddChild(hasMoney);
        steal.AddChild(openDoor);
        steal.AddChild(goToDiamond);
        steal.AddChild(goToVan);

        tree.AddChild(steal);

        
       
        tree.PrintTree();

        
    
    }

    private void Update()
    {
        
        if(treeStatus != BNode.Status.SUCCESS)
        {
            //Updates tree status when running the tree.
            treeStatus = tree.Process();
        }
        
    }


    public BNode.Status HasMoney()
    {
        if(money <= 500)
        {
            return BNode.Status.SUCCESS;
        }
        return BNode.Status.FAILURE;  
    }



    #region Go To Methods

    public BNode.Status GoToDiamond()
    {
        BNode.Status status = GoToLocation(diamond.transform.position);
        if (status == BNode.Status.SUCCESS)
        {
            diamond.transform.parent = this.transform;
            
        }

        return status;
    }

    public BNode.Status GoToVan()
    {
        return GoToLocation(van.transform.position);
    }

    public BNode.Status GoToFrontDoor()
    {

        return GoToDoor(frontDoor);
    }

    public BNode.Status GoToBackDoor()
    {

        return GoToDoor(backDoor);
    }

    #endregion

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
    
    public BNode.Status GoToDoor(GameObject door)
    {
        BNode.Status status = GoToLocation(door.transform.position);
        if (status == BNode.Status.SUCCESS)
        {
            if (!door.GetComponent<Lock>().IsLocked)
            {
                door.SetActive(false);
                return BNode.Status.SUCCESS;
            }
            return BNode.Status.FAILURE;
        }
        return status;
    }
    
}
