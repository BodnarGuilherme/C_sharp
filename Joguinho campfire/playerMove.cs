using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [Header("Statistica")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;

    public bool isWalk;
    public bool isRun;
    public bool isGround;

    [Header("Jump")]
    Vector3 velocity;
    public float gravity;
    public LayerMask layersJump;
    float velocityY;


    //Move
    CharacterController controller;
    float horizontal, vertical;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime;
        float zAxis = Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;

        isWalk = xAxis != 0 || zAxis != 0;
        isRun = Input.GetKey(KeyCode.LeftShift) && isWalk;


        isGround = Physics.Raycast(transform.position, -transform.up, 3.49999999f, layersJump);

        

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        if (isRun)
        {
            xAxis = Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime;
            zAxis = Input.GetAxisRaw("Vertical") * runSpeed * Time.deltaTime;
        }
        else
        {
            xAxis = Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime;
            zAxis = Input.GetAxisRaw("Vertical") * walkSpeed * Time.deltaTime;
        }

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
