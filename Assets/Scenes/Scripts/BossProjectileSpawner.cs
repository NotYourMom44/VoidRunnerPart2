using UnityEngine;
using TMPro;
using System.Collections;

public class BossProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform player;
    public Transform firePoint;

    public TMP_Text bossWarningText;
    public float warningDuration = 2f;

    public float attackInterval = 3f;
    public Vector3 bossOffset = new Vector3(0, 5, 40);

    private float attackTimer = 0f;
    private bool bossActive = false;

    private void Update()
    {
        if (player != null)
        {
            transform.position = player.position + bossOffset;
        }
    }

    private void FixedUpdate()
    {
        if (!bossActive) return;

        attackTimer += Time.fixedDeltaTime;

        if (attackTimer >= attackInterval)
        {
            SpawnProjectile();
            attackTimer = 0f;
        }
    }

    public void StartBossAttacks()
    {
        if (!bossActive)
        {
            StartCoroutine(BossWarningRoutine());
        }

        bossActive = true;
        attackTimer = 0f;
        Debug.Log("Boss attacks started");
    }

    public void StopBossAttacks()
    {
        bossActive = false;
        attackTimer = 0f;
        Debug.Log("Boss attacks stopped");
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

    private IEnumerator BossWarningRoutine()
    {
        if (bossWarningText != null)
        {
            bossWarningText.gameObject.SetActive(true);
            bossWarningText.text = "VOID SENTINEL ATTACK INCOMING";
        }

        yield return new WaitForSeconds(warningDuration);

        if (bossWarningText != null)
        {
            bossWarningText.gameObject.SetActive(false);
        }
    }
}