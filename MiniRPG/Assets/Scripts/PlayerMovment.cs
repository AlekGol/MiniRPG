using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movementInput;
    private Rigidbody2D rb;
    private PlayerControls controls;
    private Animator animator; // Referencja do Animatora
    private SpriteRenderer spriteRenderer; // Referencja do SpriteRenderer

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        animator.SetBool("IsMoving", movementInput != Vector2.zero);

        // Obracanie postaci
        if (movementInput.x != 0)
        {
            spriteRenderer.flipX = movementInput.x < 0; // Obrót w lewo
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
    }
}
