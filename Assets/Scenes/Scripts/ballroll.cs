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

        Vector3 movement = new Vector3(
            moveHorizontal,
            0,
            1f
        );

        rb.AddForce(movement * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSFX.Play();
        }
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

    public void StartSpeedBoost(float amount, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(amount, duration));
    }

    private IEnumerator SpeedBoostRoutine(float amount, float duration)
    {
        speed += amount;
        Debug.Log("Speed boost started");

        yield return new WaitForSeconds(duration);

        speed -= amount;
        Debug.Log("Speed boost ended");
    }
}