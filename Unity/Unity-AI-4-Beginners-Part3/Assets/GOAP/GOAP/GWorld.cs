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

    //Holds all the surgery tables
    private static Queue<GameObject> cubicles;

    static GWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();

        //Just adding cubicles instaed of dynmaicly adding them
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Surgery");
        foreach (GameObject c in cubes)
        {
            
            cubicles.Enqueue(c);
        }

        if (cubes.Length > 0)
        {
            world.ModifyState("FreeCubicle", cubes.Length);
        }

    }

    private GWorld()
    {
       
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

    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }
    
    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0)
        {
            return null;
        }
        return cubicles.Dequeue();
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
