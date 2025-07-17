using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;
    public int facingDirection = 1;
    
    // FixedUpdate is called 50x frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // condição para inverter a direção do personagem (Flip)
        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        // animação do personagem
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        // Normaliza a direção do movimento (corrige o problema de andar mais rápido na diagonal)
        Vector2 direction = new Vector2(horizontal, vertical);
        if (direction.magnitude > 1f)
            direction = direction.normalized;

        rb.linearVelocity = direction * speed;
    }

    // função para inverter a direção do personagem (Flip)
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
