using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Options")]
    public bool rotateTowardsPlayer = false;
    public float spawnDelay = 1;
    [Header("Turret Options - Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 5;
    public float projectileAcceleration;
    private Timer timerDelay;

    private PlayerMovement playerReference;

    private void Start()
    {
        timerDelay = new Timer(spawnDelay);
        playerReference = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (rotateTowardsPlayer)
            HandleRotation();

        if (timerDelay.CheckUntilDone())
        {
            Projectile newProjectile = Instantiate(projectilePrefab,transform.position, transform.rotation).GetComponent<Projectile>();
            newProjectile.gameObject.SetActive(true);
            newProjectile.Setup(transform.right, projectileSpeed, projectileAcceleration);
        }
    }

    private void HandleRotation()
    {
        float degrees = Vector3.SignedAngle(Vector3.right, playerReference.transform.position - transform.position, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, degrees);
    }
}
