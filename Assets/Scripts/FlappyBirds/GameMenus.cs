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
    public GameObject Boss;
    public GameObject ScoreUI;
    public GameObject Spacehint;
    public Text score;
    public static float level = 1;
    public Image Image;
    //0: level1 1: level2
    public Sprite[] Sprites;

    private bool isinverse = false;
    private bool isBoss = false;
    
    public void LevelChange()
    { 
       level = level == 3 ? 1 : level + 1;
       Image.sprite = Sprites[(int)(level - 1)];
       SoundManager.instance.Modeslect();
    }
    public  void Gameover()
    {
        Time.timeScale = 0f;
        overCanvas.SetActive(true);
        GameObject.FindObjectOfType<FlyBird>().gameover = true;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
        SoundManager.instance.Modeslect();
    }
    public void BacktoGame()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        SoundManager.instance.Modeslect();
    }
    public void RePlay()
    {
        overCanvas.SetActive(false);
        SceneManager.LoadScene("FlappyBird");
        Time.timeScale = 1f;
        
        // Debug.Log(level);
    }
    public void BacktoHome()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }
    void Getpoint()
    {
        if (isinverse)
        {
            score.text = (float.Parse(score.text)-1).ToString();
        }else
            score.text = (float.Parse(score.text)+1).ToString();
        SoundManager.instance.Point();
    }

    void ShowBoss()
    {
        Boss.SetActive(true);
        Boss.GetComponentInChildren<AudioSource>().Play();
        GameObject.Find("y1").SendMessage("move");
        Spacehint.SetActive(true);
        Destroy(Spacehint,3);
        SoundManager.instance.back.Stop();
    }
    
    private void Start()
     {
         Image.sprite = Sprites[(int)(level - 1)];
     }
    private void LateUpdate()
    {
        if (score.text == "15")
        {
            isinverse = true;
        }
        //当分数是0，进入boss战
        if (score.text == "0" && isinverse && !isBoss)
        {
            isBoss = true;
            Invoke("ShowBoss",7);
            ScoreUI.SetActive(false);
            GameObject.FindObjectOfType<GameControl_Flappy>().stopcreate = true;
            
        }
    }
}
