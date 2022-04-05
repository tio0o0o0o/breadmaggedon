using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Options")]
    public bool rotateTowardsPlayer = false;
    public float spawnDelay = 1;
    [Header("Turret Options - Animation")]
    public Transform turretBodyA;
    public float animationFactor = 0.15f;
    public GameObject particlesPrefab;
    [Header("Turret Options - Projectile")]
    public float damage = 1;
    public GameObject projectilePrefab;
    public float projectileSpeed = 5;
    public float projectileAcceleration;
    public float startingTime = -1;
    private Timer timerDelay;
    private float _time;

    private PlayerMovement playerReference;

    private void Start()
    {
        timerDelay = new Timer(spawnDelay);
        timerDelay.SetCurrentTime((startingTime == -1) ?spawnDelay:startingTime);
        _time = (spawnDelay <= 0.5f) ? spawnDelay/3 : 0.25f;
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
            newProjectile.Setup(transform.right, projectileSpeed, damage, projectileAcceleration);

            turretBodyA.LeanMoveLocalX(-animationFactor, _time).setEaseLinear().setLoopPingPong(1);

            if (particlesPrefab != null)
                ParticlesController.PlayParticles(particlesPrefab, 3, turretBodyA.position + turretBodyA.right * 0.25f);
        }
    }

    private void HandleRotation()
    {
        float degrees = Vector3.SignedAngle(Vector3.right, playerReference.transform.position - transform.position, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, degrees);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.right*2);
    }
}
