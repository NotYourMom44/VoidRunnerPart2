using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{
    public GameObject tutorial_level;
    public List<GameObject> levels = new List<GameObject>();

    public GameObject level_1;
    public GameObject Portal;
    public GameObject startCircle;
    public GameObject player;
    private Transform playerTransform;
    private float StartdestroyTime = 15f;
    private float circledestroyTime = 20f;
    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
        void spawn()
        {
            if (levels.Count == 0)
            {
                if (tutorial_level.gameObject.CompareTag("Tutorial Level"))
                {

                    //Instantiate(tutorial_level, new Vector3(4, 6, 303), Quaternion.identity);
                    levels.Add(tutorial_level);
                    Instantiate(tutorial_level, new Vector3((float)0.5876492, (float)7.237311, (float)-31.1104), Quaternion.identity);

                    Debug.Log("Tutorial Prefab Spawned");
                }

            }
            else
            {
                Debug.Log("Levels List populated");

            }

        }
        spawn();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 circlePosition = playerTransform.position;
        circlePosition.y = 0;
        Vector3 startPosition = playerTransform.position + Vector3.down;
        Vector3 voidPosition = playerTransform.position + Vector3.forward + Vector3.forward ;
        GameObject newLevel = Instantiate(level_1, startPosition, Quaternion.identity);
        GameObject newPortal = Instantiate(Portal, voidPosition, Quaternion.identity);
        GameObject newCircle = Instantiate(startCircle, circlePosition, Quaternion.identity);

        newLevel.name = level_1.name;
        Debug.Log("Starting Platform Spawned");
        Destroy(newLevel, StartdestroyTime);
        Destroy(newPortal, StartdestroyTime);
        Destroy(newCircle, circledestroyTime);

    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
