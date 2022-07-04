using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public AudioSource AudioSource;

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void Tank()
    {
        AudioSource.Play();
        SceneManager.LoadScene("Scenes/Tankwar_main");
    }
    public void Flappy()
    {
        AudioSource.Play();
        SceneManager.LoadScene("FlappyBird");
    }
    public void Doodler()
    {
        AudioSource.Play();
        SceneManager.LoadScene("Doodler");
    }
    
}
