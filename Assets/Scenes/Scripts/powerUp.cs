using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float speedBoostAmount = 2f;
    public float boostDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Ballroll playerMovement = other.GetComponent<Ballroll>();

            if (playerMovement != null)
            {
                playerMovement.StartSpeedBoost(speedBoostAmount, boostDuration);
            }

            Destroy(gameObject);
        }
    }
}