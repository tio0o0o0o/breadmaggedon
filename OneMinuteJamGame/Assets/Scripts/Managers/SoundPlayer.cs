using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip damagedSound;

    void PlayDamagedSound()
    {
        audioSource.PlayOneShot(damagedSound);
    }

    private void Awake()
    {
        healthManagerScript.OnDamaged -= PlayDamagedSound;
        healthManagerScript.OnDamaged += PlayDamagedSound;
    }
}
