using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3d : MonoBehaviour
{
    public float playerSpeed = 5f;
    public InputAction moveValue;
    public InputAction jumpAction;
    public InputAction lookAction;
    public bool isGrounded = false;
    public Rigidbody rb;
    public float jumpForce = 10f;

    private Vector3 moveDirection;
    public Transform groundCheck; 
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; 
    public float mouseSensitivity = 100f;

    void Start()
    {
        moveValue = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        Vector2 input = moveValue.ReadValue<Vector2>();
        moveDirection = transform.forward * -input.y + transform.right * -input.x;
        
        Vector3 velocity = new Vector3(moveDirection.x * playerSpeed, rb.velocity.y, moveDirection.z * playerSpeed);
        rb.velocity = velocity;
        
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
