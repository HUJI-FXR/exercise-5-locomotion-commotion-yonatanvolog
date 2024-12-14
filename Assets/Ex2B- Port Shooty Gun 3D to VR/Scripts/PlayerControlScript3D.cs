using UnityEngine;

public class PlayerControlScript3D : MonoBehaviour
{
    [SerializeField] private MovementScript3D movementScript;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 1f;

    private void Update()
    {
        // Forward and backward movement
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) // Move forward
        {
            direction += Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S)) // Move backward
        {
            direction += Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.back;
        }

        // Left and right movement
        if (Input.GetKey(KeyCode.A)) // Move left
        {
            direction += Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            direction += Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.right;
        }

        direction = direction.normalized * moveSpeed;
        movementScript.SetVelocity(direction);

        // Jump
        if (Input.GetKey(KeyCode.Space) && movementScript.IsGrounded())
        {
            movementScript.Jump(jumpForce);
        }
    }
}