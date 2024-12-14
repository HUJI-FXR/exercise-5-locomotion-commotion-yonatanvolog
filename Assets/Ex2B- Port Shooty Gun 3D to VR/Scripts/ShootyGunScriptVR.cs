using UnityEngine;
using UnityEngine.InputSystem;

public class ShootyGunScriptVR : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float bulletLifetime = 5f;
    [SerializeField] private InputActionProperty triggerAction;

    private void OnEnable()
    {
        // Enable the trigger action
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        // Disable the trigger action
        triggerAction.action.Disable();
    }

    private void Update()
    {
        // Check if the trigger action was performed
        if (triggerAction.action.WasPerformedThisFrame())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetActive(true);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }
}