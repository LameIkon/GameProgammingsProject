using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



//[RequireComponent(typeof(Weapon))]
public class WeaponAttack : MonoBehaviour
{

    
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius; 
    
    private BoxCollider2D boxCollider;




    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    private IEnumerator OnAttack(InputValue attackValue)
    {
        Debug.Log("Attack");
        boxCollider.enabled = true;
        yield return new WaitForFixedUpdate();
        boxCollider.enabled = false;

    }


    public bool Attack() 
    {
        Collider2D[] Hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach (Collider2D obj in Hits) 
        {
            GetComponent<ITakeDamage>()?.TakeDamage(weapon.DoDamage());
        }

        return true; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject) 
        {
            other.GetComponent<HealthMaker>().TakeDamage(weapon.DoDamage());
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
