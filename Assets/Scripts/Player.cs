using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private float moveLimiter = 0.7f;
    private Transform cameraTransform;

    public float speed;

    private Vector2 lookDirection;
    public bool lookLeft; // INDICA SE O PERSONAGEM TA OLHANDO PRA ESQUERDA
    private float h, v; // VARIÁVEIS MOVIMENTO HORIZONTAL E VERTICAL


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // ASSOCIA O COMPONENTE A VARIÁVEL
        cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        
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
        cameraTransform.transform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.localPosition.z);
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Move();
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (lookDirection.x > 0 && lookLeft)
        {
            flip();
        }
        else if (lookDirection.x < 0 && !lookLeft)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lacaio"))
        {
            GameController.instance.UpdateVida(7);
        }
        if (collision.CompareTag("Boss"))
        {
            GameController.instance.UpdateVida(14);
        }
        if (collision.CompareTag("Bomb"))
        {
            GameController.instance.UpdateVida(2);
        }
    }
}
