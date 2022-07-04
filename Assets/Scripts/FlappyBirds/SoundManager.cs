using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip die,point,hit,boss_fire,modeslect,win,Boss_move;
    public AudioSource audioSource;
    public AudioSource back;
    public AudioSource player;
    public static SoundManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    public void Fly()
    {
        player.Play();
    }
    public void Hit()
    { 
        back.Stop();
        audioSource.Stop();
        audioSource.clip = hit;
        audioSource.Play();
    }
    public void Point()
    {
        audioSource.Stop();
        audioSource.clip = point;
        audioSource.Play();
    }
    public void Die()
    {
        audioSource.Stop();
        audioSource.clip = die;
        audioSource.Play();
    }
    public void Boss_fire()
    {
        
        audioSource.clip = boss_fire;
        audioSource.Play();
    }
    public void Modeslect()
    {
        audioSource.Stop();
        audioSource.clip = modeslect;
        audioSource.Play();
    }
    public void Win()
    {
        audioSource.Stop();
        audioSource.clip = win;
        audioSource.Play();
    }

    public void BOSSMove()
    {
        audioSource.Stop();
        audioSource.clip = Boss_move;
        audioSource.Play();
    }
}
