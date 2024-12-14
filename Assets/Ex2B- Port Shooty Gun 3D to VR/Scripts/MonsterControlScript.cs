using UnityEngine;

public class MonsterControlScript : MonoBehaviour
{
    [SerializeField] private MovementScript3D movementScript;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 120f;
    [SerializeField] private float monsterTime = 5f;
    [SerializeField] private float chasePlayerChance = 0.5f;
    [SerializeField] private float randomRotationSpeed = 50f;

    private Transform playerTransform;
    private float monsterTimer = 0f;
    [SerializeField] private bool chasePlayer = false;
    private float randomYRotation = 0f;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        monsterTimer += Time.deltaTime;
        if (monsterTimer >= monsterTime)
        {
            monsterTimer = 0f;
            float randomValue = Random.Range(0f, 1f);
            chasePlayer = randomValue < chasePlayerChance;

            if (!chasePlayer)
            {
                randomYRotation = Random.Range(-randomRotationSpeed, randomRotationSpeed);
            }
        }

        if (chasePlayer && playerTransform != null)
        {
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            Vector3 forwardVelocity = transform.forward * moveSpeed;
            movementScript.SetVelocity(forwardVelocity);
        }
        else
        {
            transform.Rotate(0f, randomYRotation * Time.deltaTime, 0f);
            Vector3 forwardVelocity = transform.forward * moveSpeed;
            movementScript.SetVelocity(forwardVelocity);
        }
    }
}
