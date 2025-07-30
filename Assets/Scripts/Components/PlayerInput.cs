using System;
using UnityEngine;
using Utils;

public class PlayerInput : MonoBehaviour
{
    private MovementComponent Mov;
    private SpriteComponent Spr;

    void Start()
    {
        Mov = GetComponent<MovementComponent>();
        Spr = GetComponent<SpriteComponent>();
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

            if (Spr != null)
            {
                string dir = CustomHelper.Get8DirectionName(Mov.moveDir);
                Sprite[] newFrames = Spr.GetFrames((dir == "NONE") ? "Player_Idle" : ("Player_Move_" + dir));
                if (newFrames != null) Spr.SetFrames(newFrames);
            }
        }
    }
}
