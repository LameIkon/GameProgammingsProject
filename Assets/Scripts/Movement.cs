using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private float movementX;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jump = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float fallSpeed = 15f;

    private float startingSpeed;
    private bool isFacingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        startingSpeed = GetMaxSpeed();
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
    }

    void OnJump(InputValue jumpValue)
    {

        if (IsGrounded() && jumpValue.isPressed)
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        else if (!jumpValue.isPressed)
        {
            rb.AddForce(rb.velocity.y * fallSpeed * Vector2.down);
        }
    }


    IEnumerator OnRun(InputValue runValue)
    {
        if (runValue.isPressed)
        {
            for (float i = 0; i < 1.1f; i += 0.1f)
            {
                SetMaxSpeed(Mathf.Lerp(startingSpeed, runSpeed, i));
                yield return new WaitForSeconds(.1f);
            }
        }
        else if (!runValue.isPressed)
        {
            for (float i = 0; i < 1.1f; i += 0.1f)
            {
                SetMaxSpeed(Mathf.Lerp(runSpeed, startingSpeed, i));
                yield return new WaitForSeconds(.2f);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 movement = new Vector2(movementX, 0);

        //rb.velocity = new Vector2(movementX * speed, rb.velocity.y);

        rb.AddForce(movement * speed);


        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        Flip();

    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }


    public float GetMaxSpeed() { return maxSpeed; }

    private void SetMaxSpeed(float newSpeed)
    { maxSpeed = newSpeed; }


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

}
