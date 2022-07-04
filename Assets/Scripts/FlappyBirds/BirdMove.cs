using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public float birdspeed;
    private ModeSelect modeSelect;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * birdspeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
            //当碰到鸟获得加成
            GameObject.FindObjectOfType<ModeSelect>().SendMessage("Weaponup");
        }
        
    }


}
