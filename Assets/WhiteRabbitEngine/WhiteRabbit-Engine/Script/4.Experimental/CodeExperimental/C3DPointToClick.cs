using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// C3DPointToClick: A 3D point-and-click interaction manager.
    ///
    /// This class provides a mechanism for handling point-and-click interactions in a 3D environment.
    /// It uses raycasting to detect objects in the scene and allows interaction with objects that implement the Iinteract interface.
    ///
    /// **Key Features:**
    /// 1. **Singleton Pattern:** Ensures only one instance of C3DPointToClick exists.
    /// 2. **3D Raycasting:** Uses Physics.Raycast to detect objects in 3D space.
    /// 3. **Interaction States:** Manages three interaction states: None, Hover, and Interact.
    /// 4. **Iinteract Interface:** Interacts with objects that implement the Iinteract interface.
    /// 5. **Gizmo Visualization:** Draws a ray and a sphere in the Scene view to visualize the raycast and hit point.
    /// 6. **Persistence:** Persists across scene changes using DontDestroyOnLoad.
    /// 
    /// **How it Works:**
    /// 1. **Raycasting:** Each frame, a ray is cast from the mouse position into the 3D world.
    /// 2. **Collision Detection:** If the ray hits a collider, the script checks if the collided object has a component that implements the `Iinteract` interface.
    /// 3. **Interaction States:**
    ///     - **ACTIONSTATE_NONE (0):** No interaction is happening. The script looks for objects under the mouse.
    ///     - **ACTIONSTATE_HOVE (1):** The mouse is hovering over an interactable object (an object with a component that implements `Iinteract`).
    ///     - **ACTIONSTATE_INTERACT (2):** The player has pressed the interact key (default: 'E') while hovering over an object. The `Oninteract()` method of the `Iinteract` component is called.
    /// 4. **Interaction:** When the player interacts, the `Oninteract()` method of the `Iinteract` component on the object is called, triggering the object's interaction logic.
    /// 5. **State Transitions:** The script transitions between states based on mouse/key input and whether an interactable object is being hovered over.
    /// 
    /// **How to Use:**
    /// 1. **Add Iinteract:** Create objects in your scene that you want to be interactable. Add a script to each of these objects that implements the `Iinteract` interface.
    /// 2. **Implement Oninteract:** In your `Iinteract` script, implement the `Oninteract()` method to define what happens when the player interacts with the object.
    /// 3. **Interact Key:**  The default interact key is 'E'. When the user press this key and hover an object, the Oninteract method will be call.
    /// 4. **Run:** The C3DPointToClick class will manage all the interaction.
    ///
    /// **Future Improvements:**
    /// - Add support for different input methods (e.g., touch).
    /// - Add more complex interaction logic (e.g., double-click, hold).
    /// - Add events to notify other scripts when an interaction occurs.
    /// - Allow custom interaction keys.
    /// - Add support for differents layer mask.
    /// </summary>
    public class C3DPointToClick : MonoBehaviour
    {
        // Define the possible states of the point-and-click interaction.
        private static int ACTIONSTATE_NONE = 0;       // No interaction is happening.
        private static int ACTIONSTATE_HOVE = 1;       // The mouse is hovering over an interactable object.
        private static int ACTIONSTATE_INTERACT = 2;   // The player has pressed the interact key to interact with the object.

        GameObject anyObject;                           // Reference to the currently detected object.
        private int _actionState;                       // Current state of the interaction.
        private Component _actionObj;                  // The Iinteract component of the object being interacted with.

        /// <summary>
        /// Singleton instance of the C3DPointToClick.
        /// Provides a global access point to the 3D point-and-click functionality.
        /// </summary>
        public static C3DPointToClick Inst
        {
            get
            {
                // If the instance doesn't exist, create a new GameObject and add the C3DPointToClick component.
                if (_inst == null)
                {
                    GameObject obj = new GameObject("3DPointMechanic");

                    return obj.AddComponent<C3DPointToClick>();
                }
                return _inst;
            }
        }
        private static C3DPointToClick _inst;



        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// It ensures that only one instance of C3DPointToClick exists (Singleton pattern).
        /// It also ensures that this object will be no destroy when a new scene is load.
        /// </summary>
        public void Awake()
        {

            // If an instance already exists and it's not this one, destroy this one.
            if (_inst != null && _inst != this)
            {
                Destroy(gameObject);
                return;
            }
            //This line makes the GameObject persist across scene loads.
            DontDestroyOnLoad(this.gameObject);
            _inst = this;
        }
        
        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// It calls the InteractionPointToClick method to handle the 3D point-and-click logic.
        /// </summary>
        void Update()
        {
            InteractionPointToClick();
        }

        /// <summary>
        /// Manages the 3D point-and-click interaction logic.
        /// This method handles the detection of interactable objects, mouse hover, and mouse click events.
        /// It changes the _actionState to manage the differents state of the mechanic.
        /// </summary>
        public void InteractionPointToClick()
        {
            // State: No Interaction
            if (_actionState == ACTIONSTATE_NONE)
            {
                // Check for a collision with an interactable object.
                GameObject obj = RayCollision();
                if (obj == null)
                    return;

                // Check if the object has the Iinteract interface.
                Component actionObj = obj.GetComponent(typeof(Iinteract));
                if (actionObj != null && actionObj is Iinteract) // Check if the component implements Iinteract
                {
                    // If it has the interface, set the current action object and change the state.
                    _actionObj = actionObj;
                    _actionState = ACTIONSTATE_HOVE;
                }
            }
            // State: Hovering Over Object
            else if (_actionState == ACTIONSTATE_HOVE)
            {
                // Check for a collision again.
                GameObject obj = RayCollision();
                if (obj == null)
                {
                    // If no object is found, reset the action state and object.
                    _actionObj = null;
                    _actionState = ACTIONSTATE_NONE;
                    return;
                }

                // Check if the object has the Iinteract interface.
                Component actionObj = obj.GetComponent(typeof(Iinteract));
                if (actionObj == null)
                {
                    // If the object doesn't have the interface, reset the action state and object.
                    _actionObj = null;
                    _actionState = ACTIONSTATE_NONE;
                }
                // Check if the currently hover object is not the same as before.
                else if (actionObj != _actionObj)
                {
                    // If is different, update the _actionObj.
                    _actionObj = actionObj;
                }
                // Check if the interact key is pressed.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // If pressed, change the state to interact.
                    _actionState = ACTIONSTATE_INTERACT;
                }
            }
            // State: Interacting with Object
            else if (_actionState == ACTIONSTATE_INTERACT)
            {
                // Execute the Oninteract method of the Iinteract interface.
                (_actionObj as Iinteract).Oninteract();
                // Reset the action state and object after interaction.
                _actionState = ACTIONSTATE_NONE;
                _actionObj = null;
            }
        }

        /// <summary>
        /// Performs a raycast from the mouse position into the 3D world to detect colliders.
        /// </summary>
        /// <returns>The GameObject that the raycast hits, or null if no object is hit.</returns>
        private GameObject RayCollision()
        {

            // Convert the mouse position to a 3D ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Perform a 3D raycast
            RaycastHit hit;
            // Check if the raycast hits something.
            if (Physics.Raycast(ray, out hit))
            {
                // If it hits something, get the object and return it.
                anyObject = hit.collider.gameObject;
                return anyObject;
            }

            // If it doesn't hit anything, return null.
            return null;
        }

        /// <summary>
        /// Draws the raycast and the hit point in the Scene view for debugging purposes.
        /// </summary>
        private void OnDrawGizmos()
        {
            // Convert the mouse position to a 3D ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Draw the raycast in the Gizmo
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * 10f); // Draw the ray up to 10 units in distance

            // Draw a sphere at the hit point if there is one
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(hit.point, 0.2f); // Draw a green sphere at the hit point
            }
        }
        
        /// <summary>
        /// This function is not used in this version.
        /// </summary>
        public void CreatePoint()
        {
            //This function do not do anything.

        }
    }
}
