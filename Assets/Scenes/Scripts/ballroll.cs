using System.Collections;
using UnityEngine;

public class Ballroll : MonoBehaviour
{
    public float speed = 12f;
    public float sideSpeed = 8f;

    public AudioSource jumpSFX;

    private Rigidbody rb;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMove) return;

        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 targetVelocity = new Vector3(
            moveHorizontal * sideSpeed,
            rb.velocity.y,
            speed
        );

        rb.velocity = targetVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpSFX != null)
            {
                jumpSFX.Play();
            }
        }
    }

    public void stopMove()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void StartSpeedBoost(float amount, float duration)
    {
        StartCoroutine(SpeedBoostRoutine(amount, duration));
    }

    private IEnumerator SpeedBoostRoutine(float amount, float duration)
    {
        speed += amount;
        Debug.Log("Speed boost started. Current speed: " + speed);

        yield return new WaitForSeconds(duration);

        speed -= amount;
        Debug.Log("Speed boost ended. Current speed: " + speed);
    }
}