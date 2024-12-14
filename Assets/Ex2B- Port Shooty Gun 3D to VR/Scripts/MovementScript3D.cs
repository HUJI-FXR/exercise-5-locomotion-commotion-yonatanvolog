using UnityEngine;

public class MovementScript3D : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField] private string groundTag = "Ground";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = velocity.x;
        newVelocity.z = velocity.z;

        // Only modify the y velocity if the monster is grounded
        if (isGrounded)
        {
            newVelocity.y = velocity.y;
        }

        rb.velocity = newVelocity;
    }


    // Jump
    public void Jump(float force)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}