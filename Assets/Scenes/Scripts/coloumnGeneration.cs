using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class pickUpGeneration : MonoBehaviour
{
   
    public GameObject coloumn;
    public Collider levelCollider;
    public float coloumnDestroy = 20f;
    public int objectNo = 20;
    // Start is called before the first frame update
    void Start()
    {
        SpawnColoumns();
    }

  

    void SpawnColoumns()
    {
       
        Vector3 GetRandomPointInCollider(Collider collider)//function to get the location for coin spawn
        {
            Vector3 point = new Vector3
                (
                    Random.Range(collider.bounds.min.x, collider.bounds.max.x),//This sets the random spwan to always be on the platform
                    Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                    Random.Range(collider.bounds.min.z, collider.bounds.max.z)
                );

            point.y = -2;

            //point.y = 1;//makes the coins spawn on the ground
            return point;
        }


      //token amount

        for (int i = 0; i < objectNo; i++)
        {
            GameObject score = Instantiate(coloumn);//spawns power up
            score.name = coloumn.name;
            score.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
            Destroy(score, coloumnDestroy);
        }

        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
