using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlatformerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator knightAnimator;

    [SerializeField] private SpriteRenderer knightSpriteRenderer;

    [SerializeField] private bool freezeAnimation = false;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Set to Dynamic with gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        knightAnimator = gameObject.GetComponent<Animator>();
        knightSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveInput > 0 || moveInput < 0)
        {
            knightAnimator.SetBool("isWalking", true);
        }
        else knightAnimator.SetBool("isWalking", false);

        if (isGrounded != true)
        {
            knightAnimator.SetBool("isWalking", false);
        }

        if (moveInput < 0)
        {
            knightSpriteRenderer.flipX = true;
        }
        else knightSpriteRenderer.flipX = false;

        if (!isGrounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 15f;

        }

        if (isGrounded == true)
        {
            moveSpeed = 7f;
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // Visualise ground check in editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

