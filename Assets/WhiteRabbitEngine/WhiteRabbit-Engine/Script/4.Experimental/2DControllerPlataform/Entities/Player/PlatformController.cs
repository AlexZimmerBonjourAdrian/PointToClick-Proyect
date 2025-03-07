using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// PlatformController is responsible for moving a platform and handling passengers (other objects) that are on it.
    /// It uses raycasts to detect when passengers are on the platform and then moves them along with the platform.
    /// </summary>
    public class PlatformController : RaycastController
    {
        /// <summary>
        /// LayerMask that specifies which layers should be considered as passengers (e.g., the player).
        /// </summary>
        public LayerMask passengerMask;

        /// <summary>
        /// The movement vector of the platform per second.
        /// </summary>
        public Vector3 move;

        /// <summary>
        /// List to store information about the passengers that need to be moved.
        /// </summary>
        List<PassengerMovement> passengerMovement;

        /// <summary>
        /// Dictionary to store passenger Controller2D for faster access.
        /// Key: passenger transform.
        /// Value: passenger Controller2D.
        /// </summary>
        Dictionary<Transform, Controller2D> passengerDictionary = new Dictionary<Transform, Controller2D>();

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Calls the base Start() method to initialize the raycasting.
        /// </summary>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Called every frame.
        /// Updates the platform's position and moves passengers accordingly.
        /// </summary>
        void Update()
        {
            // Update the raycast origins based on the platform's collider.
            UpdateRaycastOrigins();

            // Calculate the platform's velocity for this frame.
            Vector3 velocity = move * Time.deltaTime;

            // Calculate which passengers should move and how.
            CalculatePassengerMovement(velocity);

            // Move the passengers before moving the platform.
            MovePassengers(true);

            // Move the platform.
            transform.Translate(velocity);

            // Move the passengers after moving the platform to correct positions.
            MovePassengers(false);
        }

        /// <summary>
        /// Moves the passengers based on the calculated passengerMovement list.
        /// </summary>
        /// <param name="beforeMovePlatform">
        /// If true, moves the passengers before the platform moves.
        /// If false, moves the passengers after the platform moves.
        /// </param>
        void MovePassengers(bool beforeMovePlatform)
        {
            // Iterate through each passenger in the passengerMovement list.
            foreach (PassengerMovement passenger in passengerMovement)
            {
                // If the passenger is not in the dictionary, add it.
                if (!passengerDictionary.ContainsKey(passenger.transform))
                {
                    passengerDictionary.Add(passenger.transform, passenger.transform.GetComponent<Controller2D>());
                }

                // If the passenger should move before the platform, or after, based on beforeMovePlatform.
                if (passenger.moveBeforePlatform == beforeMovePlatform)
                {
                    // Move the passenger using its Controller2D.
                    passengerDictionary[passenger.transform].Move(passenger.velocity, passenger.standingOnPlatform);
                }
            }
        }

        /// <summary>
        /// Calculates the movement required for each passenger based on the platform's velocity and raycast hits.
        /// </summary>
        /// <param name="velocity">The platform's current velocity.</param>
        void CalculatePassengerMovement(Vector3 velocity)
        {
            // HashSet to store passengers that have already been moved, to prevent moving them multiple times.
            HashSet<Transform> movedPassengers = new HashSet<Transform>();
            // Clear the passenger movement list to calculate it again.
            passengerMovement = new List<PassengerMovement>();

            // Determine the movement direction.
            float directionX = Mathf.Sign(velocity.x);
            float directionY = Mathf.Sign(velocity.y);

            // Vertically moving platform
            if (velocity.y != 0)
            {
                // Calculate the length of the raycast.
                float rayLength = Mathf.Abs(velocity.y) + skinWidth;

                // Cast rays vertically to detect passengers.
                for (int i = 0; i < verticalRayCount; i++)
                {
                    // Determine the ray's origin based on the direction of movement.
                    Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                    rayOrigin += Vector2.right * (verticalRaySpacing * i);
                    // Cast the ray and check for a collision.
                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

                    // If a collision is detected.
                    if (hit)
                    {
                        // If the passenger has not been moved yet.
                        if (!movedPassengers.Contains(hit.transform))
                        {
                            // Add the passenger to the moved list.
                            movedPassengers.Add(hit.transform);
                            // If the platform is going up, take into account the velocity x, else dont.
                            float pushX = (directionY == 1) ? velocity.x : 0;
                            // Calculate the y movement, substracting the distance to the hit.
                            float pushY = velocity.y - (hit.distance - skinWidth) * directionY;

                            // Add the passenger movement to the list.
                            passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), directionY == 1, true));
                        }
                    }
                }
            }

            // Horizontally moving platform
            if (velocity.x != 0)
            {
                // Calculate the length of the raycast.
                float rayLength = Mathf.Abs(velocity.x) + skinWidth;

                // Cast rays horizontally to detect passengers.
                for (int i = 0; i < horizontalRayCount; i++)
                {
                    // Determine the ray's origin based on the direction of movement.
                    Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                    rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                    // Cast the ray and check for a collision.
                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, passengerMask);

                    // If a collision is detected.
                    if (hit)
                    {
                        // If the passenger has not been moved yet.
                        if (!movedPassengers.Contains(hit.transform))
                        {
                            // Add the passenger to the moved list.
                            movedPassengers.Add(hit.transform);
                             // Calculate the x movement, substracting the distance to the hit.
                            float pushX = velocity.x - (hit.distance - skinWidth) * directionX;
                            // In this case, the pushY is the skinwidth negative.
                            float pushY = -skinWidth;

                            // Add the passenger movement to the list.
                            passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), false, true));
                        }
                    }
                }
            }

            // Passenger on top of a horizontally or downward moving platform
            if (directionY == -1 || (velocity.y == 0 && velocity.x != 0))
            {
                // Set the ray length.
                float rayLength = skinWidth * 2;

                // Cast rays vertically from the top of the platform to detect passengers above.
                for (int i = 0; i < verticalRayCount; i++)
                {
                    // Define the ray origin.
                    Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
                    // Cast the ray and check for a collision.
                    RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

                    // If a collision is detected.
                    if (hit)
                    {
                        // If the passenger has not been moved yet.
                        if (!movedPassengers.Contains(hit.transform))
                        {
                            // Add the passenger to the moved list.
                            movedPassengers.Add(hit.transform);
                            // The push will be the platform velocity.
                            float pushX = velocity.x;
                            float pushY = velocity.y;

                            // Add the passenger movement to the list.
                            passengerMovement.Add(new PassengerMovement(hit.transform, new Vector3(pushX, pushY), true, false));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Struct to store information about a passenger's movement.
        /// </summary>
        struct PassengerMovement
        {
            /// <summary>
            /// The passenger's transform.
            /// </summary>
            public Transform transform;

            /// <summary>
            /// The passenger's velocity.
            /// </summary>
            public Vector3 velocity;

            /// <summary>
            /// Whether the passenger is standing on the platform.
            /// </summary>
            public bool standingOnPlatform;

            /// <summary>
            /// Whether the passenger should move before the platform or not.
            /// </summary>
            public bool moveBeforePlatform;

            /// <summary>
            /// Constructor for PassengerMovement.
            /// </summary>
            /// <param name="_transform">The passenger's transform.</param>
            /// <param name="_velocity">The passenger's velocity.</param>
            /// <param name="_standingOnPlatform">Whether the passenger is standing on the platform.</param>
            /// <param name="_moveBeforePlatform">Whether the passenger should move before the platform.</param>
            public PassengerMovement(Transform _transform, Vector3 _velocity, bool _standingOnPlatform, bool _moveBeforePlatform)
            {
                transform = _transform;
                velocity = _velocity;
                standingOnPlatform = _standingOnPlatform;
                moveBeforePlatform = _moveBeforePlatform;
            }
        }

    }
}
