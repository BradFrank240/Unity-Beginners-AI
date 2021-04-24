using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject patientPrefab;
    public int numPatients;

    private void Start()
    {
        
       Invoke("SpawnPatient", 5);

    }

    void SpawnPatient()
    {
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        Instantiate(patientPrefab, this.transform.position, Quaternion.identity);


        Invoke("SpawnPatient", Random.Range(2, 7)); 
    }


}
