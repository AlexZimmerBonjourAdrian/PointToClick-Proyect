using UnityEngine;
using System.Collections;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// This class is responsible for handling 2D collisions and movement for a character in a platformer-style game.
    /// It uses raycasts to detect collisions with the environment and provides functionality for climbing and descending slopes.
    /// </summary>
    public class Controller2D : RaycastController
    {
        /// <summary>
        /// The maximum angle (in degrees) that the character can climb.
        /// </summary>
        float maxClimbAngle = 80;

        /// <summary>
        /// The maximum angle (in degrees) that the character can descend.
        /// </summary>
        float maxDescendAngle = 80;

        /// <summary>
        /// Struct to hold collision information for the character.
        /// </summary>
        public CollisionInfo collisions;


        /// <summary>
        /// Called when the script instance is being loaded.
        /// Calls the base Start() method.
        /// </summary>
        public override void Start()
        {
            base.Start();
        }

        /// <summary>
        /// Moves the character based on the provided velocity, handling collisions and slopes.
        /// </summary>
        /// <param name="velocity">The desired movement velocity.</param>
        /// <param name="standingOnPlatform">Whether the character is standing on a moving platform.</param>
        public void Move(Vector3 velocity, bool standingOnPlatform = false)
        {
            // Update the raycast origins based on the character's collider.
            UpdateRaycastOrigins();
            // Reset collision information for this frame.
            collisions.Reset();
            // Store the old velocity for slope handling.
            collisions.velocityOld = velocity;

            // If the character is moving downwards, check for descending slopes.
            if (velocity.y < 0)
            {
                DescendSlope(ref velocity);
            }
            // If the character is moving horizontally, check for horizontal collisions.
            if (velocity.x != 0)
            {
                HorizontalCollisions(ref velocity);
            }
            // If the character is moving vertically, check for vertical collisions.
            if (velocity.y != 0)
            {
                VerticalCollisions(ref velocity);
            }

            // Apply the calculated movement to the character's transform.
            transform.Translate(velocity);

            // If standing on a platform, set the 'below' collision flag.
            if (standingOnPlatform)
            {
                collisions.below = true;
            }
        }

        /// <summary>
        /// Handles horizontal collisions, including climbing slopes.
        /// </summary>
        /// <param name="velocity">The character's current velocity (will be modified).</param>
        void HorizontalCollisions(ref Vector3 velocity)
        {
            // Determine the direction of movement (left or right).
            float directionX = Mathf.Sign(velocity.x);
            // Calculate the ray length to cast.
            float rayLength = Mathf.Abs(velocity.x) + skinWidth;

            // Cast rays horizontally to check for collisions.
            for (int i = 0; i < horizontalRayCount; i++)
            {
                // Determine the ray's origin based on the direction of movement.
                Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                // Cast the ray and check for a collision.
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

                // Visualize the ray in the scene view (for debugging).
                Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

                // If a collision is detected.
                if (hit)
                {
                    // If the ray hit something at distance 0, continue to the next ray. (avoid collision with the self object).
                    if (hit.distance == 0)
                    {
                        continue;
                    }

                    // Calculate the angle of the slope.
                    float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

                    // If this is the first ray and the slope is within the climbable range.
                    if (i == 0 && slopeAngle <= maxClimbAngle)
                    {
                        // If previously descending a slope, reset and use the old velocity.
                        if (collisions.descendingSlope)
                        {
                            collisions.descendingSlope = false;
                            velocity = collisions.velocityOld;
                        }
                        // Calculate distance to the start of the slope.
                        float distanceToSlopeStart = 0;
                        if (slopeAngle != collisions.slopeAngleOld)
                        {
                            distanceToSlopeStart = hit.distance - skinWidth;
                            velocity.x -= distanceToSlopeStart * directionX;
                        }
                        // Handle climbing the slope.
                        ClimbSlope(ref velocity, slopeAngle);
                        velocity.x += distanceToSlopeStart * directionX;
                    }

                    // If not climbing a slope or the slope is too steep.
                    if (!collisions.climbingSlope || slopeAngle > maxClimbAngle)
                    {
                        // Adjust the horizontal velocity based on the collision.
                        velocity.x = (hit.distance - skinWidth) * directionX;
                        rayLength = hit.distance;

                        // Adjust vertical velocity if climbing a slope.
                        if (collisions.climbingSlope)
                        {
                            velocity.y = Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(velocity.x);
                        }

                        // Update collision flags.
                        collisions.left = directionX == -1;
                        collisions.right = directionX == 1;
                    }
                }
            }
        }

        /// <summary>
        /// Handles vertical collisions, including descending and adjusting for slopes.
        /// </summary>
        /// <param name="velocity">The character's current velocity (will be modified).</param>
        void VerticalCollisions(ref Vector3 velocity)
        {
            // Determine the vertical direction of movement (up or down).
            float directionY = Mathf.Sign(velocity.y);
            // Calculate the ray length to cast.
            float rayLength = Mathf.Abs(velocity.y) + skinWidth;

            // Cast rays vertically to check for collisions.
            for (int i = 0; i < verticalRayCount; i++)
            {
                // Determine the ray origin based on the direction of movement.
                Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x); //adjusting the position of the ray depending on the x velocity.
                // Cast the ray and check for a collision.
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

                // Visualize the ray in the scene view (for debugging).
                Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

                // If a collision is detected.
                if (hit)
                {
                    // Adjust the vertical velocity based on the collision.
                    velocity.y = (hit.distance - skinWidth) * directionY;
                    rayLength = hit.distance;

                    // Adjust horizontal velocity if climbing a slope.
                    if (collisions.climbingSlope)
                    {
                        velocity.x = velocity.y / Mathf.Tan(collisions.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(velocity.x);
                    }

                    // Update collision flags.
                    collisions.below = directionY == -1;
                    collisions.above = directionY == 1;
                }
            }

            // Check if still climbing a slope after vertical collision checks.
            if (collisions.climbingSlope)
            {
                float directionX = Mathf.Sign(velocity.x);
                rayLength = Mathf.Abs(velocity.x) + skinWidth;
                // Define the ray origin based on the movement direction.
                Vector2 rayOrigin = ((directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight) + Vector2.up * velocity.y;
                // Raycast to detect collisions on the side of the slope.
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

                // If a collision is detected.
                if (hit)
                {
                    float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                    // If the slope angle has changed, update the velocity and the slope angle.
                    if (slopeAngle != collisions.slopeAngle)
                    {
                        velocity.x = (hit.distance - skinWidth) * directionX;
                        collisions.slopeAngle = slopeAngle;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the character climbing a slope.
        /// </summary>
        /// <param name="velocity">The character's current velocity (will be modified).</param>
        /// <param name="slopeAngle">The angle of the slope being climbed.</param>
        void ClimbSlope(ref Vector3 velocity, float slopeAngle)
        {
            // Calculate the distance to move along the slope.
            float moveDistance = Mathf.Abs(velocity.x);
            // Calculate the vertical velocity needed to climb the slope.
            float climbVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

            // If the current vertical velocity is less than or equal to the required climbing velocity.
            if (velocity.y <= climbVelocityY)
            {
                // Set the vertical velocity to climb.
                velocity.y = climbVelocityY;
                // Calculate the horizontal velocity based on the slope angle.
                velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
                // Update collision information.
                collisions.below = true;
                collisions.climbingSlope = true;
                collisions.slopeAngle = slopeAngle;
            }
        }

        /// <summary>
        /// Handles the character descending a slope.
        /// </summary>
        /// <param name="velocity">The character's current velocity (will be modified).</param>
        void DescendSlope(ref Vector3 velocity)
        {
            // Determine the horizontal movement direction.
            float directionX = Mathf.Sign(velocity.x);
            // Set the origin of the raycast depending on the direction.
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;
            // Perform a raycast downwards to find a slope.
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.up, Mathf.Infinity, collisionMask);

            // If a collision is detected.
            if (hit)
            {
                // Get the angle of the slope.
                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
                // Check if it's a valid slope to descend.
                if (slopeAngle != 0 && slopeAngle <= maxDescendAngle)
                {
                    // If the slope is in the same direction as the movement.
                    if (Mathf.Sign(hit.normal.x) == directionX)
                    {
                        // Check if we are close enough to the slope to descend it.
                        if (hit.distance - skinWidth <= Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(velocity.x))
                        {
                            // Calculate the distance to move along the slope.
                            float moveDistance = Mathf.Abs(velocity.x);
                            // Calculate the vertical velocity to descend the slope.
                            float descendVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;
                            // Calculate the horizontal velocity based on the slope angle.
                            velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
                            // Substract the vertical velocity.
                            velocity.y -= descendVelocityY;

                            // Update collision information.
                            collisions.slopeAngle = slopeAngle;
                            collisions.descendingSlope = true;
                            collisions.below = true;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Struct to store collision information.
        /// </summary>
        public struct CollisionInfo
        {
            /// <summary>
            /// True if there is a collision above the character.
            /// </summary>
            public bool above;
            /// <summary>
            /// True if there is a collision below the character.
            /// </summary>
            public bool below;
            /// <summary>
            /// True if there is a collision to the left of the character.
            /// </summary>
            public bool left;
            /// <summary>
            /// True if there is a collision to the right of the character.
            /// </summary>
            public bool right;

            /// <summary>
            /// True if the character is climbing a slope.
            /// </summary>
            public bool climbingSlope;
            /// <summary>
            /// True if the character is descending a slope.
            /// </summary>
            public bool descendingSlope;
            /// <summary>
            /// The current angle of the slope the character is on.
            /// </summary>
            public float slopeAngle;
            /// <summary>
            /// The previous angle of the slope the character was on.
            /// </summary>
            public float slopeAngleOld;
            /// <summary>
            /// The character's old velocity from the previous frame.
            /// </summary>
            public Vector3 velocityOld;

            /// <summary>
            /// Resets all collision flags and slope information.
            /// </summary>
            public void Reset()
            {
                above = below = false;
                left = right = false;
                climbingSlope = false;
                descendingSlope = false;

                slopeAngleOld = slopeAngle;
                slopeAngle = 0;
            }
        }

    }
}
