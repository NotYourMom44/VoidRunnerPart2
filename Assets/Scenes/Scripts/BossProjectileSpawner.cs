using UnityEngine;

public class BossProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform player;
    public Transform firePoint;

    public float attackInterval = 3f;
    private float attackTimer = 0f;

    public Vector3 bossOffset = new Vector3(0, 5, 40);

    private void FixedUpdate()
    {
        attackTimer += Time.fixedDeltaTime;

        if (attackTimer >= attackInterval)
        {
            SpawnProjectile();
            attackTimer = 0f;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = player.position + bossOffset;
        }
    }

    private void SpawnProjectile()
    {
        if (projectilePrefab == null || player == null || firePoint == null)
        {
            Debug.LogWarning("BossProjectileSpawner is missing a reference.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        BossProjectile bossProjectile = projectile.GetComponent<BossProjectile>();

        if (bossProjectile != null)
        {
            bossProjectile.SetTarget(player);
        }

        Debug.Log("Boss fired projectile");
    }
}
