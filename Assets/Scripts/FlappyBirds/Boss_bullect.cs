using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullect : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime,Space
            .World);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.FindObjectOfType<GameMenus>().SendMessage("Gameover");
             SoundManager.instance.Hit();
        }
       
    }
}
