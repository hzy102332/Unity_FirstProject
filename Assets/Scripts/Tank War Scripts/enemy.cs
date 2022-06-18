using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemy : MonoBehaviour
{

    private SpriteRenderer sr;
    private Vector3 bullectEulerAngles;
    private float v,h;
   //计时器
    private float rotationtime = 0.5f;
    private float cd;
    
    public float speed = 1;
    public Sprite [] tank_sprite;
    public GameObject bullet;
    public float shootcd = 1;
    public GameObject explode;
    public GameObject Bonr_enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {    
        
        Movement();
        
       //shoot interval
        if(cd >= shootcd){
             Shoot();
        }else {
            cd += Time.deltaTime;
        }
    }

    private void Movement(){

        if(rotationtime>=1){
            int num = Random.Range(0,8);
            if (num >=5){
                v = -1;
                h = 0;
            }else if (num == 0){
                v = 1;
                h = 0;
            }else if (num <= 2){
                h = -1;
                v = 0;
            }else if(num <= 4){
                h = 1;
                v = 0;
            }
            rotationtime = 0;
        }else {
            rotationtime += Time.fixedDeltaTime;
        }
   
        transform.Translate(Vector3.up*v*speed*Time.fixedDeltaTime, Space.World);

        if(v<0){
            sr.sprite = tank_sprite[2];
            bullectEulerAngles = new Vector3(0,0,-180);
        }else if(v>0){
            sr.sprite = tank_sprite[0];
            bullectEulerAngles = new Vector3(0,0,0);
        }  

        // if (v != 0){
        //     return;
        // }

    //按下左键h是-1 
        transform.Translate(Vector3.right*h*speed*Time.fixedDeltaTime, Space.World);

        if(h<0){
            sr.sprite = tank_sprite[3];
            bullectEulerAngles = new Vector3(0,0,90);
        }else if(h>0){
            sr.sprite = tank_sprite[1];
            bullectEulerAngles = new Vector3(0,0,-90);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            rotationtime = 0.5f;
            
        }
    }

    private void Shoot(){
        // if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet,transform.position,
            Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            cd = 0;
        // }        
    }
    
    private void Die(){
        Sound.instance.Explode();
        //产生爆炸特效
        Instantiate(explode,transform.position,transform.rotation);
        Destroy(gameObject);
        // Instantiate(Bonr_enemy,new Vector3(2,0,0),Quaternion.identity);
    }
    

}
