using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cuphead : MonoBehaviour
{
    //0:up 1:right 2:down
    public Sprite[] cuphead;
    public Animator Animator;
    public float Speed;
    private bool isleft = false;
    public AudioSource AudioSource;

    private void Start()
    {
        Destroy(GameObject.Find("Canvas"),2);
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyUp(KeyCode.W))
        {
            Animator.SetFloat("w",0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Animator.SetFloat("d",0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Animator.SetFloat("s",0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Animator.SetFloat("d",0);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime,Space.World);
            Animator.SetFloat("w",2);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (isleft)
            { 
                transform.Rotate(0,-180,0);
                isleft = false;
            }
            Animator.SetFloat("d",2);
            transform.Translate(Vector3.right * Speed * Time.deltaTime,Space
            .World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Animator.SetFloat("s",2);
            transform.Translate(-Vector3.up * Speed * Time.deltaTime,Space.World);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!isleft)
            {
                 transform.Rotate(0,180,0);
                 isleft = true;
            }
            Animator.SetFloat("d",2);
            transform.Translate(-Vector3.right * Speed * Time.deltaTime,Space
            .World);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        
        if (col.gameObject.name == "g1")
        {
            AudioSource.Play();
            SceneManager.LoadScene("FlappyBird");
        }
        if (col.gameObject.name == "g2")
        {
            AudioSource.Play();
            SceneManager.LoadScene("Tankwar_main");
        }
        if (col.gameObject.name == "g3")
        {
            AudioSource.Play();
            SceneManager.LoadScene("Doodler");
        }
        if (col.gameObject.name == "exit")
        {
            AudioSource.Play();
            Application.Quit();
        }
        if (col.gameObject.name == "Rider")
        {
            AudioSource.Play();
            SceneManager.LoadScene("Rider");
        }
    }
}
