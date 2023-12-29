using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAttack, IControlable, IMoveable
{

    // All Have to be assigned in the Inspector
    [field: SerializeField, Header("Assigners")] public Rigidbody2D Rb { get; set; } // IMoveable
    [field: SerializeField] public Collider2D Coll { get; set; } //IMoveable
    [field: SerializeField] public InputsManager Inputs { get; set; } // IControlable

    [SerializeField] private Transform attackPoint; // IAttack


    #region IMoveable

    [Space(10f), Header("Moveable Variables")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpPower;
    [SerializeField] private int maxSpeed;
    [SerializeField] private int fallSpeed; 
    [SerializeField] private LayerMask groundLayer; 
     

    public void Jump() 
    {
        if (IsGrounded() && Input.GetKeyDown(Inputs.Jump()))
            Rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        else if (Input.GetKeyUp(Inputs.Jump()))
        {
            Rb.AddForce(Rb.velocity.y * fallSpeed * Vector2.down);
        }
    }
    public void Movement() 
    {
        if (movementX == 1)
        {
            Rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            //movementX = 0;            
        }
        else if (movementX == -1)
        {
            Rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            //movementX = 0;           
        }

        if (Rb.velocity.x > maxSpeed)
        {
            Rb.velocity = new Vector2(maxSpeed, Rb.velocity.y);
        }

        if (Rb.velocity.x < -maxSpeed)
        {
            Rb.velocity = new Vector2(-maxSpeed, Rb.velocity.y);
        }
    }

    public bool IsGrounded() 
    {
        return Physics2D.BoxCast(Coll.bounds.center, Coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    #endregion IMoveable





    #region IAttack

    [Space(10f), Header("Attack Variables")]
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

    #endregion IAttack





    #region IControlable 

    // [Space(10f), Header("Controlable")] 

    int movementX;
    bool lastPressedRight;


    public void KeyInputs()
    {

        if (Input.GetKeyDown(Inputs.Attack())) Attack();

        if (Input.GetKeyUp(Inputs.Right()) || Input.GetKeyUp(Inputs.Left()))
            movementX = 0;

        if (Input.GetKeyDown(Inputs.Right()))
        {
            lastPressedRight = true;
        }

        if (Input.GetKeyDown(Inputs.Left()))
        {
            lastPressedRight = false;
        }

        if (Input.GetKey(Inputs.Right()) && Input.GetKey(Inputs.Left()))
        {

            if (lastPressedRight)
            {
                movementX = 1;
            }

            else
            {
                movementX = -1;
            }
        }

        else if (Input.GetKey(Inputs.Right()))
        {
            movementX = 1;
        }

        else if (Input.GetKey(Inputs.Left()))
        {
            movementX = -1;
        }



    }

    #endregion IControlable 
}
