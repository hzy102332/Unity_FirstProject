using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Doodle_Pause : MonoBehaviour
{
    public GameObject pausemenu;
    public AudioMixer Aduiomixer;
    public GameObject gameover;
    

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        pausemenu.SetActive(false);
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameover.SetActive(true);
    }
    
    public void ReplayGame()
    {
        // GameObject.Find("backgroud").GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        gameover.SetActive(false);
        SceneManager.LoadScene("Doodler");
    }
    public void Setvolume(float value)
    {
        Aduiomixer.SetFloat("MainVolume", value);
    }
}
