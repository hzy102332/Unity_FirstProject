using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class birdbullct : MonoBehaviour
{
    public float speed = 5;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime,Space
        .World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "enemy")
        {
             Destroy(gameObject);
        }
        else if (col.tag == "barriar")
        {
            Destroy(gameObject);
        }else if (col.tag == "bullect")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
