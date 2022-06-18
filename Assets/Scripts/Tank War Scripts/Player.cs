using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private float cd;
    private Vector3 bullectEulerAngles;
    private float defendedTime = 3;

    public float speed = 3;
    public Sprite [] tank_sprite; //上右下左
    public GameObject bullet;
    public float CD = 0.4f;
    public GameObject explode;
    //是否无敌
    public bool isDefended = true;
    public GameObject sheild;
    public GameObject Born_player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {    
        Movement();
    // if is defended
        if (isDefended){
            sheild.SetActive(true);
            defendedTime -= Time.deltaTime;
            if (defendedTime <= 0){
                isDefended = false;
                sheild.SetActive(false);
            }
        }
        //shoot cd
        if(cd >= CD){
             Shoot();
        }else {
            cd += Time.deltaTime;
        }
    }

    private void Movement(){
        
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up*v*speed*Time.deltaTime, Space.World);
        //按下左键h是-1 
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right*h*speed*Time.deltaTime, Space.World);

        if (h == 0 && v == 0){}
            // Sound.instance.Idle();
        else
            Sound.instance.Move();
        //向下
        if(v<0){
            sr.sprite = tank_sprite[2];
            bullectEulerAngles = new Vector3(0,0,-180);
        }//向上
        else if(v>0){
            sr.sprite = tank_sprite[0];
            bullectEulerAngles = new Vector3(0,0,0);
        }  

        if (v != 0){
            return;
        }

        if(h<0){
            sr.sprite = tank_sprite[3];
            bullectEulerAngles = new Vector3(0,0,90);
        }else if(h>0){
            sr.sprite = tank_sprite[1];
            bullectEulerAngles = new Vector3(0,0,-90);
        }
        
    }

    private void Shoot(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet,transform.position,
            Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            cd = 0;
            Sound.instance.Fire();
        }        
    }
    
    private void Die(){
        if (isDefended){
            return;
        }
        //产生爆炸特效
        Sound.instance.Explode();
        Instantiate(explode,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void born()
    {
        Instantiate(Born_player, new Vector3(-2, -7, 0), Quaternion.identity);
    }

}
