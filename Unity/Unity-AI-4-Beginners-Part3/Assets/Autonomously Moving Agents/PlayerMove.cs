using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float horizontalInput;

    private float verticalInput;

    public float moveSpeed = 5;
    public float rotationSpeed = 100;

    public float currentSpeed = 0;


    
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        currentSpeed = verticalInput;
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, verticalInput * Time.deltaTime);
        transform.Rotate(0, horizontalInput, 0);
    }




}
