using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CharacterComponent))]
public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D rb;
    private CharacterComponent character;
    [HideInInspector] public Vector2 moveDir = Vector2.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<CharacterComponent>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move() { rb.linearVelocity = moveDir * character.SPD; }
}
