using UnityEngine;

public class ShieldPickup : MonoBehaviour, IPickup
{
    public void ActivatePickup(GameObject player)
    {
        PlayerShield shield = player.GetComponent<PlayerShield>();

        if (shield != null)
        {
            shield.ActivateShield();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePickup(other.gameObject);
            PickupEvents.PickupCollected("Shield");
            Destroy(gameObject);
        }
    }
}
