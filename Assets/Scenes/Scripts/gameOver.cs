using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    public float pos;
    public float fallheight;
    public GameObject player;
    public float deathDelay = 10f;
    public static Transform playerTransform;
    public Material invisible;

    public Ballroll br;
    
  
   
    // Start is called before the first frame update
    void Start()
    {
        br = GetComponent<Ballroll>();
    }

    void GameOver()
    {
         Debug.Log("You died");
           
            SceneManager.LoadSceneAsync(2);
     


    }

    public void OnCollisionEnter (Collision other)
    {

        if (other.gameObject.CompareTag("Death"))
        {
            
            br.stopMove();
            
            Debug.Log("You hit an obstacle died");
            ChangeMaterial();
            GameOver();
            

            


            //SceneManager.LoadSceneAsync(3);


        }

       /* if (other.gameObject.CompareTag("Boss Enemies"))
        {
            Debug.Log("The enemy got you, you're dead");

            Destroy(gameObject);
           
            SceneManager.LoadSceneAsync(3);
            


        } */
    }


    

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position.y;

        if (pos <= -10f)
        {
            GameOver();
            br.stopMove();

            Debug.Log("You hit an obstacle died");
            ChangeMaterial();

            Debug.Log("You fell too far");
        }
    }

    public void ChangeMaterial()
    {
        if (invisible != null)
        {
            // Get the Renderer component of the GameObject
            Renderer renderer = GetComponent<Renderer>();

            // Check if the Renderer component exists
            if (renderer != null)
            {
                // Change the material of the GameObject to the new material
                renderer.material = invisible;
            }
            else
            {
                Debug.LogWarning("Renderer component not found on the GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("New material is not assigned.");
        }
    }

}
