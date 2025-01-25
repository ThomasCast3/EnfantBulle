using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public InputAction moveValue;
    public InputAction jumpAction;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool isGrounded = false;

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
        rb.velocity = new Vector2(moveValue.ReadValue<Vector2>().x * playerSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if(jumpAction.ReadValue<float>() > 0.1 && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        Debug.LogWarning(rb.velocity.y);
    }
}
