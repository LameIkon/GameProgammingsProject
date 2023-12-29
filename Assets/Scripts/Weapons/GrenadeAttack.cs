using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeAttack : MonoBehaviour
{

    [SerializeField] private Grenade grenade;

    [SerializeField] private GameObject explotionCircle;

    private void Start()
    {
        if (!grenade.ExplodesOnImpact()) StartCoroutine(Fuse(grenade.GetFuse()));
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V)) 
        {
            Attack();
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (grenade.ExplodesOnImpact() && collision.gameObject)
        {

            Attack();
        }
    }

    public bool Attack() 
    {
            Debug.Log("Explotion");

        Collider2D[] damageHits = Physics2D.OverlapCircleAll(gameObject.transform.position, grenade.GetRadius());


        foreach (Collider2D objects in damageHits)
        {
            objects.GetComponent<ITakeDamage>()?.TakeDamage(grenade.DoDamage());   
        }

        Instantiate(explotionCircle, gameObject.transform.position, Quaternion.identity);
        return true;
    }


    private IEnumerator Fuse(float duration) 
    {
        yield return new WaitForSeconds(duration);
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, grenade.GetRadius());
    }
}
