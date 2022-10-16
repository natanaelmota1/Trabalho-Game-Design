using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    [SerializeField] private Transform position;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") != true)
        {
            sr.enabled = false;
            rb.velocity = new Vector2(0f, 0f);
            explosion.SetActive(true);
            Destroy(explosion, 0.5f);
            Destroy(gameObject, 0.5f);
        }
    }
}
