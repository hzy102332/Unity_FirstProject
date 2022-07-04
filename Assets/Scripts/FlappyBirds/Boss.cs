using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject Hpbar;
    public GameObject WINMenu;
    public float shootinterval = 2;
    public float Max_hp = 1000;
    public Text weapon;
    private float Hp_precent = 1000;
    private Image Hpimage;

    public float bossskillcd = 3;

    public float bullectcd = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Hp_precent = Max_hp;
        Hpimage = Hpbar.GetComponent<Image>();
        player.GetComponent<Transform>();
        InvokeRepeating("Skill_left",0,10);
        InvokeRepeating("ShootBullect1",2,10);
        InvokeRepeating("ShootBullect2",4,10);
        InvokeRepeating("ShootBullect3",6,10);
        InvokeRepeating("RandomBullect",8,10);
    }

    // Update is called once per frame
    void Update()
    {
        Hpimage.fillAmount = Hp_precent / Max_hp;
        if (Hp_precent == 0)
        {
            GetComponent<AudioSource>().Stop();
            WINMenu.SetActive(true);
            SoundManager.instance.Win();
            Time.timeScale = 0.5f;
            Invoke("Changetime",2);
        }
    }

    void Changetime()
    {
        Time.timeScale = 0f;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "bullect")
        {
             Hit();
             ReduceHP();
        }
    }
    public void ReduceHP()
    {
        Hp_precent -= float.Parse(weapon.text);
    }
    public void ShootBullect1()
    {
        for (int i = -1; i < 3; i++)
        {
            GameObject fireball = Instantiate(bullet, null);
            Vector3 dir = Quaternion.Euler(0, i * 15, 0) * -transform.right;
            //位置
            fireball.transform.position = gameObject.transform.position + dir * 2f;
            //角度
            fireball.transform.rotation = Quaternion.Euler(0, 0, i * 20);
        }
        SoundManager.instance.Boss_fire();
    }
    public void ShootBullect2()
    {
        for (int i = -1; i < 5; i++)
        {
            GameObject fireball = Instantiate(bullet, null);
            Vector3 dir = Quaternion.Euler(0, i * 15, 0) * -transform.right;
            //位置
            fireball.transform.position = gameObject.transform.position + dir * 2f;
            //角度
            fireball.transform.rotation = Quaternion.Euler(0, 0, i * 15);
        }
    }
    public void ShootBullect3()
    {
        for (int i = -4; i < 6; i++)
        {
            GameObject fireball = Instantiate(bullet, null);
            Vector3 dir = Quaternion.Euler(0, i * 15, 0) * -transform.right;
            //位置
            fireball.transform.position = gameObject.transform.position + dir * 2f;
            //角度
            fireball.transform.rotation = Quaternion.Euler(0, 0, i * 10);
        }
    }
    public void RandomBullect()
    {
        
        for (int i = 0; i < 10; i++)
        {
            float po = Random.Range(-4,7);
            GameObject bull = Instantiate(bullet, null);
            bull.transform.position = new Vector3(i * 1 + 15, po, 0);
            bullectcd = 0;
        }
    }
    public void Hit()
    {
        gameObject.GetComponent<Animator>().SetTrigger("hit");
    }
    public void Skill_left()
    {
        gameObject.GetComponent<Animator>().SetTrigger("left");
        SoundManager.instance.BOSSMove();
    }
    
}
