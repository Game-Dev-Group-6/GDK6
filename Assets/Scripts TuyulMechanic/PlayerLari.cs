using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLari : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerak horizontal
    public float jumpForce = 10f; // Kekuatan lompatan
    public Transform groundCheck; // Objek untuk memeriksa apakah pemain menyentuh tanah
    public LayerMask groundLayer; // Layer yang dianggap sebagai tanah

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mendapatkan input horizontal
        float moveInput = Input.GetAxis("Horizontal");

        // Menggerakkan pemain secara horizontal
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Memeriksa apakah pemain menyentuh tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jika pemain menyentuh tanah dan tombol lompat ditekan, maka pemain melompat
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
