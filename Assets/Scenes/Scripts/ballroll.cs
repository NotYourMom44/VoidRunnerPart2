using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballroll : MonoBehaviour
{
    public float speed;
    public GameObject speedActivity;
   

    public Rigidbody rb2;
    public int power;
    public AudioSource jumpSFX;

    public GameObject player;

    private Rigidbody rb;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 roll = new Vector3(x: moveHorizontal, y: 0, z: moveVertical);
        Vector3 Jump = new Vector3(x: 0, y: 0, z: moveVertical);

        rb.AddForce(roll * (speed * Time.deltaTime));
        rb.AddForce(Jump * (speed * Time.deltaTime));

        if (Input.GetKeyDown("space"))
        { jumpSFX.Play(); }
    }


    private void OnTriggerEnter(Collider other)
    {

    }

    public void stopMove()
    {
       // rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }
}