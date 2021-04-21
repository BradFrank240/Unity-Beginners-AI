using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LocationManager
{

    //Hold the singleton
    private static LocationManager instance;

    //Holds all the checkpoints in the scene
    private List<GameObject> _checkpoints = new List<GameObject>();

    //A public list of check points for classes to grab
    public List<GameObject> Checkpoints { get { return _checkpoints;  } }

    
    public static LocationManager Singleton
    {
        get
        {
            if(instance == null)
            {
                //create a new manager
                instance = new LocationManager();
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("CheckPoint"));
                

            }

            return instance;
        }
    }

    

}
