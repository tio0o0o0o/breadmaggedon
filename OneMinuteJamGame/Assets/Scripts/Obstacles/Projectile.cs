using UnityEngine;

// Basic projectile: in order to use it, one should instantiate it and call the setup method, providing a direction, speed and acceleration
public class Projectile : Obstacle
{
    private Vector3 direction = Vector3.zero;
    private float speed = 0;
    private float acceleration = 0;
    private float totalTime = 0;
    private Timer destroyTimer;

    private void Update()
    {
        if (direction == Vector3.zero) return;

        if (destroyTimer.CheckUntilDone(false))
        {
            Destroy(gameObject);
        }

        totalTime += Time.deltaTime;
        float acc = (acceleration == 0) ? 1 : totalTime * acceleration;
        transform.position += direction * speed * Time.deltaTime * acc;
    }

    public void Setup(Vector3 direction, float speed, float acceleration = 0)
    {
        this.direction = direction;
        float degrees = Vector3.SignedAngle(Vector3.right, direction, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, degrees);
        this.speed = speed;
        this.acceleration = acceleration;
        destroyTimer = new Timer(6);
    }
}
