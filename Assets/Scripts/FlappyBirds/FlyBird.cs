using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 1f;
    public GameMenus gameManger;
    private Rigidbody2D rb;
    public float rotationChange = 3f;
    public Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,rb.velocity.y *
         rotationChange));
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up + new Vector2(0,speed);
        }
        Debug.Log(transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        gameManger.Gameover();
    }
}
