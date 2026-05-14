using UnityEngine;

public class ShieldPickupSpawner : MonoBehaviour
{
    public GameObject shieldPickupPrefab;
    public int pickupCount = 3;
    public float spawnHeight = 1f;

    void Start()
    {
        SpawnPickups();
    }

    void SpawnPickups()
    {
        Collider spawnArea = GetComponent<Collider>();

        if (spawnArea == null)
        {
            Debug.LogWarning("ShieldPickupSpawner needs a Collider.");
            return;
        }

        for (int i = 0; i < pickupCount; i++)
        {
            Vector3 point = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                spawnHeight,
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            Instantiate(shieldPickupPrefab, point, Quaternion.identity);
        }
    }
}
