using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    private Vector3 velocity;
    private float gravity = 15f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private bool onGround;
    public float jumpHeight = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(onGround);
        if (onGround && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Input.GetButton("Fire3") && onGround && Input.GetAxis("Vertical") >= 0) {
            speed = 9;
            Debug.Log("spring");
        } else if(speed == 9 && !onGround && Input.GetAxis("Vertical") >= 0) {
            speed = 9;
        } else {
            speed = 3f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && onGround) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
            Debug.Log("jump");
        }
        
        //Debug.Log(onGround);
        controller.Move(velocity * Time.deltaTime);
    }
}
