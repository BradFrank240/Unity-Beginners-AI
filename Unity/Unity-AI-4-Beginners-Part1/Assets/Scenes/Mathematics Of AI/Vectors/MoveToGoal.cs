using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    //Character speed
    public float speed = 1f;

    //how far the bot can get to the goal
    public float accuracy = 0.9f;

    //Where the characters going
    public Transform goal;



    private void Start()
    {
        //sets rotation to have forward to look at 
        
    }


    private void LateUpdate()
    {
        //Find direction of where your going in vector form
        //direction = end point - current point.
        Vector3 direction = goal.position - this.transform.position;
        this.transform.LookAt(goal.position);
        Debug.DrawRay(this.transform.position, direction, Color.red);
        
        
        //if too far. 
        if(direction.magnitude > accuracy)
        {
            //translates player towards direction.  using the worlds space rotation
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }


        
    }


}
