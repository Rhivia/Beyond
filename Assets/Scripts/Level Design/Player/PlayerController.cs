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
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            
            if (!doubleJump && !isGrounded)
            {
                doubleJump = true;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        MovePlayer();
        Gravity();

        // Freeza Command
        if (Input.GetKeyDown("e"))
        {
            Transform box = ReturnCloser();
            Freezable freezePower = box.GetComponent<Freezable>();
            Rigidbody rb = box.GetComponent<Rigidbody>();

            if (powerUsed)
            {
                freezePower.freeze = true;
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                freezePower.freeze = false;
                rb.constraints = RigidbodyConstraints.None;
            }

            // Renderer render = box.GetComponent<Renderer>();
            // render.material.color = Color.black;
        }
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

    /**
    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
    */

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
}
