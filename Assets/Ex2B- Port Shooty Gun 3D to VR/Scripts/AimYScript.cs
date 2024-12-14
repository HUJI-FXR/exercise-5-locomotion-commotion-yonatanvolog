using UnityEngine;

public class AimYScript : MonoBehaviour
{
    public float sensitivity = 1f;
    private float yRotation = 0f;

    private void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}