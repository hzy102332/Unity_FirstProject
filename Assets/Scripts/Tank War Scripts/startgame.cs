using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    // Update is called once per frame

    public void Startgame(){
        SceneManager.LoadScene("map1");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Home");
    }
}
