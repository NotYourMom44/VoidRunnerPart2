using UnityEngine;

public class BossLevelTrigger : MonoBehaviour
{
    private BossProjectileSpawner bossSpawner;

    public bool startBoss = true;

    private void Start()
    {
        bossSpawner = FindObjectOfType<BossProjectileSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bossSpawner == null) return;

            if (startBoss)
            {
                bossSpawner.StartBossAttacks();
            }
            else
            {
                bossSpawner.StopBossAttacks();
            }
        }
    }
}