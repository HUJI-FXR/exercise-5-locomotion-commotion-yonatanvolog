using UnityEngine;

public class AimXScript : MonoBehaviour
{
    public float sensitivity = 1f;
    private float xRotation = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        xRotation += mouseX;

        transform.rotation = Quaternion.Euler(0f, xRotation, 0f);
    }
}