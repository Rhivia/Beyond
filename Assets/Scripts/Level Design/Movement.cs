using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 5f;
    public float turnSpeed = 100f;

    float angle;
    Vector2 input;
    Quaternion targetRotation;
    Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;       
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Math.Abs(input.x) < 1 && Math.Abs(input.y)<1)
        {
            return;
        }

        calculateDirection();
        rotate();
        move();
    }

    private void move(){
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    private void rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void calculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }
}
