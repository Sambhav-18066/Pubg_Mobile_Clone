using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float sensitivity = 5f; 

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X"); 
           // float mouseY = Input.GetAxis("Mouse Y"); 

            transform.Rotate(Vector3.up, mouseX * sensitivity); 
           // transform.Rotate(Vector3.right, -mouseY * sensitivity); 
        }

        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x * sensitivity; 
                //float deltaY = touch.deltaPosition.y * sensitivity; 

                transform.Rotate(Vector3.up, deltaX); 
               // transform.Rotate(Vector3.right, -deltaY); 
            }
        }

        }
}
