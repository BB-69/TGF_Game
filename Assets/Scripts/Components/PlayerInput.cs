using System;
using UnityEngine;
using Utils;

[RequireComponent(typeof(MovementComponent))]
// typeof(AnimationComponent), typeof(HeldItemAnimation) in child
public class PlayerInput : MonoBehaviour
{
    private MovementComponent Mov;
    private AnimationComponent Ani;
    private HeldItemAnimation heldAni;

    void Start()
    {
        Mov = GetComponent<MovementComponent>();
        Ani = GetComponentInChildren<AnimationComponent>();
        heldAni = GetComponentInChildren<HeldItemAnimation>();
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
            
            string dir = CustomHelper.Get8DirectionName(Mov.moveDir);

            if (Ani != null)
            {
                Ani.SetDirection(dir);
            }

            if (heldAni != null)
            {
                Vector3 p = heldAni.transform.localPosition;
                heldAni.transform.localPosition = new Vector3(p.x, p.y, (dir != "UP") ? -1 : 1);
            }
        }
    }
}
