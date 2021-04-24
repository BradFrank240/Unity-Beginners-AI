using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : GAction
{

    public override bool PrePerform()
    {
        target = this.inventory.FindItemWithTag("Surgery");
        if (target == null)
        {
            return false;
        }

        return true;    
    }

    public override bool PostPerform()
    {
        //just to track the amount of patients that have been treated
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);

        inventory.RemoveItem(target);

        GWorld.Instance.GetWorld().ModifyState("TreatingPatient", -1);
        this.beliefs.ModifyState("doneAtHospital", 1);
        

        return true;
    }

}
