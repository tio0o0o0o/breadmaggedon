using UnityEngine;
using UnityEngine.Events;

public class ExplosiveMine : Obstacle
{
    [Header("Explosive Mine Options")]
    public float time = 3;
    public float explosionRange = 3;
    public UnityEvent OnExplosion;
    [Header("Explosive Mine - Particles")]
    public GameObject particlesPrefab;
    public float particlesTime = 5;

    private UICounter uiCounter = null;
    private Timer timer;

    private void Start()
    {
        timer = new Timer(time);
        OnCollision.AddListener(Explode);
        uiCounter = GetComponent<UICounter>();
    }

    private void Update()
    {
        if (timer.CheckUntilDone())
        {
            Explode();
        }
        if (uiCounter != null)
            uiCounter.ReDrawText(Mathf.FloorToInt(timer.GetCurrentTime()+1).ToString());
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        for (int i=0; i<colliders.Length; i++)
        {
            healthManagerScript healthManager = colliders[i].GetComponent<healthManagerScript>();
            if (healthManager != null)
            {
                DealDamage(healthManager);
                break;
            }
        }
        OnExplosion.Invoke();
        PlayExplosionParticles();
        _SelfDestroy();
    }

    private void PlayExplosionParticles()
    {
        if (particlesPrefab == null) return;
        ParticlesController.PlayParticles(particlesPrefab, particlesTime, transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
