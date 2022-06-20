using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite broken;
    public GameObject explodeprefab;
    public float hp = 2;
    public GameObject Gameover;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void playerdie()
    {
        hp -= 1;
    }

    private void Recover()
    {
        hp = 2;
    }
    private void DelayFunc(){
         sr.sprite = broken;
         Time.timeScale = 0;
    }

    
    private void Die(){
        Sound.instance.BaseHurt();
        Instantiate(explodeprefab,transform.position,transform.rotation);
        float time = FindObjectOfType<explode>().time;
        Invoke("DelayFunc", time);
    }
}
