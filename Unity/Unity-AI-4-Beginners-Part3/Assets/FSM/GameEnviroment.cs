using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//As a singleton, this should not inherit monobehavior
//A sealed class means it's non-inheritable and that this is the base class
public sealed class GameEnviroment
{

    //Hold the singleton
    private static GameEnviroment instance;

    //A list of the check points in the enviroment
    private List<GameObject> _checkpoints = new List<GameObject>();

    //A public list of the check points for classes to grab.
    public List<GameObject> Checkpoints { get { return _checkpoints; } }

    public static GameEnviroment Singleton
    {
        get
        {
            //If the singleton doesn't exist create it.
            if (instance == null)
            {
                instance = new GameEnviroment();
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("CheckPoint"));
            }

            return instance;
        }
    }
}
