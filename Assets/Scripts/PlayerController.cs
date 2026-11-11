using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Movement vector
    private Vector2 movement;

    void Start()
    {
        // Cache component references
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Lock z-rotation for 2D top-down physics
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // 1. Gather Directional Input (WASD / Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Control Walking Animation State
        bool isMoving = movement != Vector2.zero;
        if (animator != null)
        {
            animator.SetBool("IsWalking", isMoving);
        }

        // 3. Flip Sprite horizontally based on movement direction
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // 4. Instant Attack Trigger (Spacebar or Left Click / Fire1)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    void FixedUpdate()
    {
        // 5. Apply physics-based movement using normalized vector
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}