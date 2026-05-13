using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
//using Random = System.Random;

public class pickUpSpawnBoss : MonoBehaviour
{
    public GameObject speedPickUp;
    public Collider levelCollider;
    public int pickUpNo;
    // Start is called before the first frame update
    void Start()
    {
        pickUpSpawnerBoss();
    }

    void pickUpSpawnerBoss()
    {
        Vector3 GetRandomPointInCollider(Collider collider)//function to get the location for coin spawn
        {
            Vector3 point = new Vector3
                (
                    UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),//This sets the random spwan to always be on the platform
                    UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                    UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );

            point.y = -2;

            //point.y = 1;//makes the coins spawn on the ground
            return point;
        }


        for (int i = 0; i < pickUpNo; i++) 
        {
            GameObject score = Instantiate(speedPickUp);//spawns token
            score.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }


    }
}
