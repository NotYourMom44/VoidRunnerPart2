using UnityEngine;

public class SpeedPickup : MonoBehaviour, IPickup
{
    public void ActivatePickup(GameObject player)
    {
        PlayerSpeedBoost speedBoost = player.GetComponent<PlayerSpeedBoost>();

        if (speedBoost != null)
        {
            speedBoost.ActivateSpeedBoost();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePickup(other.gameObject);
            PickupEvents.PickupCollected("Speed");
            Destroy(gameObject);
        }
    }
}