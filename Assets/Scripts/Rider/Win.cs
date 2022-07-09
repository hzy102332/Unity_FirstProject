using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject win;
    private void OnTriggerEnter2D(Collider2D col)
    {
        win.SetActive(true);
        RiderSound.ins.wingame();
        Time.timeScale = 0f;
    }
}
