using UnityEngine;

public class SlowTimePickup : MonoBehaviour, IPickup
{
    public void ActivatePickup(GameObject player)
    {
        PlayerSlowTime slowTime = player.GetComponent<PlayerSlowTime>();

        if (slowTime != null)
        {
            slowTime.ActivateSlowTime();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivatePickup(other.gameObject);
            PickupEvents.PickupCollected("Slow Time");
            Destroy(gameObject);
        }
    }
}
