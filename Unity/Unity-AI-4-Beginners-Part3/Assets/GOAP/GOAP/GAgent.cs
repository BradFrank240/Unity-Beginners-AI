using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SubGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;


    /// <summary>
    /// Give a bot a goal to reach for with the option to remove it
    /// </summary>
    /// <param name="s"></param>
    /// <param name="i"></param>
    /// <param name="r"></param>
    public SubGoal(string s, int i , bool r)
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(s, i);
        remove = r;
    }

}


public class GAgent : MonoBehaviour
{

    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal, int> goal = new Dictionary<SubGoal, int>();

    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;
    SubGoal currentGoal;

    void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();        
        foreach(GAction a in acts)
        {
            actions.Add(a);
        }

    }
    
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }


}
