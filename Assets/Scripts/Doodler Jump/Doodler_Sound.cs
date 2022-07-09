using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodler_Sound : MonoBehaviour
{
    public AudioClip jump, fall;
    public AudioSource AudioSource;
    public static Doodler_Sound instance;

    private void Awake()
    {
        instance = this;
    }

    public void Jump()
    {
        AudioSource.clip = jump;
        AudioSource.Play();
    }

    public void Fall()
    {
        AudioSource.clip = fall;
        AudioSource.Play();
    }
}
