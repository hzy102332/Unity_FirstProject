using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Show : MonoBehaviour
{
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject Gameover;
    
    void Update()
    {
        float hpnum = FindObjectOfType<Base>().hp;
        if (hpnum == 1)
            hp1.SetActive(false);
        else if (hpnum == 0)
            hp2.SetActive(false);
        else if (hpnum < 0)
        {
            Gameover.SetActive(true);
            hp3.SetActive(false);
            // Time.timeScale = 0f;
        }
    }

    public void Home()
    {
        Time.timeScale = 1f;
        Gameover.SetActive(false);
        SceneManager.LoadScene("Tankwar_main");
    }
    public void Restart()
    { 
        Time.timeScale = 1f;
        Gameover.SetActive(false); 
        SceneManager.LoadScene("map1");
    }

    private void Over()
    {
        Gameover.SetActive(true);
    }
}
