using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public float speed;
    public float time;
    public float VisibilityTime = 2f;
    public AudioSource pickUp;
    public AudioSource pickDown;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Speed"))
        {
            pickUp.Play();

            if (Time.time > 2f)
            {
                speed = speed * time;
                Debug.Log("Speed Increased");
                Destroy(other.gameObject);
            }

        }

       /* if (other.CompareTag("Slow"))
        {
            pickDown.Play();

            if (Time.time > 2f)
            {
                speed = speed * time;
                Debug.Log("Speed Decreased");
                Destroy(other.gameObject);
            }

        } */

    }
     
}
