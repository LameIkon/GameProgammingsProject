using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaker : MonoBehaviour, ITakeDamage
{

    [SerializeField] private int healthPoints;
    private int startingHealth;

    private HealthBar healthBar;

    void Start()
    {
        startingHealth = healthPoints;
        healthBar = GetComponentInChildren<HealthBar>();
    }


    public bool TakeDamage(int damage) 
    {
        healthPoints -= damage;
        
        if (!IsAlive())  Destroy(gameObject);
        
        healthBar.UpdateHealthBar(healthPoints, startingHealth);

        return true;
    }

    public bool IsAlive() 
    {
        if (healthPoints > 0) return true;
        
        else return false;

    }



}
