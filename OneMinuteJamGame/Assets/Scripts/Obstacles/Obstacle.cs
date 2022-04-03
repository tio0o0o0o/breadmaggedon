using UnityEngine;
using UnityEngine.Events;

/* Base Obstacle class - damages on contact */
public class Obstacle : MonoBehaviour
{
    [Header("Basic Obstacle options")]
    public float damage = 1;
    public UnityEvent OnCollision;
    protected Timer delayTimer = new Timer(0.25f);

    private bool canDamage = true;

    private void Update()
    {
        if (delayTimer.CheckUntilDone(false))
            canDamage = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!canDamage || damage == 0) return;

        healthManagerScript healthManager = collision.transform.GetComponent<healthManagerScript>();
        if (healthManager != null)
        {
            DealDamage(healthManager);
            OnCollision.Invoke();
        }
    }

    public void DealDamage(healthManagerScript healthManagerScript)
    {
        healthManagerScript.TakeDamage(damage);

        delayTimer.Reset();
        canDamage = false;
    }
}
