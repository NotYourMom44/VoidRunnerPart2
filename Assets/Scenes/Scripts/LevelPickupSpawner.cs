using UnityEngine;

public class LevelPickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs;
    public GameObject[] pickupPoints;
    public int pickupsToSpawn = 2;

    void Start()
    {
        SpawnPickups();
    }

    void SpawnPickups()
    {
        for (int i = 0; i < pickupsToSpawn; i++)
        {
            GameObject chosenPoint = pickupPoints[Random.Range(0, pickupPoints.Length)];
            GameObject chosenPickup = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];

            Instantiate(
                chosenPickup,
                chosenPoint.transform.position,
                chosenPoint.transform.rotation
            );
        }
    }
}
