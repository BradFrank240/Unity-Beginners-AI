using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //object to create on death
    public GameObject explosion;

    //The mass of the object in kilograms
    float mass = 10;

    //How much force will be applied
    float force = 1000;

    //The change in velocity
    float acceleration;
    //gravitys acceleration
    float gAccel;
    //Gravit 
    float gravity = -9.8f;

    //The speed in x
    float speedX;
    //The speed in y
    float speedY;



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if(collision.gameObject.tag == "Player")
        {
            //create explosion effect object
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            //prepare to destry explosion object
            Destroy(exp, 0.5f);
            //destroy this object
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //destorys this object if it doesnt hit somthing after 3 seconds
        Destroy(this.gameObject, 3f);
    }


    private void LateUpdate()
    {

        //Actual equation for acceleration
        acceleration = force / mass;

        //how the speed of x changes over time
        speedX += acceleration * Time.deltaTime;
        //How gravity is applied 
        gAccel = gravity / mass;
        speedY += gAccel * Time.deltaTime;

        this.transform.Translate(speedX, speedY, 0);

        //force does not change over time since it was fired
        force = 0;
    }


}
