using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float pipespeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * pipespeed * Time.deltaTime;
    }
}
