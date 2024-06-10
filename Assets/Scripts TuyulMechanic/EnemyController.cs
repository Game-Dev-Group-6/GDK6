using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Referensi ke posisi pemain
    public float moveSpeed = 5f; // Kecepatan gerak musuh
    public float safeDistance = 5f; // Jarak aman dari pemain

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Hitung jarak antara musuh dan pemain
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Jika pemain terlalu dekat, musuh akan menjauh
        if (distanceToPlayer < safeDistance)
        {
            Vector2 direction = (transform.position - player.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Musuh berhenti jika sudah cukup jauh
        }
    }
}
