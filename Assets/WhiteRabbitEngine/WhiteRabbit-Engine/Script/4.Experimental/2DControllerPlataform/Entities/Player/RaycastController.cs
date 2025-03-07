using UnityEngine;
using System.Collections;

 namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// RaycastController is a base class for handling raycast-based collision detection.
    /// It sets up the necessary parameters for raycasting, such as the number of rays, spacing,
    /// and origin points around a BoxCollider2D. This class does not perform the raycasts itself
    /// but provides the infrastructure for derived classes to use.
    ///
    /// **Key Features:**
    /// 1. **Raycast Setup:** Manages the setup of raycast origins and spacing for both horizontal and vertical rays.
    /// 2. **Collision Mask:** Uses a LayerMask to filter which layers the raycasts should collide with.
    /// 3. **Skin Width:** Implements a 'skin width' to avoid self-collisions and ensure proper collision detection at edges.
    /// 4. **Ray Density:** Allows adjustment of the number of horizontal and vertical rays for varying levels of precision.
    /// 5. **Extensibility:** Designed to be inherited, providing a foundation for more complex collision detection logic.
    ///
    /// **How it Works:**
    /// - **Raycast Origins:** Defines four origin points (top-left, top-right, bottom-left, bottom-right) around the BoxCollider2D.
    /// - **Ray Spacing:** Calculates uniform spacing between rays based on the collider's dimensions and the desired ray count.
    /// - **Collision Filtering:** The `collisionMask` determines which layers are considered for collisions.
    /// - **Skin Width:** A small offset (`skinWidth`) that is applied to the collider's bounds to prevent rays from colliding with the object itself.
    /// - **Ray Count:** `horizontalRayCount` and `verticalRayCount` define the number of rays in each direction.
    /// - **Update Origins:** `UpdateRaycastOrigins` recalculates the ray origin points when the collider's bounds change.
    /// - **Calculate Spacing:** `CalculateRaySpacing` recomputes the spacing between rays when the collider's dimensions or ray count changes.
    ///
    /// **How to Use:**
    /// 1. **Attach to GameObject:** Add this script to a GameObject with a `BoxCollider2D`.
    /// 2. **Set Collision Mask:** In the Inspector, set the `collisionMask` to specify collision layers.
    /// 3. **Adjust Ray Count (Optional):** Modify `horizontalRayCount` and `verticalRayCount` to control ray density.
    ///     - More rays increase precision but might impact performance.
    /// 4. **Inherit:** Create a new class that derives from `RaycastController` to add specific raycasting logic.
    ///     - Use `UpdateRaycastOrigins()` and the `raycastOrigins` to perform raycasts.
    ///     - Use `CalculateRaySpacing()` if you change the collider's bounds or the ray counts.
    ///
    /// **Example Use Cases:**
    /// - **Platformer Collision:** Detecting collisions with walls, floors, and ceilings.
    /// - **Object Detection:** Checking for nearby objects.
    /// - **Slope Detection:** Identifying and handling slopes in platformer games.
    ///
    /// **Limitations:**
    /// - Does not perform raycasting directly; it only sets up the raycasting parameters.
    /// - Requires a `BoxCollider2D` component on the same GameObject.
    /// </summary>
[RequireComponent (typeof (BoxCollider2D))]
public class RaycastController : MonoBehaviour {

	/// <summary>
	/// Layer mask defining which layers should be considered for collisions.
	/// </summary>
	public LayerMask collisionMask;
	
	/// <summary>
	/// Small offset to prevent raycasts from colliding with the object itself.
	/// </summary>
	public const float skinWidth = .015f;
	/// <summary>
	/// Number of horizontal rays used for collision detection.
	/// </summary>
	public int horizontalRayCount = 4;
	/// <summary>
	/// Number of vertical rays used for collision detection.
	/// </summary>
	public int verticalRayCount = 4;

	/// <summary>
	/// Spacing between horizontal rays.
	/// </summary>
	[HideInInspector]
	public float horizontalRaySpacing;
	/// <summary>
	/// Spacing between vertical rays.
	/// </summary>
	[HideInInspector]
	public float verticalRaySpacing;

	/// <summary>
	/// Reference to the BoxCollider2D component.
	/// </summary>
	[HideInInspector]
	public new BoxCollider2D collider;
	/// <summary>
	/// Struct to store the origins of the rays.
	/// </summary>
	public RaycastOrigins raycastOrigins;

    /// <summary>
    /// Initializes the collider and calculates the ray spacing.
    /// Called when the script is loaded.
    /// </summary>
	public virtual void Start() {
		collider = GetComponent<BoxCollider2D> ();
		CalculateRaySpacing ();
	}

    /// <summary>
    /// Updates the origins of the rays based on the current bounds of the collider.
    /// Must be called whenever the collider's bounds change.
    /// </summary>
	public void UpdateRaycastOrigins() {
        //Get the bounds of the collider.
		Bounds bounds = collider.bounds;
        //Reduce the bounds by the skinWidth to prevent raycasts from colliding with the object itself.
		bounds.Expand (skinWidth * -2);
		
        // Define the four corners of the raycast area.
		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}
	
    /// <summary>
    /// Calculates the spacing between rays based on the collider's bounds and the number of rays.
    /// Must be called whenever the collider's bounds or ray counts change.
    /// </summary>
	public void CalculateRaySpacing() {
        //Get the bounds of the collider.
		Bounds bounds = collider.bounds;
        //Reduce the bounds by the skinWidth.
		bounds.Expand (skinWidth * -2);
		
        //Ensure there are at least 2 rays in each direction.
		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);
		
        //Calculate the spacing between horizontal rays.
		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        //Calculate the spacing between vertical rays.
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}
	
    /// <summary>
    /// Struct to store the origins of the rays.
    /// </summary>
	public struct RaycastOrigins {
        /// <summary>
        /// Top-left corner of the raycast area.
        /// </summary>
		public Vector2 topLeft,
        /// <summary>
        /// Top-right corner of the raycast area.
        /// </summary>
        topRight;
        /// <summary>
        /// Bottom-left corner of the raycast area.
        /// </summary>
		public Vector2 bottomLeft,
        /// <summary>
        /// Bottom-right corner of the raycast area.
        /// </summary>
        bottomRight;
	}
}
}

