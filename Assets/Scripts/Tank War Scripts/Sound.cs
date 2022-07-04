using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip fire, die, killenemy, move,idle 
        ,basedestroy, explosion;
    public AudioSource audioSource;
    public static Sound instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void Fire()
    {
        audioSource.clip = fire;
        audioSource.Play();
    }
    
    public void Move()
    {
        audioSource.clip = move;
        audioSource.Play();
    }
    
    public void Idle()
    {
        audioSource.clip = idle;
        audioSource.Play();
    }
    
    public void Explode()
    {
        audioSource.clip = explosion;
        audioSource.Play();
    }
    
    public void Getpoint()
    {
        audioSource.clip = killenemy;
        audioSource.Play();
    }
    
    public void Die()
    {
        audioSource.clip = die;
        audioSource.Play();
    }
    
    public void BaseHurt()
    {
        audioSource.clip = basedestroy;
        audioSource.Play();
    }
}
