using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpSpeed;
    private CharacterController charecterController;
    private float ySpeed;
    private float originalStepOffset;
    [SerializeField]private float jumpButtonGracePeriod;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    [SerializeField]private Transform cameraTransform;


    void Start()
    {
        charecterController = GetComponent<CharacterController>();
        originalStepOffset = charecterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3 (horizontalInput,0,verticalInput);
        float magnitude = movementDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up)* movementDirection;
        movementDirection.Normalize();
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(charecterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }
        if(Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if(Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            charecterController.stepOffset = originalStepOffset;
            ySpeed= -0.5f;

            if(Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
            ySpeed = jumpSpeed;
            jumpButtonPressedTime = null;
            lastGroundedTime = null;
            }
        }
        else
        {
            charecterController.stepOffset = 0f;
        }

        

        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;
        charecterController.Move(velocity * Time.deltaTime);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            
        }
    }

    private void OnApplicationFocus (bool focus)
    {
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState=CursorLockMode.None;
        }
    }
}
