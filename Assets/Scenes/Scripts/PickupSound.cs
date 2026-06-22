using UnityEngine;

public class PickupSound : MonoBehaviour
{
    public AudioSource pickupSFX;

    private void OnEnable()
    {
        PickupEvents.OnPickupCollected += PlayPickupSound;
    }

    private void OnDisable()
    {
        PickupEvents.OnPickupCollected -= PlayPickupSound;
    }

    private void PlayPickupSound(string pickupName)
    {
        if (pickupSFX != null)
        {
            pickupSFX.Play();
        }
    }
}