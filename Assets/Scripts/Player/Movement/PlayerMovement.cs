using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")] public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    /// <summary>
    /// 
    /// </summary
 //   public Joystick joystick;

    public bool isJumb;
    public bool isJumbing;

    public bool isControl;
    private void Start()
    {
        isControl = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isJumb = false;
        readyToJump = true;
    }

    private void Update()
    {
        if (!isControl)
            return;
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight /*0.5f + 0.2f*/, whatIsGround);
    
       
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
        {
            isJumbing = false;
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!isControl)
            return;
        MovePlayer();
  
    }

    private void MyInput()
    {
//#if UNITY_EDITOR
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
//#elif UNITY_ANDROID
//        Debug.Log("Android");
//        verticalInput = joystick.Vertical;
//        horizontalInput = joystick.Horizontal;
//#endif
        if (Input.GetKeyDown("space"))
            isJumb = true;

        // when to jump
        if (isJumb && readyToJump && grounded)
        {
            isJumbing = true;
            isJumb = false;
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0;
        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded && isJumbing)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

//        text_speed.SetText("Speed: " + flatVel.magnitude);
    }

    private void Jump()
    {
        // reset y velocity
       // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}