using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IDamageable
{
    void Start() 
    {
        HealthPoint = MaxHealthPoints;
    }


    #region IDamageable

    public int HealthPoint { get; set; }
    [field: SerializeField] public int MaxHealthPoints { get; set; }


    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        HealthPoint -= amount;

        if (HealthPoint <= 0) 
        {
            Die();
        }

    }

    #endregion
}
