using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepSound : MonoBehaviour
{
    //Make footstep sounds if player is moving

    [SerializeField] AudioSource footsteps;
    [SerializeField] float delay;

    private bool delayFinished = true;

    private void Update()
    {
        if (PlayerMovement.moveDirection.magnitude >= 0.01 && delayFinished)
        {
            footsteps.pitch = Random.Range(0.5f, 1.5f);
            footsteps.Play();
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        delayFinished = false;
        yield return new WaitForSecondsRealtime(delay);
        delayFinished = true;
    }
}
