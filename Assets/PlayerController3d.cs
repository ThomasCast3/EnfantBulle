using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3d : MonoBehaviour
{
    public float playerSpeed = 5f;
    public InputAction moveValue;
    public InputAction jumpAction;
    public bool isGrounded = false;
    public Rigidbody rb;
    public float jumpForce = 10f;

    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; 

    void Start()
    {
        moveValue = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        rb.velocity = new Vector3(-moveValue.ReadValue<Vector2>().x * playerSpeed, rb.velocity.y , -moveValue.ReadValue<Vector2>().y * playerSpeed);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if(jumpAction.ReadValue<float>() > 0.1 && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
