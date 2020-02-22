using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Player */
    private CharacterController controller;

    /* Movement */
    private float horizontalMovement, verticalMovement;
    public float playerSpeed = 12f;
    public float jumpHeight = 3f;
    bool doubleJump = false;
    bool enableFreeze = false;

    /* Gravity */
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    /* Freezable */
    private Collider[] freezables;
    public LayerMask freezeMask;
    public float freezeRange = 50f;
    bool powerUsed = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (!doubleJump)
            {
                doubleJump = true;
                Jump();
            }
        }

        MovePlayer();
        Gravity();

        // Freeze Command
        if (Input.GetKeyDown("e"))
        {
            Transform box = ReturnCloser();
            Renderer render = box.GetComponent<Renderer>();
            Freezable obj = box.GetComponent<Freezable>();

            if (powerUsed)
            {
                obj.FreezeHandler += Freeze;
            }

            render.material.color = Color.black;
        }
    }
    private void Freeze(Rigidbody rb)
    {
        Debug.Log("Enable");
        // freezeSave = rb.velocity;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
    }

    private Transform ReturnCloser()
    {
        freezables = Physics.OverlapSphere(transform.position, freezeRange, freezeMask);

        Transform tMin = null;

        float minDist = Mathf.Infinity;
        // Vector3 currentPos = transform.position;

        foreach (Collider freezable in freezables)
        {
            Renderer render = freezable.GetComponent<Renderer>();

            float dist = Vector3.Distance(transform.position, render.transform.position);
            if (dist < minDist)
            {
                tMin = render.transform;
                minDist = dist;
            }
        }

        return tMin;
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            doubleJump = false;
        }
    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void MovePlayer()
    {
        Vector3 move = transform.right * horizontalMovement + transform.forward * verticalMovement;

        controller.Move(move * playerSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
