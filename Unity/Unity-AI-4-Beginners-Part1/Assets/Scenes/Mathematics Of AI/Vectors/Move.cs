using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Goal for bot to reach. 
    //vector3 is the vector form of 3D
    Vector3 Goal = new Vector3(6, 0, -4);


    void Start()
    {
        Goal = Goal * 0.01f;
          
    }

   
    void Update()
    {
        this.transform.Translate(Goal);
    }
}
