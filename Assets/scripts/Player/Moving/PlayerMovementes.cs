 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementes : MonoBehaviour
{
    //public FoodHunger foodhunger1;
    [SerializeField] Transform orientation;
    public float jumpForce = 60f;
    public float jetForce = 45f;
    float playerHeight = 2f;
    public float flyingForward = 15f;
    public float flyingUp = 10f;



    [Header("Movement")]
    public float moveSpeed = 6f;
    [SerializeField] float airMultiplier = 0.4f;
    public float movementMultiplier = 10f;
    public float sprint = 15f;
    public bool IsSprinting = false;
    public int fuel = 3000;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;

    [Header("Drag")]
    public float groundDrag = 8f;
    public float airDrag = 4f;
    public float gravitytest = 2f;

    float horMove;
    float vertMove;
    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    public float groundDistance = 0.4f;

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    RaycastHit slopeHit;

    private bool onSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 2f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, groundMask);
        MyInput();
        ControlDrag();



        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            jump();
        }
        else if (Input.GetKey(jumpKey) && !isGrounded && fuel > 0)
        {
            fuelSpend();
            airDrag = 2.5f;
            moveSpeed = 500f;
        }
        else
        {
            airDrag = -0.015f;
            moveSpeed = 45f;
        }
        if (isGrounded && fuel<=3000)
        {
            fuel += 5;
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += sprint;
            IsSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed -= sprint;
            IsSprinting = false;
        }

    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

    }
    void MyInput()
    {
        horMove = Input.GetAxisRaw("Horizontal");
        vertMove = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.right * horMove + orientation.forward * vertMove;
    }
    private void FixedUpdate()
    {
        MovePlayer();
        rb.AddForce(Physics.gravity, ForceMode.Acceleration);
    }
    void MovePlayer()
    {
        if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }

        else
        {
            if (!onSlope())
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            }
            else
            {
                rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            }
        }
    }

    void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    public void fuelSpend()
    {
        
        if (fuel > 0)
        {
            //var flyDir = Vector3.up * flyingUp + orientation.forward * flyingForward;
            //rb.AddForce(flyDir, ForceMode.Acceleration);
            rb.AddForce(Vector3.up * jetForce, ForceMode.Acceleration);
            fuel -= 1;
        }
    }
}