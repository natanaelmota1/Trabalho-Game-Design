using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int vida;
    public Text vidaText;
    public GameObject gameOver;
    public static GameController instance;
    void Start()
    {
        instance = this;
        vida = 100;
    }

    void Update()
    {
        if (vida <= 0)
        {
           GameOver();
        }
    }

    public void UpdateVida(int dano)
    {
        vida -= dano;
        vidaText.text = vida.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }
}