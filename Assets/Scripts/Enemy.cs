using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Animator enemyAnimator;
    private Vector2 movement;
    public int life = 1;
    public bool lookLeft; // INDICA SE O PERSONAGEM TA OLHANDO PRA ESQUERDA
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        perseguir(direction);
        if (life <= 0)
        {
            Destroy(gameObject, 0.05f);
        }
    }
    
    void perseguir(Vector3 direction)
    {
        if (player != null)
        {
            enemyAnimator.SetBool("walk", true);
            direction.Normalize();
            movement = direction;
        }
        else
        {
            enemyAnimator.SetBool("walk", false);
        }
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * (moveSpeed * Time.deltaTime)));
        if (direction.x > 0 && lookLeft)
        {
            flip();
        }
        else if (direction.x < 0 && !lookLeft)
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
        if(collision.CompareTag("Flecha"))
        {
            enemyAnimator.SetTrigger("hit");
            life -= 4;
        }
        if(collision.CompareTag("Bomb"))
        {
            enemyAnimator.SetTrigger("hit");
            life -= 5;
        }
        if(collision.CompareTag("Melee"))
        {
            enemyAnimator.SetTrigger("hit");
            life -= 7;
        }
    }
}
