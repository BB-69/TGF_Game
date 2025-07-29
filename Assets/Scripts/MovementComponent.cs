using System;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    // Components
    Rigidbody2D rb;
    void GetComponents() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    [NonSerialized] public Vector2 moveDir = Vector2.zero;
    public float moveSpd = 10f;

    void Start()
    {
        GetComponents();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move() { rb.linearVelocity = moveDir * moveSpd; }
}
