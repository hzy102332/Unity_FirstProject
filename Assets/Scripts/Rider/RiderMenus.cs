using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiderMenus : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Die;

    public void PauseMenu(){
       Pause.SetActive(true); 
       Time.timeScale = 0f;
    }

    public void Back(){
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(){
         SceneManager.LoadScene("Home");
         Time.timeScale = 1f;
    }

    public void Retry(){
        SceneManager.LoadScene("Rider");
        Time.timeScale = 1f;
    }
}
