using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 5f;  // Jarak deteksi pemain
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool hasStumbled = false;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool stumbledAfterRock = false;  // Variable to check if enemy has stumbled after rock

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasStumbled)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer < detectionRange)
            {
                Vector2 direction = (transform.position - player.position).normalized;
                movement = direction;

                // Flip sprite based on movement direction
                if (movement.x > 0 && !isFacingRight)
                {
                    Flip();
                }
                else if (movement.x < 0 && isFacingRight)
                {
                    Flip();
                }
            }
            else
            {
                movement = Vector2.zero;  // Berhenti jika pemain di luar jangkauan
                animator.SetBool("Yutul_Lari",false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasStumbled)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            animator.SetBool("Yutul_Lari",true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stumble();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            stumbledAfterRock = true;  // Set variable to true when touching the rock
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") && stumbledAfterRock)
        {
            Stumble();
            stumbledAfterRock = false;  // Reset variable
        }
    }

    void Stumble()
    {
        hasStumbled = true;
        rb.velocity = Vector2.zero;
        animator.SetTrigger("Fall"); // Set trigger for fall animation
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
