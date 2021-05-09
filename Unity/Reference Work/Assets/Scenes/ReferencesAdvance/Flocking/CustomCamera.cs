using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    //If user is focused on an object
    private bool isFocused = false;

    //Object current focused on
    private GameObject currentFocus;

    //camera rotation spped
    public float rotationSpeed = 10f;
    
    void Update()
    {
        if (isFocused)
        {
            Quaternion lookRotation = Quaternion.LookRotation(currentFocus.transform.position - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isFocused = false;
                currentFocus = null;
            }

            
            if (Input.GetMouseButtonDown(0))
            {
                currentFocus = FocusOnObject();
            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentFocus = FocusOnObject();
            }
            
        }
    }

    private GameObject FocusOnObject()
    {
         RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != null)
                {
                    
                    isFocused = true;
                    return hit.collider.gameObject;
                }
            }

        if(isFocused == true)
        {
            return currentFocus;
        }
        

        return null;
    }
}
