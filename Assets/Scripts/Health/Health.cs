using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int healthPoints;
    private int startingHealth;

    private HealthBar healthBar;

    void Start()
    {
        startingHealth = healthPoints;
        healthBar = GetComponentInChildren<HealthBar>();
    }


    public void TakeDamage(int damage) 
    {
        healthPoints -= damage;
        
        if (!IsAlive())  Destroy(gameObject);
        
        healthBar.UpdateHealthBar(healthPoints, startingHealth);
        
    }

    public bool IsAlive() 
    {
        if (healthPoints > 0) return true;
        
        else return false;

    }



}
