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

    public void QuitGame() 
    {
        Application.Quit();
    }

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
    public void Home(){
        pausemenu.SetActive(false);
        SceneManager.LoadScene(home_name);
        Time.timeScale = 1f;
    }

    public void Setvolume(float value)
    {
        Aduiomixer.SetFloat("MainVolume", value);
    }
}
