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


    private int loopIndex = 0;

    private float currentCycleY = 0f;

    private GameObject[] levelPattern;

    void Start()
    {
        levelPattern = new GameObject[]
        {
            level1Prefab, level1Prefab,
            level2Prefab, level2Prefab, level2Prefab,
            level3Prefab, level3Prefab, level3Prefab, level3Prefab, level3Prefab, level3Prefab
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
        GameObject levelToSpawn = levelPattern[loopIndex];

        Vector3 spawnPosition = new Vector3(
            0.5f,
            currentCycleY,
            playerTransform.position.z + spawnDistance
        );

        if (levelToSpawn == level3Prefab)
        {
            spawnPosition.y = currentCycleY - 4f;
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

        if (loopIndex >= levelPattern.Length)
        {
            loopIndex = 0;

            currentCycleY = playerTransform.position.y;
        }
    }
}



