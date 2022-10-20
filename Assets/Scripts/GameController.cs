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
    public GameObject hud;
    public GameObject victory;
    public static GameController instance;
    public bool isVictory;

    void Start()
    {
        isVictory = false;
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
        hud.SetActive(false);
        gameOver.SetActive(true);
    }
    
    public void Victory()
    {
        hud.SetActive(false);
        victory.SetActive(true);
        isVictory = true;
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        hud.SetActive(true);
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }
}