using System.Collections.Generic;
using UnityEngine;

public class pickUpGeneration : MonoBehaviour
{
    public GameObject coloumn;
    public float columnDestroy = 20f;
    public int objectNo = 8;

    public float columnY = -4f;
    public float minimumDistance = 8f;

    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        SpawnColoumns();
    }

    void SpawnColoumns()
    {
        Collider spawnArea = GetComponent<Collider>();

        if (spawnArea == null)
        {
            Debug.LogWarning("Column spawner needs a collider.");
            return;
        }

        int spawned = 0;
        int attempts = 0;

        while (spawned < objectNo && attempts < 100)
        {
            attempts++;

            Vector3 point = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                columnY,
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            if (IsFarEnough(point))
            {
                GameObject newColumn = Instantiate(coloumn, point, Quaternion.identity);
                newColumn.name = coloumn.name;

                Destroy(newColumn, columnDestroy);

                spawnedPositions.Add(point);
                spawned++;
            }
        }
    }

    bool IsFarEnough(Vector3 point)
    {
        foreach (Vector3 existingPoint in spawnedPositions)
        {
            if (Vector3.Distance(point, existingPoint) < minimumDistance)
            {
                return false;
            }
        }

        return true;
    }
}