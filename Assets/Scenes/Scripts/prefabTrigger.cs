using UnityEngine;

public class prefabTrigger : MonoBehaviour
{
    public GameObject level1Prefab;
    public GameObject level2Prefab;
    public GameObject level3Prefab;
    public GameObject portalPrefab;
    public AudioSource portalWarp;

    public Transform playerTransform;

    public float spawnDistance = 99f;
    public float levelDestroyTime = 20f;

    public BossProjectileSpawner bossSpawner;

    private int loopIndex = 0;
    private float currentCycleY = 0f;

    private GameObject[] introPattern;

    void Start()
    {
        introPattern = new GameObject[]
        {
            level1Prefab,
            level2Prefab,
            level3Prefab
        };

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spawn"))
        {
            if (portalWarp != null)
            {
                portalWarp.Play();
            }

            SpawnNextLevel();
        }
    }

    void SpawnNextLevel()
    {
        GameObject levelToSpawn;

        if (loopIndex < introPattern.Length)
        {
            levelToSpawn = introPattern[loopIndex];
        }
        else
        {
            levelToSpawn = Random.value > 0.5f ? level2Prefab : level3Prefab;
        }

        if (bossSpawner != null)
        {
            if (levelToSpawn == level3Prefab)
            {
                bossSpawner.StartBossAttacks();
            }
            else
            {
                bossSpawner.StopBossAttacks();
            }
        }

        Vector3 spawnPosition = new Vector3(
    0.5f,
    0f,
    playerTransform.position.z + spawnDistance
);

        if (levelToSpawn == level3Prefab)
        {
            spawnPosition.y = -4f;
        }

        GameObject newLevel = Instantiate(levelToSpawn, spawnPosition, Quaternion.identity);
        newLevel.name = levelToSpawn.name;

        if (portalPrefab != null)
        {
            GameObject newPortal = Instantiate(portalPrefab, spawnPosition, Quaternion.identity);
            newPortal.name = portalPrefab.name;
            Destroy(newPortal, levelDestroyTime);
        }

        Destroy(newLevel, levelDestroyTime);

        loopIndex++;

    }
}