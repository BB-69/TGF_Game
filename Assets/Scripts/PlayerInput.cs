using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Components
    MovementComponent MOV;

    void Start()
    {
        MOV = GetComponent<MovementComponent>();
    }

    void FixedUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (MOV == null) return;

        MOV.moveDir = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }
}
