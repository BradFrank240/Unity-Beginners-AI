using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BNode 
{
    
    //Any node can have three status's
    //Successful when ran
    //Failed when rain
    //Still runninng

    public enum Status
    {
        SUCCESS, RUNNING, FAILURE
    };

    public Status status;

    //A node can have a child 
    public List<BNode> children = new List<BNode>();

    //Track what child is being excuted
    public int currentChild = 0;

    //Give each node a name for debuging
    public string name;

    //empty constructor
    public BNode()
    {

    }

    public BNode(string name)
    {
        this.name = name;
    }

    public virtual Status Process()
    {

        return children[currentChild].Process();
    }

    public void AddChild(BNode newNode)
    {
        children.Add(newNode);
    }






}
