
////This code work perfect to trak any mobile shak in any direction
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class AccelerometerTest : MonoBehaviour
//{
//    public TextMeshPro  TextToChange;
//    // Start is called before the first frame update
//    void Start()
//    {
//        print("START - AccelerometerTest");
//        // accessing the static property Instance of the Accelerometer class.
//        Accelerometer.Instance.Onshake += ActionToRunWhenShakingDevice;

//    }

//    private void OnDestroy()
//    {
//        print("OnDestroy - AccelerometerTest");
//        Accelerometer.Instance.Onshake -= ActionToRunWhenShakingDevice;
//    }

//    private void ActionToRunWhenShakingDevice()
//    {
//        //print("Inside ActionToRunWhenShakingDevice - AccelerometerTest");
//        TextToChange.text = "Device shaked";
//        TextToChange.color = Color.green;
//        print(TextToChange.text);
//    }
//}


//----------------------------------------------------------------------
// This code only detiect Back to Front and Front To back Mobile Shaking
//using TMPro;
//using UnityEngine;

//public class AccelerometerTest : MonoBehaviour
//{
//    public TextMeshPro TextToChange;
//    private void Start()
//    {
//        Accelerometer.Instance.OnShakeFrontToBack += HandleShakeFrontToBack;
//        Accelerometer.Instance.OnShakeBackToFront += HandleShakeBackToFront;
//    }

//    private void HandleShakeFrontToBack()
//    {
//        // Code to execute when front-to-back shake is detected
//        Debug.Log("Front-to-back shake detected");
//        TextToChange.text = "Front To Back";
//        TextToChange.color = Color.red;
//    }

//    private void HandleShakeBackToFront()
//    {
//        // Code to execute when back-to-front shake is detected
//        Debug.Log("Back-to-front shake detected");
//        TextToChange.text = "Back To Front";
//        TextToChange.color = Color.blue;
//    }
//}

//----------------------------------------------------------------------
//------------- Workimng Perfect for all direction----------------------

//This code will detect all shaking direction Fromt/Back,Back/Front, Left/Right,Right/Left
//using TMPro;
//using UnityEngine;

//public class AccelerometerTest : MonoBehaviour
//{
//    public TextMeshPro TextToChange;

//    private void Start()
//    {
//        Accelerometer.Instance.OnShakeFrontToBack += HandleShakeFrontToBack;
//        Accelerometer.Instance.OnShakeBackToFront += HandleShakeBackToFront;
//        Accelerometer.Instance.OnShakeRightToLeft += HandleShakeRightToLeft;
//        Accelerometer.Instance.OnShakeLeftToRight += HandleShakeLeftToRight;
//    }

//    private void HandleShakeFrontToBack()
//    {
//        // Code to execute when front-to-back shake is detected
//        Debug.Log("Front-to-back shake detected");
//        TextToChange.text = "Front To Back";
//        TextToChange.color = Color.red;
//    }

//    private void HandleShakeBackToFront()
//    {
//        // Code to execute when back-to-front shake is detected
//        Debug.Log("Back-to-front shake detected");
//        TextToChange.text = "Back To Front";
//        TextToChange.color = Color.blue;
//    }

//    private void HandleShakeRightToLeft()
//    {
//        // Code to execute when right-to-left shake is detected
//        Debug.Log("Right-to-left shake detected");
//        TextToChange.text = "Right To Left";
//        TextToChange.color = Color.green;
//    }

//    private void HandleShakeLeftToRight()
//    {
//        // Code to execute when left-to-right shake is detected
//        Debug.Log("Left-to-right shake detected");
//        TextToChange.text = "Left To Right";
//        TextToChange.color = Color.yellow;
//    }
//}
//-----------------------------------------------------------------------

// Store the current shake direction for the next shake
using TMPro;
using UnityEngine;

public class AccelerometerTest : MonoBehaviour
{
    public TextMeshPro TextToChange;
    public float shakeForce = 1.0f;
    public Transform cube;

    private Vector3 initialCubePosition;
    private Vector3 previousShakeDirection;
    private bool isShaking;

    private void Start()
    {
        initialCubePosition = cube.position;
        Accelerometer.Instance.OnShakeDetected += HandleShakeDetected;
    }

    private void HandleShakeDetected(Vector3 shakeDirection)
    {
        // Calculate the desired movement based on the shake direction
        Vector3 movement = Vector3.zero;

        // Determine the dominant shake direction
        Vector3 absShakeDirection = new Vector3(Mathf.Abs(shakeDirection.x), Mathf.Abs(shakeDirection.y), Mathf.Abs(shakeDirection.z));
        float maxShakeValue = Mathf.Max(absShakeDirection.x, absShakeDirection.y, absShakeDirection.z);

        // Update the movement based on the dominant shake direction
        if (maxShakeValue == absShakeDirection.x)
        {
            movement = new Vector3(shakeDirection.x, 0f, 0f);
        }
        else if (maxShakeValue == absShakeDirection.z)
        {
            movement = new Vector3(0f, 0f, shakeDirection.z);
        }

        // Update the cube's position relative to its initial position
        Vector3 newPosition = initialCubePosition + movement * shakeForce;
        newPosition.x = Mathf.Clamp(newPosition.x, -5f, 5f); // Limit the x position between -5 and 5
        newPosition.y = initialCubePosition.y;
        newPosition.z = Mathf.Clamp(newPosition.z, -5f, 5f); // Limit the z position between -5 and 5

        // Move the cube to the new position
        cube.position = newPosition;

        // Update the initial cube position for the next shake
        initialCubePosition = newPosition;

        // Check if the current shake direction is the same as the previous one
        if (shakeDirection != previousShakeDirection)
        {
            // Change the text based on the dominant shake direction when the shake direction changes
            if (maxShakeValue == absShakeDirection.x)
            {
                if (shakeDirection.x > 0)
                {
                    TextToChange.text = "Right";
                    TextToChange.color = Color.green;
                }
                else
                {
                    TextToChange.text = "Left";
                    TextToChange.color = Color.yellow;
                }
            }
            else if (maxShakeValue == absShakeDirection.z)
            {
                if (shakeDirection.z > 0)
                {
                    TextToChange.text = "Front";
                    TextToChange.color = Color.blue;
                }
                else
                {
                    TextToChange.text = "Back";
                    TextToChange.color = Color.red;
                }
            }
        }

        // Store the current shake direction for the next shake
        previousShakeDirection = shakeDirection;
    }
}