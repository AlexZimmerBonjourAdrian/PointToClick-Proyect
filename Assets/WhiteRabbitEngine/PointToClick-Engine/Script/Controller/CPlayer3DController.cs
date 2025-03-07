using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer3DController : MonoBehaviour
{
    // Movement variables
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    // Look variables
    public float mouseSensitivity = 2f;
    public float clampAngle = 80f;

    // Private variables
    private CharacterController _controller;
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private float _verticalRotation;
    private float _horizontalRotation;

    [SerializeField]
    private Transform direction_Transform;


 
    [SerializeField]
    private Transform CameraTransform;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _verticalRotation = transform.localEulerAngles.y;
        
      
    }

    private void Update()
    {
        // Movement
        float xHorizontal = Input.GetAxis("Horizontal");
        float zVertical = Input.GetAxis("Vertical");

        _moveDirection = direction_Transform.forward * zVertical; // Forward/Backward
        _moveDirection += direction_Transform.right * xHorizontal; // Left/Right

       
        if (_controller.isGrounded)
        {
             _velocity.x = _moveDirection.x * moveSpeed;
             _velocity.z = _moveDirection.z * moveSpeed;
             if (Input.GetButtonDown("Jump"))
             {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);   
             }   
        }  

        if (!_controller.isGrounded)
        {
         _velocity.x = _moveDirection.x * moveSpeed;
         _velocity.z = _moveDirection.z * moveSpeed;
         _velocity.y -= gravity * Time.deltaTime;
        }
        _controller.Move(_velocity * Time.deltaTime);

        // Looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        _verticalRotation += mouseX;
        _horizontalRotation -= mouseY;

        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -clampAngle, clampAngle);

       CameraTransform.transform.localEulerAngles = new Vector3(_horizontalRotation, _verticalRotation, 0f);
    }
}
