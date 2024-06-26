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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasStumbled)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
            Stumble();
        }
    }

    void Stumble()
    {
        hasStumbled = true;
        rb.velocity = Vector2.zero;
        Invoke("ResetStumble", 2f);
    }

    void ResetStumble()
    {
        hasStumbled = false;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
