using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  WhiteRabbit.Core;
 namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// The C3DBox class represents a simple 3D box object in the game world that can be interacted with.
    /// It implements the Iinteract interface, allowing it to respond to player interactions.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Interactable Object:** Makes the 3D box interactable via the point-and-click or other interaction systems.
    /// 2. **Color Change:** Changes the color of the box randomly each time it's interacted with.
    /// 3. **Renderer Management:** Manages the box's visual appearance using its Renderer component.
    /// 4. **Debug Logging:** Logs a message to the console upon interaction for debugging and feedback.
    /// 
    /// **How It Works:**
    /// - This script is intended to be attached to a 3D GameObject (e.g., a cube) in a Unity scene.
    /// - The GameObject must have a Renderer component (e.g., Mesh Renderer) to allow color changes.
    /// - When the player interacts with the box (e.g., by clicking on it), the `Oninteract` method is called.
    /// - `Oninteract` generates a random color and assigns it to the box's material.
    /// - It also logs a message to the console to indicate that the interaction occurred.
    /// 
    /// **How to Use:**
    /// 1. **Create a 3D Box:** In your Unity scene, create a 3D object (e.g., a Cube) using GameObject -> 3D Object -> Cube.
    /// 2. **Add the Script:** Add this `C3DBox` script as a component to the 3D box GameObject.
    /// 3. **Ensure Renderer:** Make sure the object has a Renderer component (like Mesh Renderer) attached. This is usually added automatically when creating 3D objects.
    /// 4. **Add collider:** Make sure that the object has a collider to be detect with the interaction system.
    /// 5. **Interact:** Run the game and interact with the box. Each interaction will change its color.
    /// 
    /// **Example Use Cases:**
    /// - **Interactive Elements:** Use this as a basis for creating interactive objects that change their appearance upon interaction.
    /// - **Feedback Mechanisms:** Provide visual feedback to the player when they interact with an object.
    /// - **Simple Puzzles:** Create a simple puzzle where the player has to change the color of multiple boxes in a certain way.
    /// - **Testing:** It can be used to test the interaction system.
    /// 
    /// **Future Improvements:**
    /// - **More Complex Changes:** Implement more complex visual changes beyond just color (e.g., texture changes, scaling).
    /// - **Interaction Effects:** Add particle effects, sounds, or other visual feedback when the box is interacted with.
    /// - **Conditional Changes:** Make the color change or other effects dependent on game state or player actions.
    /// - **Multiple interactions**: Add multiple interactions.
    /// 
    /// **Current Limitations:**
    /// - **Basic Interaction:** The only interaction is to change the color randomly.
    /// - **No Audio:** No sound feedback is provided.
    /// - **Only one action**: only interact, there is no other posibility of action.
    /// </summary>
public class C3DBox : MonoBehaviour, Iinteract
{
   private Renderer rend; // Reference to the Renderer component
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It gets the Renderer component of the object to allow color manipulation.
    /// </summary>
    public void Awake()
    {

        rend = GetComponent<Renderer>();
    }
     /// <summary>
    /// This method is called when the player interacts with this object.
    /// It changes the color of the object to a random color and logs a message to the console.
    /// </summary>
     public void Oninteract()
    {
        // Get a random color from the array
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        // Set the object's color to the random color
        rend.material.color = randomColor;

        Debug.Log("Estoy Interactuando");
    }

    public void OnStopInteract()
    {
        // This line of code will print the "Texto" value to the console.
        Debug.Log("Estoy dejando de interactuar");
    }
}

}
