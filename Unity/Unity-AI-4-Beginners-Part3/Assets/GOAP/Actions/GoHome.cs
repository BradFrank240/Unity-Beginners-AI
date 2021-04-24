using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : GAction
{
    public override bool PrePerform()
    {
        //set in inspector 
        //target = inventory.FindItemWithTag("Home");
       // if (target == null)
       // {
       //     Debug.Log("No home");
       //     return false;
       // }


        return true;
    }




    public override bool PostPerform()
    {
        //Once reached, simply destory self

        Destroy(this.gameObject, 5f);
        return true;
    }

}
