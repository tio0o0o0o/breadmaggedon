using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Turret Options")]
    public bool rotateTowardsPlayer = false;
    public float spawnDelay = 1;
    [Header("Turret Options - Animation")]
    public Transform turretBodyA;
    public float animationFactor = 0.15f;
    [Header("Turret Options - Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 5;
    public float projectileAcceleration;
    private Timer timerDelay;
    private float _time;

    private PlayerMovement playerReference;

    private void Start()
    {
        timerDelay = new Timer(spawnDelay);
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
            newProjectile.Setup(transform.right, projectileSpeed, projectileAcceleration);
            turretBodyA.LeanMoveLocalX(-animationFactor, _time).setEaseLinear().setLoopPingPong(1);
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
        Gizmos.DrawLine(transform.position, transform.right);
    }
}
