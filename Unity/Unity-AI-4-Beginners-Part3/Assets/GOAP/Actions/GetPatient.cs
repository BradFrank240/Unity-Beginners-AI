using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : GAction
{
    //get the cubicle that patients is going to 
    GameObject resource;
    

    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();

        if(target == null)
        {
            Debug.Log("no target");
            return false;
        }
        else
        {
            //Debug.Log(target);
        }

        resource = GWorld.Instance.RemoveCubicle();

        if(resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            Debug.Log("No free cubicle");

            GWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }

        
        //Take away a cubicle
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);


        return true;    
    }

    public override bool PostPerform()
    {
        //Take away a patient
        GWorld.Instance.GetWorld().ModifyState("isWaiting", -1);

        if(target)
        {
            //adding cubicile to the patients inventory so they can both get to it, could just have 
            //paitent follow nurse, but you would also need to add the nurse to inventory. This is just better
            target.GetComponent<GAgent>().inventory.AddItem(resource);
            
        }

        return true; 
    }

}
