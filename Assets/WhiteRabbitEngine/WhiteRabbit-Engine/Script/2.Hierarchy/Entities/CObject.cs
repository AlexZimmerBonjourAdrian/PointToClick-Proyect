using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.Hierarchy
{
    /// <summary>
    /// The CObject class represents a specific type of interactive object within the game world.
    /// It inherits from CGenericObject, providing a base set of properties, and implements the Iinteract interface,
    /// enabling it to respond to player interactions.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Specific Object Representation:** Represents a concrete, interactive object in the game world.
    /// 2. **Inherits from CGenericObject:** Inherits common properties like `id`, `name`, `descripcion`, `imageItem`, `optional`, and `isActive`.
    /// 3. **Implements Iinteract:** Allows the object to be interacted with via the point-and-click system.
    /// 4. **Custom Interaction Logic:** Defines how this specific object should behave when interacted with (e.g., displaying text).
    /// 5. **Example Functionality:** Includes an example implementation that logs text to the console when interacted with.
    /// 6. **Manage a text**: hold a text to show when it is interact.
    /// 
    /// **How It Works:**
    /// - This script is intended to be attached to a GameObject in a Unity scene.
    /// - The GameObject represents an interactive object in the game.
    /// - It inherits properties from `CGenericObject`, like a unique identifier (`id`) and a name (`name`).
    /// - When the player interacts with this object (e.g., by clicking on it), the `Oninteract` method is called.
    /// - The `Oninteract` method in this example logs a predefined text string to the console.
    /// - This class can be easily extended to include more complex interaction logic or unique properties.
    /// 
    /// **How to Use:**
    /// 1. **Create an Object:** Create a GameObject in your Unity scene to represent the interactive object.
    /// 2. **Add the Component:** Add this `CObject` script as a component to the object GameObject.
    /// 3. **Set Parameters:**
    ///     - In the Inspector, fill out the fields inherited from `CGenericObject` (e.g., `id`, `name`, `descripcion`, `imageItem`, `optional`, `isActive`).
    ///     - In the inspector, add a text in the field "Texto" to be display in the console.
    /// 4. **Configure Collider:** Ensure the object has a collider component (e.g., Box Collider 2D) to detect player interactions.
    /// 5. **Extend Logic:** Modify the `Oninteract` method to implement custom interaction behavior.
    /// 6. **Interact:** The object now can be interact with the point to click system.
    /// 
    /// **Example Use Cases:**
    /// - **Examining Objects:** Create objects that display descriptive text when examined.
    /// - **Simple Interactions:** Create interactive objects that trigger basic actions (e.g., opening a door).
    /// - **Clue Display:** Create an object that, when interacted with, displays a clue or a piece of information.
    /// - **Scene elements:** Create an object to manage a element of a scene.
    /// 
    /// **Future Improvements:**
    /// - **Advanced Interactions:** Implement more complex logic within `Oninteract` (e.g., playing animations, triggering events, checking player inventory).
    /// - **Custom Properties:** Add more specific properties to this class to further define the object's behavior and attributes.
    /// - **Visual Effects:** Add visual feedback when the object is interacted with.
    /// - **Different Action:** Add more posibility to the interact action.
    /// 
    /// **Current Limitations:**
    /// - **Basic Interaction:** The default interaction is limited to logging text to the console.
    /// - **No Visual Feedback:** It does not provide any visual feedback when the player interacts with it.
    /// - **Only one action:** Only one action in the interact function.
    /// </summary>
    public class CObject : CGenericObject, Iinteract
    {
        //Example Object
        /// <summary>
        /// This string holds the text that will be display in the console when the object is interact.
        /// </summary>
        [SerializeField]
        private string Texto = " ";
        /// <summary>
        /// This method is called when the player interacts with this object.
        /// When the player click in this object, this method will be call.
        /// </summary>
        public void Oninteract()
        {
            // This line of code will print the "Texto" value to the console.
            Debug.Log(Texto);
        }
    }
}
