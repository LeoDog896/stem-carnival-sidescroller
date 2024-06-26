using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 6.5f;
    private bool isFacingRight = true;

    private Vector2 movementInput = Vector2.zero;
    private bool jumpInput = false;

    private Transform _originalParent;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    [SerializeField] private PhysicsMaterial2D groundMaterial;
    [SerializeField] private PhysicsMaterial2D airMaterial;

    [SerializeField] private BoxCollider2D groundCollider;

    [SerializeField] private AudioSource jumpSound;
    private bool wasJumping = false;
    private int lastJumpFrame = 0;

    private void Start()
    {
        _originalParent = transform.parent;
    }

    void Update()
    {
        horizontal = movementInput.x;

        if (jumpInput && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            // jumpSound.Play();
            if (Time.frameCount - lastJumpFrame > 2)
            {
                jumpSound.Play();
            }
            wasJumping = true;
            lastJumpFrame = Time.frameCount;
        }

        if (IsGrounded())
        {
            rb.sharedMaterial = groundMaterial;
            if (wasJumping)
            {
                wasJumping = false;
            }
        }
        else
        {
            rb.sharedMaterial = airMaterial;
        }

        animator.SetBool("isUp", Mathf.Abs(rb.velocity.y) > 0.001 && rb.velocity.y > 0.001);
        animator.SetBool("isFalling", Mathf.Abs(rb.velocity.y) > 0.001 && rb.velocity.y < -0.001 && !IsGrounded());
        animator.SetBool("IsMoving", horizontal != 0);

        Flip();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValueAsButton();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        var colliders = Physics2D.OverlapBoxAll(
            groundCheck.position,
            new Vector2(groundCollider.size.x, groundCollider.size.y),
            0f,
            groundLayer
        );

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}