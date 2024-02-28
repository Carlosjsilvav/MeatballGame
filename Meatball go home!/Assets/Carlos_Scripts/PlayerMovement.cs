using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public float walkSpeed;
    private float currSpeed;
    public bool grounded;
    private float drag = .8f;

    public bool playerCanMove;
    
    //Jump
    public float jumpForce = 100;
    
    //Camera
    private float mouseX;
    private float mouseY;
    [Range(0.0f,10.0f)]
    public float mouseSens = 1;
    private float xRot;
    private float yRot;
    public InputAction lookVector;
    public InputAction moveVector;
    
    //Components
    private Rigidbody rb;
    public PlayerInput actions;
    public Camera myCam;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame
    void Update()
    {
        CameraUpdate();
        MoveUpdate();
    }
    void InitializeComponents(){
        //Components
        rb = GetComponent<Rigidbody>();
        actions = GetComponent<PlayerInput>();
        
        //Actions
        moveVector = actions.actions.FindAction("Move");
        lookVector = actions.actions.FindAction("Look");
        actions.actions.FindAction("Jump").performed += OnJump;
        
        //Set Variables
        currSpeed = walkSpeed;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void CameraUpdate()
    {
        mouseX = lookVector.ReadValue<Vector2>().x;
        mouseY = lookVector.ReadValue<Vector2>().y;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 100);
        myCam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        rb.transform.Rotate(Vector3.up * mouseX * mouseSens);
    }

    private void MoveUpdate()
    {
        if (playerCanMove)
        {
            Vector3 moveDir = new Vector3(moveVector.ReadValue<Vector2>().x, 0, moveVector.ReadValue<Vector2>().y);
            transform.Translate(moveDir * currSpeed * Time.deltaTime * drag, Space.Self);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}