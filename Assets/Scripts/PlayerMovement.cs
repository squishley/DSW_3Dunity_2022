using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public bool isSprinting = false;
    public bool isCrouching = false;
    public bool isJumping = false;
    public float jumpHeight = 3f;    
    public float crouchingHeight = 1.2f;
    public float standingHeight = 2.2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //IS GROUNDED 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //JUMPING

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //SPRINT

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            isCrouching = false;
            speed = 24f;
        }
        else
        {
            isSprinting = false;

            //CROUCHING

            if (Input.GetKey(KeyCode.LeftControl))
            {
                isCrouching = true;
                controller.height = crouchingHeight;
                speed = 6f;
            }
            else
            {
                isCrouching = false;
                controller.height = standingHeight;
                speed = 12f;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
    }
}
