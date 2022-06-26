using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType PlatformType;
    public float bounceSpeed = 7f;
    private bool isadd = false;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.up * bounceSpeed;
                if (! isadd)
                {
                    FindObjectOfType<GameManger>().SendMessage("AddScore");
                    isadd = true;
                }
               
            }


            if (PlatformType == PlatformType.weak)
            {
                if (GetComponent<Animator>() != null)
                {
                    //play animation
                    GetComponent<Animator>().SetTrigger("Trigger");
                    Invoke("hideobject",0.5f);
                    
                    //destroy platform
                }
            }
        }
    }

    void hideobject()
    {
        gameObject.SetActive(false);
    }
}

public enum PlatformType
{
    normal, weak,explode,move
}
