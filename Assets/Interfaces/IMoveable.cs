using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Rigidbody2D Rb { get; set; }

    Collider2D Coll { get; set; }

    void Movement();
    void Jump();
    bool IsGrounded();

}
