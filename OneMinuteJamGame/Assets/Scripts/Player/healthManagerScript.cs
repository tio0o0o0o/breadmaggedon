using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healthManagerScript : MonoBehaviour
{
    [SerializeField] int maxHealth;

    [HideInInspector] public static float publicMaxHealth;
    [HideInInspector] public static float currentHealth;

    public static event Action OnDamaged = delegate { };
    public static event Action OnDeath = delegate { };

    private void Awake()
    {
        publicMaxHealth = maxHealth;
        currentHealth = maxHealth;

        OnDeath += DestroyPlayer;
    }

    private void OnDestroy()
    {
        OnDeath -= DestroyPlayer;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }

        OnDamaged?.Invoke();
    }

    void PlayerDeath()
    {
        OnDeath?.Invoke();
    }

    private void Update()
    {
        //For testing
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(2f);
        }
    }

    void DestroyPlayer()
    {
        GameObject.Destroy(gameObject, 2);
    }
}
