using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



//[RequireComponent(typeof(Weapon))]
public class Attack : MonoBehaviour
{

    
    [SerializeField] private Weapon weapon;
    
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject) 
        {
            other.GetComponent<Health>().TakeDamage(weapon.DoDamage());
        }
    
    }
}
