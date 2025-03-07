using UnityEngine;
using System.Collections;
using Vector2 = UnityEngine.Vector2;
using WhiteRabbit.Core;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// The Player class controls the player character's movement and interactions in a 2D platformer environment.
    /// It handles jumping, horizontal movement, gravity, and collision detection using the Controller2D class.
    /// </summary>
    [RequireComponent(typeof(Controller2D))] // Ensures that the GameObject has a Controller2D component attached.
    public class Player : MonoBehaviour
    {
        // --- Public Variables ---
        /// <summary>
        /// The height of the player's jump.
        /// </summary>
        public float jumpHeight = 4;
        /// <summary>
        /// The time it takes for the player to reach the peak of their jump.
        /// </summary>
        public float timeToJumpApex = .4f;
        /// <summary>
        /// The distance the player can interact with objects.
        /// </summary>
        public float interactionDistance = 2f;

        // --- Private Variables ---
        /// <summary>
        /// The rate at which the player's horizontal velocity changes while airborne.
        /// </summary>
        float accelerationTimeAirborne = .2f;
        /// <summary>
        /// The rate at which the player's horizontal velocity changes while grounded.
        /// </summary>
        float accelerationTimeGrounded = .1f;
        /// <summary>
        /// The player's maximum horizontal movement speed.
        /// </summary>
        float moveSpeed = 6;

        /// <summary>
        /// The gravitational force acting on the player.
        /// </summary>
        float gravity;
        /// <summary>
        /// The initial upward velocity applied when the player jumps.
        /// </summary>
        float jumpVelocity;
        /// <summary>
        /// The player's current velocity.
        /// </summary>
        UnityEngine.Vector3 velocity;
        /// <summary>
        /// A smoothing value for horizontal velocity changes.
        /// </summary>
        float velocityXSmoothing;

        /// <summary>
        /// A reference to the Controller2D component, responsible for collision detection and movement.
        /// </summary>
        Controller2D controller;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Initializes gravity, jump velocity, and the Controller2D component.
        /// </summary>
        void Start()
        {
            controller = GetComponent<Controller2D>();

            // Calculate gravity based on jump height and time to jump apex.
            gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
            // Calculate jump velocity based on gravity and time to jump apex.
            jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
            print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
        }

        /// <summary>
        /// Called every frame.
        /// Handles player input, movement, jumping, and interactions.
        /// </summary>
        void Update()
        {
            // Reset vertical velocity if there's a collision above or below.
            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
            }

            // Get horizontal and vertical input from the player.
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Handle jumping when the spacebar is pressed and the player is on the ground.
            if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
            {
                velocity.y = jumpVelocity;
            }

            // Calculate the target horizontal velocity based on input.
            float targetVelocityX = input.x * moveSpeed;
            // Smoothly adjust the player's horizontal velocity towards the target velocity.
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            // Apply gravity to the player's vertical velocity.
            velocity.y += gravity * Time.deltaTime;
            // Move the player using the calculated velocity and handle collisions.
            controller.Move(velocity * Time.deltaTime);

            // Handle interactions when the 'E' key is pressed.
            if (Input.GetKeyDown(KeyCode.E)) // Or any key of your choice
            {
                Interact();
            }
        }

        /// <summary>
        /// Handles player interactions with nearby objects that implement the Iinteract interface.
        /// </summary>
        void Interact()
        {
            // Debug log to indicate the start of interaction detection.
            Debug.Log("Buscando objetos interactivos...");
            // Perform a raycast in the direction the player is facing to detect interactable objects.
            //RaycastAll: This method is used to detect all objects within a specified distance that collide with a ray.
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(controller.collisions.left ? -1 : 1, 0), interactionDistance);

            // Iterate through each detected collision.
            foreach (RaycastHit2D hit in hits)
            {
                // Attempt to get the Iinteract component from the collided object.
                Iinteract interactable = hit.collider.GetComponent<Iinteract>();

                // If an interactable object is found.
                if (interactable != null)
                {
                    // Log the interaction for debugging.
                    Debug.Log("Interactuando con: " + hit.collider.gameObject.name);
                    // Call the Oninteract method of the interactable object.
                    interactable.Oninteract();
                    break; // Only interact with the first object found in the raycast.
                }
            }
        }
    }
}
