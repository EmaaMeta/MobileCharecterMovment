using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Transform player;
    public Transform triggerObject;
    public float spotlightDistance = 10f;
    public bool followPlayer = false;

    private void Update()
    {

        if (player != null && followPlayer)
        {
            print("(player != null && followPlayer)");
            // Calculate the direction from the spotlight to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Calculate the target position for the spotlight
            Vector3 targetPosition = player.position - directionToPlayer * spotlightDistance;

            // Update the spotlight's position to the target position
            transform.position = targetPosition;

            // Update the spotlight's rotation to look at the player
            transform.LookAt(player.position);
        }
    }

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    public void ActivateSpotlight(bool activate)
    {
        followPlayer = activate;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.transform);
        print("OnTriggerEnter");
        if (other.transform == triggerObject)
        {
            ActivateSpotlight(true);
            print("YES");
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform == triggerObject)
    //    {
    //        ActivateSpotlight(false);
    //    }
    //}
}