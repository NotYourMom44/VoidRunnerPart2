using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class enemyfollow : MonoBehaviour
{
    public Transform targetObj;
   public Transform enemyTransform;
    public float playerKillInterval = 7f;
    public float minDist = 2f;
    public float pos;
    public float fallheight;
    public GameObject enemy;
    public Rigidbody rb;
    public float speed;
    public float time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("kill enemy")) 
        {
            Destroy(enemy);
            Debug.Log("Enemy Hit Collider, bro's dead");
        }

      /*  if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject, playerKillInterval);
            Debug.Log("Enemy Hit You, you dead bro");
        } */
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetObj);
        float distance = Vector3.Distance(transform.position, targetObj.position);
        if (distance > minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }


            pos = enemy.transform.position.y;

        if (pos <= -10f)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Despawned");
        }

    }
}
