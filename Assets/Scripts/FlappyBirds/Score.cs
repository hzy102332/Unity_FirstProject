using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            FindObjectOfType<GameMenus>().SendMessage("Getpoint");
    }

}
