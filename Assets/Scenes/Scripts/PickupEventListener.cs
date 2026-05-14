using UnityEngine;

public class PickupEventListener : MonoBehaviour
{
    private void OnEnable()
    {
        PickupEvents.OnPickupCollected += HandlePickupCollected;
    }

    private void OnDisable()
    {
        PickupEvents.OnPickupCollected -= HandlePickupCollected;
    }

    private void HandlePickupCollected(string pickupName)
    {
        Debug.Log("Event caught: " + pickupName + " pickup collected");
    }
}