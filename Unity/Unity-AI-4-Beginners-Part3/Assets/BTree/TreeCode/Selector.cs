using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In the tree it selects what to do next 
public class Selector : BNode
{
    //Start at first child and run, if failed just go to the next one


    public Selector(string name)
    {
        this.name = name;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();

        //If running, continue running
        if (childStatus == Status.RUNNING) return Status.RUNNING;

        //Check if the child succeded
        if(childStatus == Status.SUCCESS)
        {
            currentChild = 0;
            return Status.SUCCESS;
        }

        //If the job was failed than go to next child
        currentChild++;
        //if went through all children
        if(currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.FAILURE;
        }

        return Status.RUNNING;
    }



}
