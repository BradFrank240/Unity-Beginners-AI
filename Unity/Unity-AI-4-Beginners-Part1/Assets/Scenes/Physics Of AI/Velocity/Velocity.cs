using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{

    public float speed = 1f;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.right * 10f, Color.blue, 5f);
        }
        */

        //move forward by one meter per second
        this.transform.Translate(Time.deltaTime * speed, Time.deltaTime, 0);
        
    }
}
