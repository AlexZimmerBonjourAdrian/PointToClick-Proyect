using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// CPlayer3DController is a component that controls a 3D character's movement and camera in a 3D environment.
    /// It handles player input for movement (WASD or arrow keys), jumping (Space), and looking around (mouse).
    /// </summary>
    public class CPlayer3DController : MonoBehaviour
    {
        // Movement variables
        /// <summary>
        /// The speed at which the character moves.
        /// </summary>
        public float moveSpeed = 5f;
        /// <summary>
        /// The height of the character's jump.
        /// </summary>
        public float jumpHeight = 2f;
        /// <summary>
        /// The force of gravity acting on the character.
        /// </summary>
        public float gravity = -9.81f;

        // Look variables
        /// <summary>
        /// The sensitivity of the mouse for looking around.
        /// </summary>
        public float mouseSensitivity = 2f;
        /// <summary>
        /// The maximum angle the player can look up or down.
        /// </summary>
        public float clampAngle = 80f;

        // Private variables
        /// <summary>
        /// The CharacterController component attached to the player.
        /// </summary>
        private CharacterController _controller;
        /// <summary>
        /// The direction in which the character is moving.
        /// </summary>
        private Vector3 _moveDirection;
        /// <summary>
        /// The character's current velocity.
        /// </summary>
        private Vector3 _velocity;
        /// <summary>
        /// The character's vertical rotation angle.
        /// </summary>
        private float _verticalRotation;
        /// <summary>
        /// The character's horizontal rotation angle.
        /// </summary>
        private float _horizontalRotation;

        /// <summary>
        /// The transform that determines the movement direction (forward/backward, left/right).
        /// </summary>
        [SerializeField]
        private Transform direction_Transform;


        /// <summary>
        /// The transform of the camera, used for looking around.
        /// </summary>
        [SerializeField]
        private Transform CameraTransform;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// It initializes the CharacterController and sets the initial vertical rotation.
        /// </summary>
        private void Awake()
        {
            // Get the CharacterController component.
            _controller = GetComponent<CharacterController>();
            // Initialize the vertical rotation to the current Y rotation of the object.
            _verticalRotation = transform.localEulerAngles.y;
        }

        /// <summary>
        /// Update is called every frame.
        /// It handles character movement, jumping, and looking around based on player input.
        /// </summary>
        private void Update()
        {
            // --- Movement ---
            // Get horizontal (A/D or left/right arrows) and vertical (W/S or up/down arrows) input.
            float xHorizontal = Input.GetAxis("Horizontal");
            float zVertical = Input.GetAxis("Vertical");

            // Calculate the movement direction based on the input and the direction_Transform.
            _moveDirection = direction_Transform.forward * zVertical; // Forward/Backward
            _moveDirection += direction_Transform.right * xHorizontal; // Left/Right

            // Check if the character is grounded (touching the ground).
            if (_controller.isGrounded)
            {
                // Set the horizontal velocity based on the movement direction and move speed.
                _velocity.x = _moveDirection.x * moveSpeed;
                _velocity.z = _moveDirection.z * moveSpeed;
                // Check if the jump button (Space) is pressed.
                if (Input.GetButtonDown("Jump"))
                {
                    // Calculate the upward velocity for jumping.
                    _velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
                }
            }
            //If the player is not in the ground.
            if (!_controller.isGrounded)
            {
             // Set the horizontal velocity based on the movement direction and move speed.
             _velocity.x = _moveDirection.x * moveSpeed;
             _velocity.z = _moveDirection.z * moveSpeed;
             // Apply gravity to the vertical velocity.
             _velocity.y -= gravity * Time.deltaTime;
            }

            // Move the character using the calculated velocity.
            _controller.Move(_velocity * Time.deltaTime);

            // --- Looking Around ---
            // Get mouse movement input.
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Adjust the vertical and horizontal rotation based on mouse input.
            _verticalRotation += mouseX;
            _horizontalRotation -= mouseY;

            // Clamp the horizontal rotation to prevent looking too far up or down.
            _horizontalRotation = Mathf.Clamp(_horizontalRotation, -clampAngle, clampAngle);

            // Apply the rotations to the CameraTransform.
            //The camera is rotated vertically with _horizontalRotation and horizontally with _verticalRotation
            CameraTransform.transform.localEulerAngles = new Vector3(_horizontalRotation, _verticalRotation, 0f);
        }
    }
}
