using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//A node that excutes multiple nodes in a row
public class Sequence : BNode
{
   
    public Sequence(string name)
    {
        this.name = name;
    }

    public override Status Process()
    {
        
        //Need to loop through this sequence once and not do it multiple times

        //finds first child in array
        Status childStatus = children[currentChild].Process();

        //Checking if the child is already running
        if (childStatus == Status.RUNNING) return Status.RUNNING;

        //Check if you need to leave sequence due to failure
        if (childStatus == Status.FAILURE)
        {
            Debug.Log("Failure of sequence " + this.name + ". child " + children[currentChild].name);
            return childStatus;
        }

        //go to the next child as it has done it's job
        currentChild++;
        
        //If gone through all children, than return a success.
        if(currentChild  >= children.Count)
        {
            
            currentChild = 0;
            return Status.SUCCESS;
        }

        return Status.RUNNING;
    }



}
