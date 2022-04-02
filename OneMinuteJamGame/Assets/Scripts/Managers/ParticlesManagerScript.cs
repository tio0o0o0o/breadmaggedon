using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManagerScript : MonoBehaviour
{
    [SerializeField] GameObject damagedParticles;
    [SerializeField] Transform playerTransform;

    void SpawnDamagedParticles()
    {
        GameObject damagedParticlesInstance = Instantiate(damagedParticles, playerTransform);
        GameObject.Destroy(damagedParticlesInstance, 0.4f);
    }

    private void Start()
    {
        healthManagerScript.OnDamaged += SpawnDamagedParticles;
    }

    private void OnDestroy()
    {
        healthManagerScript.OnDamaged -= SpawnDamagedParticles;
    }
}
