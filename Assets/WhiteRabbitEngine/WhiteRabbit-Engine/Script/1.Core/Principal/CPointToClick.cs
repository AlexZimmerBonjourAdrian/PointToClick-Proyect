using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

 
 namespace WhiteRabbit.Core
  {

public class CPointToClick : MonoBehaviour
{
    // Define the possible states of the point-and-click interaction.
    private static int ACTIONSTATE_NONE = 0;       // No interaction is happening.
    private static int ACTIONSTATE_HOVE = 1;       // The mouse is hovering over an interactable object.
    private static int ACTIONSTATE_INTERACT = 2;   // The player has clicked to interact with the object.

    GameObject anyObject;                           // Reference to the currently detected object.
    private int _actionState;                       // Current state of the interaction.
    private Component _actionObj;                  // The Iinteract component of the object being interacted with.

    /// <summary>
    /// Singleton instance of the CPointToClick.
    /// Provides a global access point to the point-and-click functionality.
    /// </summary>
    public static CPointToClick Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CPointToClick component.
            if (_inst == null)
            {
                GameObject obj = new GameObject("PointMechanic");

                return obj.AddComponent<CPointToClick>();
            }
            return _inst;
        }
    }
    private static CPointToClick _inst;



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CPointToClick exists (Singleton pattern).
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
    /// It calls the InteractionPointToClick method to handle the point-and-click logic.
    /// </summary>
    void Update()
    {
        InteractionPointToClick();
    }

    /// <summary>
    /// Manages the point-and-click interaction logic.
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
            if (actionObj != null)
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
            // Check if the left mouse button is pressed.
            if (Input.GetKeyDown(KeyCode.Mouse0))
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
    /// Performs a raycast from the mouse position to detect colliders.
    /// </summary>
    /// <returns>The GameObject that the raycast hits, or null if no object is hit.</returns>
    private GameObject RayCollision()
    {


        
        // Convert the mouse position from screen space to world space.
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Perform a 2D raycast.
        RaycastHit2D hitinfo = Physics2D.Raycast(worldPoint, Vector2.zero);
        

        // Check if the raycast hits something.
        if (hitinfo.collider != null)
        {
            //  Debug.Log("Entra");
            // anyObject = Collider2D.;
            // (_actionObj as Iinteract).Oninteract();
            //Debug.Log(hitinfo.collider.gameObject.name);
            // If it hits something, get the object and return it.
            anyObject = hitinfo.collider.gameObject;
            return anyObject;
        }

        // If it doesn't hit anything, return null.
        return null;
    }

    /// <summary>
    /// Draws a gizmo sphere at the mouse position for debugging purposes.
    /// </summary>
    void OnDrawGizmos()
    {
        // Convert the mouse position to world space.
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        // Draw a sphere at the mouse position.
        Gizmos.DrawSphere(worldPoint, .3f);

    }

    /// <summary>
    /// This function is not used in this version.
    /// </summary>
    public void CreatePoint()
    {
        

    }
}
}
