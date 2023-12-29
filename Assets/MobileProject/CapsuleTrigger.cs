using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    public GameObject spotlightObject;
    private bool isFollowing = false; // Flag to track if the capsule is within the trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spotlight")
        {
            Debug.Log("Capsule entered spotlight!");
            isFollowing = true; // Start following the capsule
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spotlight")
        {
            Debug.Log("Capsule exited spotlight!");
            isFollowing = false; // Stop following the capsule
        }
    }

    private void Update()
    {
        if (isFollowing)
        {
            // Get the capsule's position
            Vector3 capsulePosition = transform.position;

            // Set the spotlight's X and Z to match the capsule, keeping its original Y
            Transform spotlightTransform = spotlightObject.transform;
            spotlightTransform.position = new Vector3(capsulePosition.x, spotlightTransform.position.y, capsulePosition.z);

            // Optionally, make the spotlight look at the capsule
            spotlightTransform.LookAt(transform);
        }
    }
}
