using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{

    private InputsManager inputs;

    void Start()
    {
        inputs = GetComponent<InputsManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(inputs.Attack()))
        {
            Attack();
        }
    }


    #region IAttack

    [Header("Attack Variables")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (Collider2D hit in hits) 
        {
            hit.GetComponent<IDamageable>()?.TakeDamage(1);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    #endregion
}
