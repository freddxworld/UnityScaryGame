using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

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

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;

        /*
        if (Input.GetButtonDown("Jump") && onGround) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
            Debug.Log("jump");
        }*/
        
        //Debug.Log(onGround);
        controller.Move(velocity * Time.deltaTime);
    }
}
