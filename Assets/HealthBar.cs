using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]private Image healthBar;

    void Start() 
    {
        healthBar = GetComponentInChildren<Image>();
    }


    public void UpdateHealthBar(int currentHealth, int startingHealth) 
    {
        healthBar.fillAmount = (float)currentHealth / startingHealth; 
    }

    
}
