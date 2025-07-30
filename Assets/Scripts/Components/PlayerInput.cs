using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class PlayerInput : MonoBehaviour
{
    private MovementComponent movement;

    void Start()
    {
        movement = GetComponent<MovementComponent>();
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (movement == null) return;

        movement.moveDir = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }
}
