using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class prefabTrigger : MonoBehaviour
{
    private Transform playerTransform;
    public List<GameObject> levels = new List<GameObject>();
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    public GameObject level_4;
    public GameObject player;
    public GameObject Portal;
    public AudioSource portalWarp;

    private float spawnDistance = 99f;
    private float spawnDistance2 = 30f;
    private float spawnDistance3 = 50f;
    private float spawnDistance4 = 160f;
    private float spawnDistance5 = 70f;
    private float PlatformdestroyTime = 8f;
    private float BossLeveldestroyTime = 20f;
    private float TunneldestroyTime = 30f;
    public Vector3 spawnPosition;
    public bool GameRunning = false;
    public int platforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            GameRunning = true;
        }
    }

    void SpawnRoad()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //spawnPosition uses the players transform position, and the spawnDistance float which is the point at which the next prefab is located
        Vector3 spawnPosition = playerTransform.position + Vector3.forward * spawnDistance;

        Vector3 spawnPosition2 = playerTransform.position + Vector3.forward * spawnDistance2;

        Vector3 spawnPosition3 = playerTransform.position + Vector3.forward * spawnDistance3;

        Vector3 spawnPosition4 = playerTransform.position + Vector3.forward * spawnDistance4;

        Vector3 spawnPosition5 = playerTransform.position + Vector3.forward * spawnDistance5;

        Vector3 voidPosition = playerTransform.position + Vector3.forward * spawnDistance;

        spawnPosition.y = 0;
        spawnPosition.x = 0.5f;

        spawnPosition2.y = 0;
        spawnPosition2.x = 0.5f;

        spawnPosition3.y = 0;
        spawnPosition3.x = 0.5f;

        spawnPosition4.y = -2;
        spawnPosition4.x = 0.5f;

        spawnPosition5.y = 0;
        spawnPosition5.x = 0.5f;

        if (platforms < 10)
        {

            //The prefabs folder then populates the levels list using the LoadAll function
            levels = Resources.LoadAll<GameObject>("Prefabs/level default").ToList();

            //This adds the first level game object to tthe list
            levels.Add(level_1);
            Debug.Log("Level 1 Start");
            //A new level is generated and the level 1 prefab is instantiated in the spawnPosition Vector3
            GameObject newLevel = Instantiate(levels[0], spawnPosition, Quaternion.identity);
            GameObject newPortal = Instantiate(Portal, voidPosition, Quaternion.identity);
            Debug.Log("Level 1 instantiated");

            //this makes sure that the heiarchy displays the instatiated level shows up with it's name and not a clone 
            newLevel.name = levels[0].name;
            newPortal.name = Portal.name;

            //destroys the new platform using the destroy timer
            Destroy(newLevel, PlatformdestroyTime);
            Destroy(newPortal, PlatformdestroyTime);
        }


        if (platforms >= 10)
        {
            

            levels = Resources.LoadAll<GameObject>("Prefabs/tutorial_level").ToList();

            //This adds the first level game object to tthe list
            levels.Add(level_2);
            Debug.Log("Level 2 Added");
            //A new level is generated and the level 1 prefab is instantiated in the spawnPosition Vector3

            if (platforms < 6)
            {
                GameObject newLevel2 = Instantiate(levels[0], spawnPosition3, Quaternion.identity);
                Debug.Log("Level 2 instantiated");


                //this makes sure that the heiarchy displays the instatiated level shows up with it's name and not a clone then destroys the object
                newLevel2.name = levels[0].name;
                Destroy(newLevel2, TunneldestroyTime);
            }

            if (platforms <= 14)
            {
                GameObject newLevel2 = Instantiate(levels[0], spawnPosition2, Quaternion.identity);
                Debug.Log("Level 2 instantiated");

                //this makes sure that the heiarchy displays the instatiated level shows up with it's name and not a clone then destroys the object
                newLevel2.name = levels[0].name;
                Destroy(newLevel2, TunneldestroyTime);


            }
            //destroys the new platform using the destroy timer

        }

        
        if (platforms >= 15)
        {
        

            if (platforms < 20)
            {
                //The prefabs folder then populates the levels list using the LoadAll function
                levels = Resources.LoadAll<GameObject>("Prefabs/Boss level").ToList();

                //This adds the first level game object to tthe list
                levels.Add(level_3);
                Debug.Log("Level 3 Start");
                //A new level is generated and the level 1 prefab is instantiated in the spawnPosition Vector3
                GameObject newLevel = Instantiate(levels[0], spawnPosition4, Quaternion.identity);
                Debug.Log("Level 3 instantiated");

                //this makes sure that the heiarchy displays the instatiated level shows up with it's name and not a clone 
                newLevel.name = levels[0].name;


                //destroys the new platform using the destroy timer
                Destroy(newLevel, BossLeveldestroyTime);
            }

            
        }

        if (platforms >= 20)
        {
            

            //The prefabs folder then populates the levels list using the LoadAll function
            levels = Resources.LoadAll<GameObject>("Prefabs/tutorial_level").ToList();

            //This adds the first level game object to tthe list
            levels.Add(level_2);
            Debug.Log("Level 4 Start");
            //A new level is generated and the level 1 prefab is instantiated in the spawnPosition Vector3
            GameObject newLevel = Instantiate(levels[0], spawnPosition5, Quaternion.identity);
            Debug.Log("Level 4 instantiated");

            //this makes sure that the heiarchy displays the instatiated level shows up with it's name and not a clone 
            newLevel.name = levels[0].name;


            //destroys the new platform using the destroy timer
            Destroy(newLevel, TunneldestroyTime);


        }


    }

 


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("spawn"))
        {
            portalWarp.Play();
            if (GameRunning == true)

            {
                platforms++;
                SpawnRoad();
            }


        }

       
    }
}



