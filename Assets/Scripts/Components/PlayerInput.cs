using System;
using UnityEngine;
using Utils;

[RequireComponent(typeof(MovementComponent))] //typeof(AnimationComponent) in child
public class PlayerInput : MonoBehaviour
{
    private MovementComponent Mov;
    private AnimationComponent Ani;

    void Start()
    {
        Mov = GetComponent<MovementComponent>();
        Ani = GetComponentInChildren<AnimationComponent>();
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Mov != null)
        {
            Mov.moveDir = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            ).normalized;

            if (Ani != null)
            {
                string dir = CustomHelper.Get8DirectionName(Mov.moveDir);
                Ani.SetDirection(dir);
            }
        }
    }
}
