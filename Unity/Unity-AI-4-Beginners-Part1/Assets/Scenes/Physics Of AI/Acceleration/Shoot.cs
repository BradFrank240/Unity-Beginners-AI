using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Hold shells that are fired
    public GameObject shellPrefab;

    //holds position to spawn shell
    public GameObject shellSpawnPos;






    private void Update()
    {

        //When space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Fires shell
            Fire();
        }
    }


    void Fire()
    {
        //Creates shell
        GameObject shell = Instantiate(shellPrefab, shellSpawnPos.transform.position, shellSpawnPos.transform.rotation);
    }


}
