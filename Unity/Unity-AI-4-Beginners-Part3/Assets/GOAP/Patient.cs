using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : GAgent
{
    
    public new void Start()
    {
        
        base.Start();
        SubGoal s1 = new SubGoal("isWaiting", 1, true);
        goals.Add(s1, 3);
        
        SubGoal s2 = new SubGoal("isTreated", 1, true);
        //the goal is s2 and the value or importance is a 5
        goals.Add(s2, 5);

        SubGoal s3 = new SubGoal("goHome", 1, true);
        goals.Add(s3, 6);


    }

    
}
