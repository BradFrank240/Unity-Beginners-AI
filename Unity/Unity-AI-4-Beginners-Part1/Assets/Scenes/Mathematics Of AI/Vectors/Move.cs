using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //script to move goal cube

    //Stores inputs
    private float _HorizontalInput;
    private float _VerticalInput;

    //Stores speed
    public float playerSpeed = 2f;



    private void Update()
    {
        //Gets inputs
        _HorizontalInput = Input.GetAxis("Horizontal");
        _VerticalInput = Input.GetAxis("Vertical");
    }

    private void LateUpdate()
    {
        this.transform.Translate(new Vector3(_HorizontalInput, 0, _VerticalInput) * playerSpeed * Time.deltaTime);
    }



}
