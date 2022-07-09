using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderSound : MonoBehaviour
{
    public AudioClip start, move,hit,win,fall;
    public AudioSource AudioSource;
    public static RiderSound ins;
    
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        AudioSource.clip = start;
        AudioSource.Play();
    }

    public void Carmove()
    {
        if (!AudioSource.isPlaying)
        {
            AudioSource.clip = move;
            AudioSource.Play();
        }
        
    }

    public void Carfall()
    {
        AudioSource.clip = fall;
        AudioSource.Play();
    }

    public void Hit()
    {
        AudioSource.clip = hit;
        AudioSource.Play();
    }

    public void wingame()
    {
        AudioSource.clip = win;
        AudioSource.Play();
    }
}
