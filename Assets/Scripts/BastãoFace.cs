using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastãoFace : MonoBehaviour
{

    [SerializeField] private Transform barrelTip;
    [SerializeField] private GameObject player;

    private Rigidbody2D rb;

    private Vector2 lookDirection;
    private float lookAngle, addedRot, posOrNeg;
    public float swingtick, swingtimer, swingspeed, cooldown, cooldownTick;
    public bool lookLeft, attacking, activateOnce;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        if (lookDirection.x > 0)
        {
            addedRot = -50f;
            lookLeft = false;
        }
        else if (lookDirection.x < 0)
        {
            addedRot = -130f;
            lookLeft = true;
        }

        if(!attacking)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + addedRot);
        }
        else
        {
            if(!activateOnce)
            {
                if(lookLeft)
                {
                    posOrNeg = +1;
                }
                else if(!lookLeft)
                {
                    posOrNeg = -1;
                }
                activateOnce = true;
            }

            swingtick += Time.deltaTime;
            rb.rotation += swingspeed * posOrNeg;
            if(swingtick >= swingtimer)
            {
                attacking = false;
                swingtick = 0;
                activateOnce = false;
                cooldownTick = 0f;
            }
        }
        cooldownTick += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if(cooldownTick >= cooldown)
            {
                attacking = true;
            }
        }
        
    }

    private void Attack()
    {
        
    }

}
