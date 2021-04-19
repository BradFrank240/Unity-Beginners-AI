using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAvoid : MonoBehaviour
{

    public GameObject obstacle;
    GameObject[] _agents;

    private void Start()
    {
        _agents = GameObject.FindGameObjectsWithTag("SAFE");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out hitinfo))
            {
                Instantiate(obstacle, hitinfo.point, obstacle.transform.rotation);
                Destroy(obstacle, 10f);
                
                foreach(GameObject agent in _agents)
                {
                    agent.GetComponent<controlAI>().DetectNewObstacle(new Vector3(hitinfo.point.x, agent.transform.position.y, hitinfo.point.z));
                    
                }
            }
        }
    }


}
