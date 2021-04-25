using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : BNode
{
    
    public BehaviourTree()
    {
        name = "Tree";
    }

    public BehaviourTree(string treeName)
    {
        this.name = treeName;
    }

    public override Status Process()
    {
        return children[currentChild].Process();
    }



    struct BNodeLevel
    {
        //Keep track of what level a nodes sits on
        public int level;
        public BNode node;
    }



    /// <summary>
    /// Write in console what the children of the tree are.
    /// </summary>
    public void PrintTree()
    {
        
        //Stores Tree String
        string TreePrint = "";


        //In and out way of going through nodes
        Stack<BNodeLevel> bStack = new Stack<BNodeLevel>();

        //Track the current node
        BNode currentNode = this;

        bStack.Push(new BNodeLevel { level = 0, node = currentNode });

        while (bStack.Count != 0) 
        {
            
           BNodeLevel nextNode = bStack.Pop();

            TreePrint += new string('-', nextNode.level) + nextNode.node.name + "\n";

           
           for(int i = nextNode.node.children.Count - 1; i >= 0; i--)
           {
               bStack.Push(new BNodeLevel { level = nextNode.level+1, node =nextNode.node.children[i] });
           }
        }

        Debug.Log(TreePrint);
       

        //Debug.Log(this.name);
        //Check for every nodes child as well
        // PrintNodes(this);
    }


    /// <summary>
    /// Recursive Method that goes through every node and prints the name.
    /// </summary>
    /// <param name="node"></param>
    private void PrintNodes(BNode node)
    {
        
        foreach(BNode childNode in node.children)
        {
            //Print the name of father 
            Debug.Log(childNode.name);

            //Print that childs children
            PrintNodes(childNode);
            
        }


    }




}
