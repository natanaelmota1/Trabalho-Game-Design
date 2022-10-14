using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoFaceMouse : MonoBehaviour
{

    [SerializeField] private Transform barrelTip;
    [SerializeField] private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject fireBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
        Destroy(fireBullet, 1f);
    }
}
