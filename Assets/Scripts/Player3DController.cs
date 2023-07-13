using UnityEngine;
using System.Collections.Generic;

public class Player3DController : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 3.0f;

    [SerializeField]
    float runSpeed = 5.0f;

    [SerializeField]
    float rotationSpeed = 8.0f;

    [SerializeField]
    float mouseSensitivity = 8.0f;

    [SerializeField]
    float jumpForce = 6.0f;

    [SerializeField]
    float gravityMultiplier = 2.0f;

    CharacterController characterController;
    Transform cameraTransform;


    float verticalRotation = 0.0f;
    float verticalVelocity = 0.0f;

    bool isJumping = false;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
    }

    void HandleMovement()
    {
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;
        Vector3 movement = moveDirection * moveSpeed;

        verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        movement.y = verticalVelocity;

        characterController.Move(movement * Time.deltaTime);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);

        verticalRotation -= mouseY * rotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);
    }

    void HandleJump()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                verticalVelocity = jumpForce;
            }
            else
            {
                isJumping = false;
                verticalVelocity = 0.0f;
            }
        }
    }


}
