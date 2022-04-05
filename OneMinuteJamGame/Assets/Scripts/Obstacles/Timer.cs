using UnityEngine;

/* Base Timer class I always use for timing stuff since I hate coroutines */
[System.Serializable]
public class Timer
{
    public float timeMax = 3;
    public float speed = 1;
    private float current;

    public Timer(float time)
    {
        Reset(time);
    }

    public float GetCurrentTime()
    {
        return current;
    }

    // Should be called all the time, once on every Update, in order for the timer to well, time things
    public bool CheckUntilDone(bool autoRestart = true)
    {
        if (current <= 0)
        {
            if (autoRestart)
                Reset();
            return true;
        }
        current -= Time.deltaTime * speed;
        return false;
    }

    // Resets timer (time can be changed here too)
    public void Reset(float time = 0)
    {
        if (time > 0)
            timeMax = time;
        current = timeMax;
    }
}
