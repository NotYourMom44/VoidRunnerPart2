using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 8f;

    private Transform target;

    public void SetTarget(Transform playerTarget)
    {
        target = playerTarget;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("deathScene");
        }
    }
}
