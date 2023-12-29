using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSchoolMovement : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private float jump = 20f;
    [SerializeField] private float fallSpeed = 20f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private LayerMask groundLayer;

    private InputsManager inputs;
    private Rigidbody2D rb;
    private Collider2D coll;

    private int movementX;
    private bool isFacingRight;
    private bool lastPressedRight;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<InputsManager>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        Flip();
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();

    }

    private void MovementInput() 
    {

        if (Input.GetKeyUp(inputs.Right()) || Input.GetKeyUp(inputs.Left()))
            movementX = 0;

        if (Input.GetKeyDown(inputs.Right()))
        {
            lastPressedRight = true;
        }

        if (Input.GetKeyDown(inputs.Left()))
        {
            lastPressedRight = false;
        }

        if (Input.GetKey(inputs.Right()) && Input.GetKey(inputs.Left()))
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

        else if (Input.GetKey(inputs.Right()))
        {
            movementX = 1;
        }

        else if (Input.GetKey(inputs.Left()))
        {
            movementX = -1;
        }

    }

    private void Jump() 
    {

        if (IsGrounded() && Input.GetKeyDown(inputs.Jump()))
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        else if (Input.GetKeyUp(inputs.Jump()))
        {
            rb.AddForce(rb.velocity.y * fallSpeed * Vector2.down);
        }
    }


    private void Flip()
    {
        if (isFacingRight && movementX < 0 || !isFacingRight && movementX > 0)
        {

            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
      
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    private void Movement() 
    {
        if (movementX == 1)
        {
            rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
            //movementX = 0;            
        }
        else if (movementX == -1)
        {
            rb.AddForce(Vector2.left * speed, ForceMode2D.Force);
            //movementX = 0;           
        }

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

}
