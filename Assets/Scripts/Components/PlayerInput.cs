using System;
using UnityEngine;
using Utils;

[RequireComponent(typeof(MovementComponent), typeof(WeaponComponent))]
// typeof(AnimationComponent), typeof(LayerComponent) in child
public class PlayerInput : MonoBehaviour
{
    private Camera cam;
    private MovementComponent Mov;
    private WeaponComponent Wep;
    private AnimationComponent Ani;
    private LayerComponent Lay;

    void Start()
    {
        cam = Camera.main;
        Mov = GetComponent<MovementComponent>();
        Wep = GetComponent<WeaponComponent>();
        Ani = GetComponentInChildren<AnimationComponent>();
        Lay = GetComponentInChildren<LayerComponent>();
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

            if (Lay != null)
            {
                Lay.localPadding = (dir != "UP") ? 5 : -5;
                Lay.intervalPadding = (dir != "UP") ? 1 : -1;
            }
        }

        if (Wep != null)
        {
            if (Input.GetMouseButton(0)) Wep.UseWeapon();
        }

        if (cam != null && CameraFollowPlayer.Instance != null)
        {
            CameraFollowPlayer.Instance.SetPan(Input.GetMouseButton(1));
        }
    }
}
