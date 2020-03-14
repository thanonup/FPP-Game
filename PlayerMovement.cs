using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float runSpeed = 0.5f;

    public float jumpHeightdefault;
    public float speeddefault;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 velocity;
    Vector3 move;

    bool isGrounded;
    bool running;
    bool Crouching;


    private void Start()
    {
        jumpHeightdefault = jumpHeight;
        speeddefault = speed;
        
    }
    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move* speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * speed * runSpeed * Time.deltaTime);
            running = true;
        }
        else { running = false; }

        if (Input.GetKey(KeyCode.LeftControl) && !running)
        {          
            transform.localScale = new Vector3(1, 0.7f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            }
        }
        
    }
}
