using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] Image healthFill;

    void UpdateHealthUI()
    {
        float currectHealthPercentage = healthManagerScript.currentHealth / healthManagerScript.publicMaxHealth;
        healthFill.fillAmount = currectHealthPercentage;
    }

    private void Awake()
    {
        healthManagerScript.OnDamaged -= UpdateHealthUI;
        healthManagerScript.OnDamaged += UpdateHealthUI;
    }
}
