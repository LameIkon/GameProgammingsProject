using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int healthPoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive())  Destroy(gameObject); 

    }


    public void TakeDamage(int damage) 
    {
        healthPoints -= damage;
    }

    public bool IsAlive() 
    {
        if (healthPoints > 0) return true;
        
        else return false;

    }



}
