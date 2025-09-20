using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4.5f;

    Rigidbody2D rb;
    Vector2 moveInput;
    PlayerInputActions playerInputActions;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new();
    }

    void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Move.performed += OnMove;
        playerInputActions.Player.Move.canceled += OnMove;   
    }

    void OnDisable()
    {
        playerInputActions.Player.Move.performed -= OnMove;
        playerInputActions.Player.Move.canceled -= OnMove;
        playerInputActions.Disable();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;   
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
