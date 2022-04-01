using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManagerScript : MonoBehaviour
{
    [SerializeField] int maxHealth;

    [HideInInspector] public static int currentHealth;

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
    }

    void PlayerDeath()
    {
        
    }
}
