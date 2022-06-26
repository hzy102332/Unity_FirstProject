using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject Gamover;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            Gamover.SetActive(true);
            Time.timeScale = 0f; 
        }
       
    }
}
