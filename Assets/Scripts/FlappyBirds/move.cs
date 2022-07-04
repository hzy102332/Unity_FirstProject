using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float pipespeed;
    public float pipinterval;
    // Update is called once per frame
    void Update()
    {
        //管道移动
        transform.position += Vector3.left * pipespeed * Time.deltaTime;
    }
}
