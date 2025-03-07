using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace WhiteRabbit.Hierarchy
{
    /// <summary>
    /// The CGenericObject class represents a generic object within the game world.
    /// It serves as a base class for creating various types of interactive or non-interactive objects.
    /// This class provides common properties and functionality that are shared across different object types.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Object Representation:** Acts as a component to represent a generic object in the game.
    /// 2. **Unique Identification:** Assigns a unique ID (`id`) to each object for referencing purposes.
    /// 3. **Name and Description:** Stores the object's name (`name`) and a brief description (`descripcion`).
    /// 4. **Visual Representation:** Holds a `Texture2D` (`imageItem`) for the object's visual representation, like in an inventory.
    /// 5. **Optional Status:** Indicates whether the object is optional (`optional`) or required for game progression.
    /// 6. **Active Status:** Tracks whether the object is currently active or inactive (`isActive`) in the game world.
    /// 7. **Start Method PlaceHolder**: Have a method called Start to allow the subclasses override this.
    /// 
    /// **How it Works:**
    /// - This script is intended to be a base class and will not be used as is. It should be inherited by specific object types.
    /// - This class must be attached to a GameObject in a Unity scene to represent the object.
    /// - The `id` is a unique identifier for the object.
    /// - `name` holds the object's name.
    /// - `descripcion` provides a brief description of the object.
    /// - `imageItem` is a `Texture2D` that can be used to display the object's icon or image.
    /// - `optional` is a boolean that indicates whether the object is optional.
    /// - `isActive` is a boolean that indicates whether the object is active.
    /// - The `Start()` method is virtual, allowing derived classes to override it to initialize their specific logic.
    /// - The subclass can manage their own method to handle the interaction.
    /// 
    /// **How to Use:**
    /// 1. **Create an Object:** Create a GameObject in your Unity scene to represent an object.
    /// 2. **Create a derived class:** Create a new class and make it inherit from this class.
    /// 3. **Add Components:** Add the derived class script as a component to the object GameObject.
    /// 4. **Set Parameters:**
    ///     - In the Inspector, set the `id` to a unique integer for this object.
    ///     - Set the `name` and `descripcion` to provide information about the object.
    ///     - Set the `imageItem` to a `Texture2D` that will be used to represent the object visually.
    ///     - Optionally, set `optional` to true if the object is not mandatory for game progression.
    ///     - Optionally, set `isActive` to true if the object is currently active in the scene.
    /// 5. **Override the Start method**: If it is necessary, you can override the Start method to make your own implementation.
    /// 
    /// **Example Use Cases:**
    /// - **Inventory System:** Use this class as a base for items that can be collected and stored in the player's inventory.
    /// - **Interactive Objects:** Use this class for objects that the player can interact with in the game world (e.g., doors, buttons, levers).
    /// - **Collectible Items:** Use this class for items that the player can collect but do not necessarily interact with (e.g., coins, gems).
    /// - **Scene elements:** use this class to manage a element of a scene.
    /// 
    /// **Future Improvements:**
    /// - **More Properties:** Add more properties to represent additional object attributes (e.g., weight, value, type).
    /// - **Methods to Interact:** Add methods to handle object-specific interactions.
    /// - **Inventory Interaction:** Make it so that the object can be affected by the player's inventory.
    /// - **State management**: Add logic to manage the differents states of the object.
    /// 
    /// **Current Limitations:**
    /// - **Basic Structure:** It's currently a basic data structure.
    /// - **No interaction:** There is no interaction manage in this class.
    /// - **No inventory Logic:** There is no inventory logic implement yet.
    /// </summary>
public class CGenericObject : MonoBehaviour
{
    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    [SerializeField]
    protected int id;
    /// <summary>
    /// The name of the object.
    /// </summary>
    [SerializeField]
    protected new string name;
    /// <summary>
    /// A brief description of the object.
    /// </summary>
    [SerializeField]
    protected string descripcion;
    /// <summary>
    /// A Texture2D used to represent the object visually.
    /// </summary>
    [SerializeField]
    protected Texture2D imageItem;
    /// <summary>
    /// Indicates whether the object is optional in the game.
    /// </summary>
    [SerializeField]
    protected bool optional;
    /// <summary>
    /// Indicates whether the object is currently active in the game.
    /// </summary>
    [SerializeField]
    protected bool isActive;

    /// <summary>
    /// The Start method is virtual, so it can be overridden by derived classes.
    /// </summary>
    [SerializeField]

    protected virtual void Start()
    {
       // imageItem = item.imageItem;
     //   optional = item.Optional;
       // isActive = item.isActive;
    }


}
}
