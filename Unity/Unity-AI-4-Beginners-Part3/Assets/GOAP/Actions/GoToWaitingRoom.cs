﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : GAction
{

    public override bool PrePerform()
    {
        return true;    
    }




    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("isWaiting", 1);
        GWorld.Instance.AddPatient(this.gameObject);

        
        this.beliefs.ModifyState("atHospital", 1);


        return true; 
    }

}
