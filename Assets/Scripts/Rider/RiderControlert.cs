using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiderControlert : MonoBehaviour
{
    public bool move;
    private Rigidbody2D rb;
    public float MaxmoveSpeed = 8f;
    private float movespeed = 0f;
    public float rotateSpeed = 30f;
    public Transform Groundcheckl, Groundcheckr;
    public LayerMask Ground;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(GameObject.Find("Hint"),2);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            move = false;
        }

        if (!isGround())
        {
            if (Input.GetKey(KeyCode.RightArrow))
            { 
                rb.AddTorque(-rotateSpeed);
            }
        }
    }

    private void FixedUpdate()
    {
        
        if (move)
        {
            if (isGround())
            {
                if (MaxmoveSpeed > movespeed)
                {
                    movespeed += Time.deltaTime * 4f;
                    RiderSound.ins.Carmove();
                }
                else
                {
                    movespeed = MaxmoveSpeed;
                } 
                rb.velocity = transform.right * movespeed;
                rb.AddForce(-transform.up * 9.8f);
            }else 
            {  
                rb.AddTorque(rotateSpeed);
                movespeed = MaxmoveSpeed / 2;
                
            }
        }
    }

    bool isGround()
    {
        RaycastHit2D hitl = Physics2D.Raycast(Groundcheckl.position,
            -transform.up, 0.2f, Ground);
        RaycastHit2D hitr = Physics2D.Raycast(Groundcheckr.position,
            -transform.up, 0.5f, Ground);
        return hitl && hitr;
    }
    
}
