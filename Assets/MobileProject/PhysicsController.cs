using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float ShakeForceMulitplayer;
    public Rigidbody[] ShakingRB;

    public void ShakeRB(Vector3 deviceAcclration)
    { 
        foreach (var rigibody in ShakingRB)
        {
            rigibody.AddForce(deviceAcclration * ShakeForceMulitplayer, ForceMode.Impulse);

        }
    }
}
