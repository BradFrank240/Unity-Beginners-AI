using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    //We want the player to move on the x and z axis and turn using a & d

    public Vector3 Goal;
    
    private float forwardInput;

    
    public float moveSpeed = 5f;
    public float turningSpeed = 100f;



    private void Start()
    {
     
    }


    private void Update()
    {
        UpdateInput();

        MoveTowardsGoal();




    }

    private void LateUpdate()
    {
       

        LookAtGoal(Goal);

        
    }



    private void UpdateInput()
    {
        forwardInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Goal = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }




    }




    private void LookAtGoal(Vector3 goal)
    {

        Quaternion lookAtGoal = Quaternion.LookRotation(goal - transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtGoal, turningSpeed * Time.deltaTime);

    }

    private void MoveTowardsGoal()
    {
        transform.Translate(new Vector3(0, 0, forwardInput));
    }


}
