using System.Collections.Generic;
using UnityEngine;

// Particles Manager class that stores everything related to generic particles handled by gameobjects
public class ParticlesController : MonoBehaviour
{
    public static ParticlesController instance;

    private List<ParticleItem> particles = new List<ParticleItem>();
    private List<ParticleItem> particlesToRemove = new List<ParticleItem>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        CheckActiveParticles();
        CleanParticles();
    }

    // Checks on current particle systems still alive given their set time
    private void CheckActiveParticles()
    {
        foreach (var particlesItem in particles)
        {
            if (particlesItem.timer.CheckUntilDone())
                particlesToRemove.Add(particlesItem);
        }
    }
    // Used internally to clean the particles main list
    private void CleanParticles()
    {
        foreach (var particlesItem in particlesToRemove)
        {
            particles.Remove(particlesItem);
            Destroy(particlesItem.instantiatedObject);
        }
        particlesToRemove.Clear();
    }

    // Allows one to instantiate a particles system whenever and wherever one wants
    public static void PlayParticles(GameObject prefab, float time, Vector3 position, Transform parentTransform = null)
    {
        if (instance == null) throw new System.Exception("No particles Controller detected in scene.");

        GameObject instantiated = Instantiate(prefab, position,Quaternion.identity);
        if (parentTransform != null) instantiated.transform.SetParent(parentTransform);

        ParticleItem newParticlesItem = new ParticleItem() {
            timer = new Timer(time),
            instantiatedObject = instantiated
        };
        instance.particles.Add(newParticlesItem);
    }

    // Local class used to store the timer and gameobject of each particle system instantiated
    private class ParticleItem
    {
        public Timer timer;
        public GameObject instantiatedObject;
    }
}
