using UnityEngine;
using UnityEngine.Events;

public class ExplosiveMine : Obstacle
{
    private Timer timer;
    public float time = 3;
    public float explosionRange = 3;
    public UnityEvent OnExplosion;

    private void Start()
    {
        timer = new Timer(time);
        OnCollision.AddListener(Explode);
    }

    private void Update()
    {
        if (timer.CheckUntilDone())
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        for(int i=0; i<colliders.Length; i++)
        {
            healthManagerScript healthManager = colliders[i].GetComponent<healthManagerScript>();
            if (healthManager != null)
            {
                DealDamage(healthManager);
                break;
            }
        }
        OnExplosion.Invoke();
        _SelfDestroy();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
