using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximaFase : MonoBehaviour
{
    public String nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.instance.NextLevel(nextLevel);
        }
    }
}
