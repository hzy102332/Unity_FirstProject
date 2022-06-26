using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Positionchange : MonoBehaviour
{

   public Transform target;
   public float movespeed = 0.3f;
   private Vector3 speed;
   
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.tag == "Player")
      { 
         Transform t = other.gameObject.transform;
         t.position = new Vector3((-t.position.x)/ 0.95f, t.position.y, 0);
      }

      if (other.tag == "platform")
      {
         other.gameObject.SetActive(false);
      }
      
   }
   
   //camera follow
   private void LateUpdate()
   {
      if (target.position.y > transform.position.y)
      {
         Vector3 targetpos = new Vector3(0, target.position.y, -10f);
         transform.position = Vector3.SmoothDamp(transform.position, 
            targetpos, ref speed, movespeed * Time.deltaTime);
      }
   }
}
