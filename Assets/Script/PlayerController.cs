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
    
    void Start()
    {
        moveValue = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    
    void Update()
    {
        rb.velocity = new Vector2(moveValue.ReadValue<Vector2>().x * playerSpeed, rb.velocity.y);
        if(jumpAction.ReadValue<float>() > 0.1  )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
