using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GoBreak : GAction
{
    public override bool PostPerform()
    {
        

        return true;
    }


    public override bool PrePerform()
    {

        beliefs.RemoveState("exhausted");

        return true;
    }
}
