using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    private float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int life = 1;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        perseguir(direction);
        if (life <= 0)
        {
            Destroy(gameObject, 0.01f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Laser"))
        {
            life -= 1;
        }
    }
    void perseguir(Vector3 direction)
    {
        if (player != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90f;
            direction.Normalize();
            movement = direction;
        }
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * (moveSpeed * Time.deltaTime)));
    }
}
