using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private float moveLimiter = 0.7f;

    
    public float speed;
    
    public bool lookLeft; // INDICA SE O PERSONAGEM TA OLHANDO PRA ESQUERDA
    private float h, v; // VARIÁVEIS MOVIMENTO HORIZONTAL E VERTICAL


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // ASSOCIA O COMPONENTE A VARIÁVEL
    }

    void FixedUpdate()
    {
        if (h != 0 && v != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            h *= moveLimiter;
            v *= moveLimiter;
        } 
        playerRb.velocity = new Vector2(h * speed, v * speed);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (h > 0 && lookLeft)
        {
            flip();
        }
        else if (h < 0 && !lookLeft)
        {
            flip();
        }
    }
    
    void flip()
    {
        lookLeft = !lookLeft; //inverte valor da variável boleana
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
