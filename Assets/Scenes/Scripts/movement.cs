using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float doubleJumpForce = 10f;
    public float timeBeforeNextJump = 1.2f;

    private Rigidbody rb;
    public bool isGrounded = true;
    private float nextJumpTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && CanJump())
        {
            Jump();
        }
    }

    private bool CanJump()
    {
        return isGrounded && Time.time > nextJumpTime;
    }

    private void Jump()
    {
        float force = isGrounded ? jumpForce : doubleJumpForce;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        isGrounded = false;
        nextJumpTime = Time.time + timeBeforeNextJump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsOnGround(collision))
        {
            isGrounded = true;
        }
    }

    private bool IsOnGround(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                return true;
            }
        }
        return false;
    }
}