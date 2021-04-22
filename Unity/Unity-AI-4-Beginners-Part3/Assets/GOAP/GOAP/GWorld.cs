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

    static GWorld()
    {
        world = new WorldStates();

    }

    private GWorld()
    {

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
