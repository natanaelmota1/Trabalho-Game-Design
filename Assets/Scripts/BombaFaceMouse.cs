using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BombaFaceMouse : MonoBehaviour
{
    [SerializeField] private Transform barrelTip;
    [SerializeField] private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;
    private bool activated;
    private SpriteRenderer bombaSprite;

    public float tick, cooldown;
    

    void Start()
    {
        bombaSprite = gameObject.GetComponent<SpriteRenderer>();
        activated = false;
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);
        tick += Time.deltaTime;
        if (tick >= cooldown)
        {
            activated = true;
            if (Input.GetMouseButtonDown(0))
            {
                FireBullet();
                tick = 0f;
            }
        }
        bombaSprite.enabled = activated;
    }

    private void FireBullet()
    {
        GameObject fireBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
        Destroy(fireBullet, 1f);
        activated = false;
    }
}
