using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    public GameObject playerObject;
    public SpotlightController spotlightController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            Transform playerTransform = playerObject.transform;
            spotlightController.SetPlayer(playerTransform);
            Debug.Log("Player entered the spot range.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObject)
        {
            spotlightController.SetPlayer(null);
            Debug.Log("Player exited the spot range.");
        }
    }
}