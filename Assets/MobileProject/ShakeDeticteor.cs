using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PhysicsController))]

public class ShakeDeticteor : MonoBehaviour
{
    // Start is called before the first frame update


    public float ShakeDetectionThresholde;
    public float MainShakeInterval;


    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;
    private PhysicsController physicsControl;
    
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThresholde, 2);
        physicsControl= GetComponent<PhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
            && Time.unscaledTime >=timeSinceLastShake + MainShakeInterval )
        {
            physicsControl.ShakeRB(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;

        }
    }
}
