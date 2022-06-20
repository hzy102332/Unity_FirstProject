using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    public string home_name;
    public AudioMixer Aduiomixer;
    public GameObject winmenu;
    
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f; 
        GameObject.Find("backgroud").GetComponent<AudioSource>().Stop();
    }

    public void BackGame()
    {
        pausemenu.SetActive(false);
        GameObject.Find("backgroud").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
    }
    public void Home()
    {
        pausemenu.SetActive(false);
        SceneManager.LoadScene(home_name);
        Time.timeScale = 1f;
    }

    public void wintohome()
    {
        winmenu.SetActive(false);
        SceneManager.LoadScene(home_name);
        Time.timeScale = 1f;
    }

    public void wingame()
    {
        winmenu.SetActive(true);
        Time.timeScale = 0f; 
        GameObject.Find("backgroud").GetComponent<AudioSource>().Stop();
    }
    public void replaygame()
    {
        GameObject.Find("backgroud").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        winmenu.SetActive(false); 
        SceneManager.LoadScene("map1");
    }
    public void Setvolume(float value)
    {
        Aduiomixer.SetFloat("MainVolume", value);
    }
}
