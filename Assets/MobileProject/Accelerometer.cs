

//This code work perfect to trak any mobile shak in any direction
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Accelerometer : MonoBehaviour
//{


//    private static Accelerometer instance;
//    public static Accelerometer Instance { get { return instance; } }// allowing to be accessed from anywhere in the code without needing an instance of the Accelerometer script.



//    [Header("Shake Detection")]
//    public Action Onshake;


//    [SerializeField] private float ShakeDetectionThreshold = 2.0f;
//    private float accelermoterUpdateInterval = 1.0f / 60.0f;
//    private float lowPassKernelWidthInSeconds = 1.0f;
//    private float lowPassFilterFactor;
//    private Vector3 lowPassValue;

//    private void Awake()
//    {
//        if (instance == null)
//            instance = this;
//        else
//            Destroy(this.gameObject);

//        DontDestroyOnLoad(this.gameObject);
//    }

//    private void Start()
//    {
//        Debug.Log("Accelerometer script started");
//        //DontDestroyOnLoad(this.gameObject);

//        lowPassFilterFactor = accelermoterUpdateInterval / lowPassKernelWidthInSeconds;
//        ShakeDetectionThreshold *= ShakeDetectionThreshold;
//        lowPassValue = Input.acceleration;
//    }

//    private void Update()
//    {
//        Vector3 acceleration = Input.acceleration;
//        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
//        Vector3 deltaAcceleration = acceleration - lowPassValue;


//        //any mobile shake direction Detection
//        if (deltaAcceleration.sqrMagnitude >= ShakeDetectionThreshold)
//            Onshake?.Invoke();
//    }

//}

//----------------------------------------------------------------------
// This code only detiect Back to Front and Front To back Mobile Shaking
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class Accelerometer : MonoBehaviour
//{
//    private static Accelerometer instance;
//    public static Accelerometer Instance { get { return instance; } }

//    [Header("Shake Detection")]
//    public Action OnShakeFrontToBack;
//    public Action OnShakeBackToFront;

//    [SerializeField] private float shakeDetectionThreshold = 2.0f;
//    private float accelerometerUpdateInterval = 1.0f / 60.0f;
//    private float lowPassKernelWidthInSeconds = 1.0f;
//    private float lowPassFilterFactor;
//    private Vector3 lowPassValue;

//    private void Awake()
//    {
//        if (instance == null)
//            instance = this;
//        else
//            Destroy(this.gameObject);

//        DontDestroyOnLoad(this.gameObject);
//    }

//    private void Start()
//    {
//        Debug.Log("Accelerometer script started");

//        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
//        shakeDetectionThreshold *= shakeDetectionThreshold;
//        lowPassValue = Input.acceleration;
//    }

//    private void Update()
//    {
//        Vector3 acceleration = Input.acceleration;
//        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
//        Vector3 deltaAcceleration = acceleration - lowPassValue;

//        // Detect front-to-back shaking
//        if (Mathf.Abs(deltaAcceleration.z) >= shakeDetectionThreshold)
//        {
//            if (deltaAcceleration.z > 0)
//                OnShakeFrontToBack?.Invoke();
//            else
//                OnShakeBackToFront?.Invoke();
//        }
//    }
//}
//----------------------------------------------------------------------



//-----------------------------------------------------------------------------------------
//This code will detect all shaking direction Fromt/Back,Back/Front, Left/Right,Right/Left
//---------------------- Workimng Perfect for all direction-------------------------------
//-----------------------------------------------------------------------------------------

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Accelerometer : MonoBehaviour
//{
//    private static Accelerometer instance;
//    public static Accelerometer Instance { get { return instance; } }

//    [Header("Shake Detection")]
//    public Action OnShakeFrontToBack;
//    public Action OnShakeBackToFront;
//    public Action OnShakeRightToLeft;
//    public Action OnShakeLeftToRight;

//    [SerializeField] private float shakeDetectionThreshold = 2.0f;
//    private float accelerometerUpdateInterval = 1.0f / 60.0f;
//    private float lowPassKernelWidthInSeconds = 1.0f;
//    private float lowPassFilterFactor;
//    private Vector3 lowPassValue;

//    private void Awake()
//    {
//        if (instance == null)
//            instance = this;
//        else
//            Destroy(this.gameObject);

//        DontDestroyOnLoad(this.gameObject);
//    }

//    private void Start()
//    {
//        Debug.Log("Accelerometer script started");

//        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
//        shakeDetectionThreshold *= shakeDetectionThreshold;
//        lowPassValue = Input.acceleration;
//    }

//    private void Update()
//    {
//        Vector3 acceleration = Input.acceleration;
//        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
//        Vector3 deltaAcceleration = acceleration - lowPassValue;

//        // Detect front-to-back shaking
//        if (Mathf.Abs(deltaAcceleration.z) >= shakeDetectionThreshold)
//        {
//            if (deltaAcceleration.z > 0)
//                OnShakeFrontToBack?.Invoke();
//            else
//                OnShakeBackToFront?.Invoke();
//        }

//        // Detect right-to-left shaking
//        if (Mathf.Abs(deltaAcceleration.x) >= shakeDetectionThreshold)
//        {
//            if (deltaAcceleration.x < 0)
//                OnShakeRightToLeft?.Invoke();
//            else
//                OnShakeLeftToRight?.Invoke();
//        }
//    }
//}
//-----------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accelerometer : MonoBehaviour
{
    private static Accelerometer instance;
    public static Accelerometer Instance { get { return instance; } }

    [Header("Shake Detection")]
    public Action<Vector3> OnShakeDetected;

    [SerializeField] private float shakeDetectionThreshold = 2.0f;
    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    private float lowPassKernelWidthInSeconds = 1.0f;
    private float lowPassFilterFactor;
    private Vector3 lowPassValue;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Debug.Log("Accelerometer script started");

        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        // Detect shake in any direction
        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            OnShakeDetected?.Invoke(deltaAcceleration);
        }
    }
}