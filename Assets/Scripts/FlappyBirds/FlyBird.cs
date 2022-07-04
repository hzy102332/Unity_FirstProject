using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 1f;
    public GameMenus gameManger;
    private Rigidbody2D rb;
    public float rotationChange = 3f;
    public bool gameover = false;
    public GameObject birdbullet;
    public float cd = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,rb.velocity.y * rotationChange));
                //点击鼠标左键往上飞
                if (Input.GetMouseButtonDown(0) && !gameover)
                {
                    rb.velocity = Vector2.up + new Vector2(0,speed);
                    SoundManager.instance.Fly();
                }
              
                //点击空格发射小鸟
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(birdbullet, transform.position + new Vector3(1,0,0), Quaternion.Euler
                        (transform.eulerAngles ));
                    cd = 0;
                }
        
                cd += Time.deltaTime;
    }

    //player移到屏幕左边
    public void move()
    {
        transform.position = transform.position - new Vector3(9,0,0);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        gameManger.Gameover();
        SoundManager.instance.Hit();
    }
}
