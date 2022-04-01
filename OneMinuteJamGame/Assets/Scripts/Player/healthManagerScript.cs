using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class healthManagerScript : MonoBehaviour
{
    [SerializeField] int maxHealth;

    [HideInInspector] public static int currentHealth;

    public static event Action OnDamaged = delegate { };
    public static event Action OnDeath = delegate { };

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
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
}
