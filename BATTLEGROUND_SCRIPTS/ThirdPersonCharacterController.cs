using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    
    
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float walkback = -4f;
    public float crouchSpeed = 2f;
    public float jumpForce = 4f;
    public float gravity = -12f;
    public float groundRayLength = 1f;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool isCrouching;
    private bool wasCrouching;
    private bool wasAiming;
    private bool isAiming;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 cameraOffset;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        cameraOffset = mainCamera.transform.position - transform.position;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRayLength);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = walkSpeed;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward = forward.normalized;

        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed = walkback;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
        }

        if (isCrouching)
        {
            speed = crouchSpeed;
        }

        if (vertical < 0)
        {
            speed = walkSpeed;
        }

        if (horizontal != 0 || vertical != 0)
        {
            moveDirection = (forward * vertical + right * horizontal).normalized;
            animator.SetFloat("speed", speed);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            moveDirection.y = jumpForce;
            animator.SetTrigger("jump");
        }

        moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime * speed);

        if (isCrouching)
        {
            if (!wasCrouching)
            {
                wasCrouching = true;
                animator.SetTrigger("crouch");
            }
        }
        else
        {
            if (wasCrouching)
            {
                wasCrouching = false;
                animator.SetTrigger("idle");
            }
        }



        if (Input.GetKeyDown(KeyCode.Backspace) && isGrounded && isAiming)
        {
            if (!wasAiming)
            {
                wasAiming = true;
                animator.SetTrigger("Aim");
            }
        }
        else
        {
            if (wasAiming)
            {
                wasAiming = false;
                animator.SetTrigger("idle");
            }
        }

        mainCamera.transform.position = transform.position + cameraOffset;
    }
}

