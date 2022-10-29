using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bastao : MonoBehaviour
{
    private Animator BastaoAnimator;
    private Collider2D bastaoCol;
    public float tick, cooldown;

    void Start()
    {
        BastaoAnimator = GetComponent<Animator>();
        bastaoCol = GetComponent<Collider2D>();
    }
    void Update()
    {
        tick += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && tick >= cooldown)
        {
            BastaoAnimator.SetTrigger("atack");
            tick = 0;
        }

        if (BastaoAnimator.GetCurrentAnimatorStateInfo(0).IsName("bastao_atack"))
        {
            bastaoCol.enabled = true;
        }
        else
        {
            bastaoCol.enabled = false;
        }
    }
    
}
