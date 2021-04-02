using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Hold shells that are fired
    public GameObject shellPrefab;

    //holds position to spawn shell
    public GameObject shellSpawnPos;

    //Reference to the target
    public GameObject target;

    //reference to the parent object
    public GameObject _parent;

    //initial speed for projectile
    float speed = 15f;

    //Look roation
    float turnSpeed = 2f;




    private void Update()
    {

        //When space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fires shell
            Fire();
        }

        float? angle = RotateTurret();


        /*Something wrong here and just gonna get rid of it, beleive to be due to 2d prodject instead of 3d. 
        //Direction of enemy in a normalized vector a a vector length of 1
        Vector3 direction = (target.transform.position - _parent.transform.position).normalized;

        Debug.DrawRay(_parent.transform.position, direction * 10, Color.blue);

        //Gets the direction it should be looking
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        //Somthing is wrong with code here but right now i don't see, and it isnt required for the core subject of the lesson.

        //Has parent rotation smoothy look from one direction to another
        _parent.transform.rotation = Quaternion.Slerp(_parent.transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0)), Time.deltaTime * turnSpeed);
        */

    }


    float? RotateTurret()
    {
        float? angle = CalculateAngle(true);
        if(angle != null)
        {
            this.transform.localEulerAngles = new Vector3(0f, 0f, -(360f - (float)angle));
        }

        return angle;
    }

    float? CalculateAngle(bool low)
    {
        //Start with direction to target
        Vector3 targetDir = target.transform.position - this.transform.position;

        //Get the y componenet
        float y = targetDir.y;

        //makes target direction just the x and z
        targetDir.y = 0;
        //Length or distance of vection
        float x = targetDir.magnitude;

        //gravity being applied
        float gravity = 9.81f;

        //speed square rooted
        float sSqr = speed * speed;

        //The complicated equation
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * y * sSqr);

        //when true, their is a potential angel
        if(underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);

            // The low and high angles of the parabola
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low)
            {

                return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            }
            else
            {
                return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
            }
        }
        else
        {
            return null;
        }


    }

    void Fire()
    {
        //Creates shell
        GameObject shell = Instantiate(shellPrefab, shellSpawnPos.transform.position, shellSpawnPos.transform.rotation);
    }


}
