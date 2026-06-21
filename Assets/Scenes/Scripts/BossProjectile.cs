using UnityEngine;
using UnityEngine.SceneManagement;

public class BossProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 8f;

    private Vector3 moveDirection;
    private bool hasDirection = false;

    public void SetTarget(Transform playerTarget)
    {
        Vector3 targetPosition = playerTarget.position;

        moveDirection = (targetPosition - transform.position).normalized;
        hasDirection = true;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (!hasDirection) return;

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponent<PlayerShield>();

            if (shield != null && shield.shieldActive)
            {
                Debug.Log("Shield blocked boss projectile");
                Destroy(gameObject);
                return;
            }

            Debug.Log("Boss projectile hit player");
            SceneManager.LoadScene("deathScene");
        }
    }
}