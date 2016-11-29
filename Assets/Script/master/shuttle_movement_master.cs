﻿using UnityEngine;
using System.Collections;

public class shuttle_movement_master : MonoBehaviour {
    public int speed;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal_1");
        float v = -Input.GetAxisRaw("Vertical_1");

        rb2d.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);
        if (h != 0 || v != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, (Mathf.Atan2(-h, v) * 180) / Mathf.PI);
            GetComponent<Animator>().speed = 1;
        } else
        {
            GetComponent<Animator>().speed = 0;
        }
    }
}