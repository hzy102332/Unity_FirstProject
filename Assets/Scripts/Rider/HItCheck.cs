using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HItCheck : MonoBehaviour
{
    public GameObject die;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
        {
            RiderSound.ins.Hit();
            Time.timeScale = 0f;
            die.SetActive(true);
        }
    }
}
