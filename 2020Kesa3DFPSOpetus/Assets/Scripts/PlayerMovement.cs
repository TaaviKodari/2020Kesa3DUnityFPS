﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 8f, runSpeed = 1.8f;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float pushForce = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    public Vector3 velocity;
    private bool isGrounded;

    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        move = transform.right * xAxis + transform.forward * zAxis;
        if (Input.GetButton("Fire3"))
        {
            //juostaan
            controller.Move(move * moveSpeed * runSpeed * Time.deltaTime);
        }
        else
        {
            //kävellään
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
       

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.layer == 8)
        {
            return;
        }

        Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();

        if(rb == null)
        {
            return;
        }
        rb.AddForce(move * pushForce);

    }

}
