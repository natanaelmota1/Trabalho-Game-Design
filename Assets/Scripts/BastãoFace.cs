using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BastãoFace : MonoBehaviour
{

    [SerializeField] private Transform bastao;
    [SerializeField] private Collider2D bastaoCol;
    [SerializeField] private GameObject player;
    

    private Rigidbody2D rb;

    private Vector2 lookDirection;
    private float lookAngle, addedRot, posOrNeg;
    public float swingtick, swingtimer, swingspeed, cooldown, cooldownTick, xPos;
    public bool lookLeft, attacking, activateOnce;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bastao.transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        bastao.position = new Vector3(player.transform.position.x + xPos, player.transform.position.y - 0.45f, player.transform.position.z);

        if (lookDirection.x > 0 && lookLeft)
        {
            addedRot = -50f;
            xPos = -0.25f;
            lookLeft = !lookLeft; 
        }
        else if (lookDirection.x < 0 && !lookLeft)
        {
            addedRot = -130f;
            xPos = 0.25f;
            lookLeft = !lookLeft;
        }

        if(!attacking)
        {
            bastao.rotation = Quaternion.Euler(0f, 0f, lookAngle + addedRot);
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
                bastaoCol.enabled = false;
            }
        }
        
        cooldownTick += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if(cooldownTick >= cooldown)
            {
                attacking = true;
                bastaoCol.enabled = true;
            }
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
