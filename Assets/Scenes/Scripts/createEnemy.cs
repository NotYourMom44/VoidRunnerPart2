using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class createEnemy : MonoBehaviour
{
    public GameObject level_1;
   
    public GameObject level_3;

    public GameObject enemy;

    public Transform levelTransform;

    public float spawnDistance = 5f;

    public Collider levelCollider;

    public Collider levelCollider2;

    public Collider levelCollider3;

    public GameObject enemyBoss;

    public int enemyNo;//token amount

    // Start is called before the first frame update


    void Start()
    {
        EnemySpawn();

      
    }
/*
    private void FixedUpdate()
    {
        int bossNo = 2;
        for (int b = 1; b < bossNo; b++)
        {
            if (levelCollider3 != null)
            {
                Vector3 GetRandomPointInCollider(Collider collider)//function to get the location for coin spawn
                {
                    Vector3 point = new Vector3
                        (
                            Random.Range(collider.bounds.min.x, collider.bounds.max.x),//This sets the random spwan to always be on the platform
                            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                        );

                    point.y = 5;

                    //point.y = 1;//makes the coins spawn on the ground
                    return point;
                }

                int scoreNo = 1;//token amount
                for (int i = 0; i < scoreNo; i++)
                {
                    GameObject score = Instantiate(enemyBoss);//spawns token
                    score.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
                }
            }
        }
    }
*/

    public void EnemySpawn()
    {

        Vector3 GetRandomPointInCollider(Collider collider)//function to get the location for coin spawn
        {
            Vector3 point = new Vector3
                (
                    Random.Range(collider.bounds.min.x, collider.bounds.max.x),//This sets the random spwan to always be on the platform
                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                    Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );

            point.y = 3;

            //point.y = 1;//makes the coins spawn on the ground
            return point;
        }

       
        for (int i = 0; i < enemyNo; i++)
        {
            GameObject score = Instantiate(enemy);//spawns token
            score.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
