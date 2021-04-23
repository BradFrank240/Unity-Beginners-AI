using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Sealed to make sure only one thing can be accesed at a time
public sealed class GWorld 
{
    //this singleton
    private static readonly GWorld instance = new GWorld();

    //dictionary holding all world states
    private static WorldStates world;

    //patients go in the queue for the nurst to get rid of 
    private static Queue<GameObject> patients;

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
    }



    public void AddPatient(GameObject p) 
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance;  }
    }

    public WorldStates GetWorld()
    {
        return world;
    }





}
