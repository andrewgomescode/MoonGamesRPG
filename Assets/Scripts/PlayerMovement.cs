using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    
    // FixedUpdate is called 50x frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Normaliza a direção do movimento (corrige o problema de andar mais rápido na diagonal)
        Vector2 direction = new Vector2(horizontal, vertical);
        if (direction.magnitude > 1f)
            direction = direction.normalized;

        rb.linearVelocity = direction * speed;
    }
}
