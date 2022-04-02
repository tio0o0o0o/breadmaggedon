using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepSound : MonoBehaviour
{
    //Make footstep sounds if player is moving

    [SerializeField] AudioSource footsteps;

    private void Update()
    {
        if (PlayerMovement.moveDirection.magnitude >= 0.01)
        {
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
            }
        }
        else
        {
            if (footsteps.isPlaying)
            {
                footsteps.Stop();
            }
        }
    }
}
