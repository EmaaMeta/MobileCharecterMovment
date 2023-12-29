//------------------------------------------------------------------------------------------------------------
//------------ Capsule rotate around self and move forword when i press W or up arrow ------------------------
//------------------------------------------------------------------------------------------------------------

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharectuerRotationandMovment : MonoBehaviour
//{ 
//    public float rotationSpeed = 100f;
//    public float moveSpeed = 5f;

//    private bool isRotating = true;
//    private Quaternion targetRotation;

//    private void Update()
//    {
//        if (isRotating)
//        {
//            // Continuously rotate the player around itself
//            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
//        }

//        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            // Stop rotating and start moving forward
//            isRotating = false;
//            targetRotation = transform.rotation;
//        }

//        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
//        {
//            // Resume rotating in the last position without moving forward
//            isRotating = true;
//            transform.rotation = targetRotation;
//        }

//        if (!isRotating)
//        {
//            // Move forward in the direction the player was facing
//            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
//        }
//    }
//}



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~ Capsule rotate around self and move forword when i press W or up arrow~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~ draws a green line or ray from the player's position indicating the direction of movement~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

//using UnityEngine;

//public class CharectuerRotationandMovment : MonoBehaviour
//{
//    public float rotationSpeed = 100f;
//    public float moveSpeed = 5f;

//    private bool isRotating = true;
//    private Quaternion targetRotation; // Quaternion:rotation in 3D space. rotations are typically represented using quaternions instead of Euler angles

//    private void Update()
//    {
//        if (isRotating)
//        {
//            // Continuously rotate the player around itself
//            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Vector3.up = positive y-axis
//        }

//        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            // Stop rotating and start moving forward
//            isRotating = false;
//            targetRotation = transform.rotation;//store the rotation of the player at a specific moment in time.
//        }

//        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
//        {
//            // Resume rotating in the last position without moving forward
//            isRotating = true;
//            transform.rotation = targetRotation;
//        }

//        if (!isRotating)
//        {
//            // Move forward in the direction the player was facing
//            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

//            // Draw a line to visualize the movement direction
//            Debug.DrawRay(transform.position, transform.forward * 6f, Color.green); //Debug.DrawRay : draws a green line or ray from the player's position in the Scene view, indicating the direction of movement.
//        }
//    }
//}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~ Capsule rotate around self and move forword when i Shake Mobile~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~ draws a green line or ray from the player's position indicating the direction of movement~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
using UnityEngine;

public class CharectuerRotationandMovment : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float moveSpeed = 5f;

    private bool isRotating = true;
    private Quaternion targetRotation;

    private bool isShaking = false;
    private float shakeThreshold = 2f; // Adjust this value to control the sensitivity of the shake detection

    private bool isMoving = false;

    private void Update()
    {
        if (isRotating)
        {
            // Continuously rotate the player around itself
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (isMoving)
        {
            // Move forward in the direction the player was facing
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (!isShaking && isMoving)
        {
            // Stop moving and resume rotating when shaking stops
            isMoving = false;
            isRotating = true;
        }
    }
 

    
    private void FixedUpdate()
    {
        // Detect mobile device shake
        float acceleration = Input.acceleration.magnitude;
        if (acceleration > shakeThreshold)
        {
            isShaking = true;

            if (!isMoving)
            {
                // Start moving when shaking begins and stop rotating
                isMoving = true;
                isRotating = false;
                targetRotation = transform.rotation;
            }
        }
        else
        {
            isShaking = false;

            if (isMoving)
            {
                // Stop moving and resume rotating when shaking stops
                isMoving = false;
                isRotating = true;
                transform.rotation = targetRotation;
            }
        }
    }
}