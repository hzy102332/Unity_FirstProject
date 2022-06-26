using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenus : MonoBehaviour
{
    public GameObject overCanvas;
    public GameObject PauseCanvas;
    public Text score;
    private float point = 0;
    public  void Gameover()
    {
        Time.timeScale = 0f;
        overCanvas.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
    }

    public void BacktoGame()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
    }
    public void RePlay()
    {
        overCanvas.SetActive(false);
        SceneManager.LoadScene("FlappyBird");
        Time.timeScale = 1f;
    }

    public void BacktoHome()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }

    private void Start()
    {
        point = 0;
    }

    void Getpoint()
    {
        point += 1;
        score.text = point.ToString();
    }
}
