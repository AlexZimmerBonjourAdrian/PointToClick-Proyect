using UnityEngine;
using System.Collections;

 namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// CRayController is a base class for objects that need to perform raycasting
    /// to detect collisions or check for the presence of other objects in a 2D environment.
    /// It sets up and manages the raycasting system, which can be further customized by derived classes.
    ///
    /// **Key Responsibilities:**
    /// 1. **Raycast System Setup:** Initializes the raycasting setup by calculating ray origins and spacing.
    /// 2. **Collision Detection:** Provides a `LayerMask` to define which layers should be considered for collisions.
    /// 3. **Ray Origin Management:** Manages the origins of the raycasts based on the object's `BoxCollider2D`.
    /// 4. **Ray Spacing Calculation:** Calculates the spacing between horizontal and vertical rays to ensure uniform coverage.
    /// 5. **Extensibility:** Designed to be inherited from, allowing subclasses to implement specific raycasting logic.
    ///
    /// **How it Works:**
    /// - **Ray Origins:** The class defines four ray origins (top-left, top-right, bottom-left, bottom-right) based on the object's `BoxCollider2D`.
    /// - **Ray Spacing:** It divides the collider's height and width by the number of horizontal and vertical rays, respectively, to determine the spacing between rays.
    /// - **Collision Detection:** The `collisionMask` is used to filter which layers should be considered for collisions.
    /// - **Skin Width:** `skinWidth` is a small offset used to prevent raycasts from colliding with the object itself.
    /// - **Raycast Number:** the numbers of raycast are define by `horizontalRayCount` and `verticalRayCount`
    /// - **Update Raycast origins:** Each time that is necesary, we need to update the origins, usign the method `UpdateRaycastOrigins`
    /// - **Calculate Ray spacing:** Each time that is necesary, we need to recalculate the spacing, using the method `CalculateRaySpacing`
    ///
    /// **How to Use:**
    /// 1. **Attach to GameObject:** Attach this script to a GameObject that requires raycasting.
    /// 2. **Set Collision Mask:** In the Inspector, set the `collisionMask` to define which layers to check for collisions.
    /// 3. **Adjust Ray Count (Optional):** Modify `horizontalRayCount` and `verticalRayCount` to change the density of the rays.
    ///     - More rays means more precision but potentially higher performance cost.
    /// 4. **Inherit and Extend:** Create a new class that inherits from `CRayController` to implement specific raycasting logic.
    ///     - Override methods or add new ones to use the calculated ray origins and spacing.
    /// 5. **Get Information:** you can get the origins of the ray cast, or the spacement using the variables.
    /// 
    /// **Example Use Cases:**
    /// - **Platformer Character Collision:** Detect collisions with walls, floors, and ceilings.
    /// - **Object Detection:** Check for the presence of other objects within a certain range.
    /// - **Line of Sight:** Determine if a character has line of sight to another object.
    /// 
    /// **Future Improvements:**
    /// - Add methods to perform the raycast and check for collisions.
    /// - Add a function to visualize the raycast in the editor.
    /// - Add more customization for the raycast parameters.
    /// 
    /// **Current Limitations:**
    /// - Does not perform any raycasting. It only sets up the system.
    /// - It only works with `BoxCollider2D`.
    /// </summary>
[RequireComponent(typeof(BoxCollider2D))] // Ensure that a BoxCollider2D component is attached to the GameObject.
public class CRayController : MonoBehaviour
{

	public LayerMask collisionMask; // LayerMask to define which layers to check for collisions.

	public const float skinWidth = .015f; // Small offset to prevent raycasts from colliding with the object itself.
	public int horizontalRayCount = 4; // Number of horizontal rays.
	public int verticalRayCount = 4; // Number of vertical rays.

	[HideInInspector]
	public float horizontalRaySpacing; // Spacing between horizontal rays.
	[HideInInspector]
	public float verticalRaySpacing; // Spacing between vertical rays.

	[HideInInspector]
	public new BoxCollider2D collider; // Reference to the BoxCollider2D component.
	public RaycastOrigins raycastOrigins; // Structure to store the origins of the rays.

    /// <summary>
    /// Start is called before the first frame update.
    /// Initializes the collider and calculates the ray spacing.
    /// </summary>
	public virtual void Start()
	{
		collider = GetComponent<BoxCollider2D>(); // Get the BoxCollider2D component.
		CalculateRaySpacing(); // Calculate the spacing between rays.
	}

    /// <summary>
    /// UpdateRaycastOrigins updates the origins of the rays based on the current bounds of the collider.
    /// This should be called whenever the collider's bounds change.
    /// </summary>
	public void UpdateRaycastOrigins()
	{
		Bounds bounds = collider.bounds; // Get the bounds of the collider.
		bounds.Expand(skinWidth * -2); // Reduce the bounds by the skinWidth to prevent raycasts from colliding with the object itself.

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y); // Set the bottom-left origin.
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y); // Set the bottom-right origin.
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y); // Set the top-left origin.
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y); // Set the top-right origin.
	}

    /// <summary>
    /// CalculateRaySpacing calculates the spacing between rays based on the collider's bounds and the number of rays.
    /// </summary>
	public void CalculateRaySpacing()
	{
		Bounds bounds = collider.bounds; // Get the bounds of the collider.
		bounds.Expand(skinWidth * -2); // Reduce the bounds by the skinWidth.

		horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue); // Ensure there are at least 2 horizontal rays.
		verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue); // Ensure there are at least 2 vertical rays.

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1); // Calculate the horizontal spacing.
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1); // Calculate the vertical spacing.
	}

    /// <summary>
    /// RaycastOrigins is a struct to store the origins of the rays.
    /// </summary>
	public struct RaycastOrigins
	{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}
}
}
