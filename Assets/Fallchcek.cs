using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallchcek : MonoBehaviour
{
   public GameObject over;
   private void OnTriggerEnter2D(Collider2D col)
   {
      RiderSound.ins.Carfall();
      Time.timeScale = 0f;
      over.SetActive(true);
   }
}
