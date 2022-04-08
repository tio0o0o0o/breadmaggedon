using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitstopScript : MonoBehaviour
{
    [SerializeField] public float pauseTime;

    private void Awake()
    {
        healthManagerScript.OnDamaged += CallHitStop;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        healthManagerScript.OnDamaged -= CallHitStop;
    }

    public void CallHitStop()
    {
        StartCoroutine(HitStop());
    }

    IEnumerator HitStop()
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(pauseTime);

        Time.timeScale = 1f;
    }
}
