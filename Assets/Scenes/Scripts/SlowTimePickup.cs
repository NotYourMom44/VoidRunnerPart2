using UnityEngine;

public class SlowTimePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSlowTime slowTime = other.GetComponent<PlayerSlowTime>();

            if (slowTime != null)
            {
                slowTime.ActivateSlowTime();
                Destroy(gameObject);
            }
        }
    }
}
