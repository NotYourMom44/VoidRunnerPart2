using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircle : MonoBehaviour
{
    public GameObject power;
    public GameObject circle;
    public Transform playerTransform;
    public float destroyThePower = 4f;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boss Level Ground")) 
        {
            Vector3 playerPos = playerTransform.position;
            GameObject newPower = Instantiate(power, playerPos, Quaternion.identity);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss Level Ground"))
        {
            Vector3 playerPos = playerTransform.position;
            GameObject newCircle = Instantiate(circle, playerPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = gameObject.transform;
    }
}
