using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// `CInventoryItemData` is a ScriptableObject class that serves as the base data container for items in the game's inventory system.
    /// It defines the fundamental properties and behavior of an item, including its name, icon, and how it should be used.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Item Data Storage:** Stores the basic data of an inventory item, such as its name and icon.
    /// 2. **ScriptableObject:** Leverages Unity's ScriptableObject feature, allowing item data to be created and edited directly in the Unity Editor.
    /// 3. **IInventoryItem Implementation:** Implements the `IInventoryItem` interface, making it usable within the `Cinventory` system.
    /// 4. **Virtual Use Method:** Provides a `Use()` method that can be overridden by derived classes to define custom item usage logic.
    /// 5. **Centralized Item Creation:** Facilitates the creation of multiple distinct item types, all sharing a common base data structure.
    /// 
    /// **How It Works:**
    /// - This class is designed to be used as a template for creating specific item types in the game.
    /// - You would typically create new ScriptableObject assets from this class in the Unity Editor.
    /// - Each asset represents a unique item in the game.
    /// - The `itemName` and `icon` fields are exposed in the Unity Editor, allowing designers to set the item's name and visual representation.
    /// - The `Use()` method is virtual, meaning you can override it in derived classes to implement custom behavior for specific item types.
    /// - When the item is added to the inventory, an instance of this item is created in the list of the inventory.
    /// - When the Use method is call, the method of the instance in the inventory is called.
    /// 
    /// **How to Use:**
    /// 1. **Create New Item Types:** In your Unity project, right-click in the Project window, select "Create," then "Inventory," and "Item" to create a new ScriptableObject based on this class.
    /// 2. **Fill Item Data:** In the Inspector for the newly created item asset, set the `itemName` (string) and assign a `Sprite` to the `icon` field.
    /// 3. **Override Use Method (Optional):** If the item needs custom behavior, create a new class that inherits from `CInventoryItemData` and override the `Use()` method.
    /// 4. **Add to Inventory:** Use `Cinventory.Instance.AddItem()` to add an instance of this `CInventoryItemData` (or a derived class) to the player's inventory.
    /// 5. **Use the Item:** Use `Cinventory.Instance.UseItem()` to use the item, calling the `Use()` method.
    /// 
    /// **Example Use Cases:**
    /// - **Consumables:** Create item types like "Health Potion" or "Mana Potion," overriding `Use()` to apply healing or mana restoration.
    /// - **Keys:** Create key items that unlock doors, overriding `Use()` to check for the appropriate door and open it.
    /// - **Quest Items:** Create unique items that are part of the game's quest system.
    /// - **Collectibles:** Create items that don't necessarily have a direct use but are collected by the player.
    /// 
    /// **Future Improvements:**
    /// - **Item Properties:** Add more properties to manage additional item attributes (e.g., value, weight, stack size).
    /// - **Complex Use Logic:** Allow the `Use()` method to take parameters for more complex interactions.
    /// - **Item Categories:** Add a category system to group items together.
    /// - **Item Combination:** Add logic to allow items to be combined to create new items.
    /// - **Different Type**: Add the posibility to manage different types of objects.
    /// 
    /// **Current Limitations:**
    /// - **Basic Use Logic:** The default `Use()` method is very basic and only logs a message to the console.
    /// - **No Item States:** The class doesn't manage different states that an item might have.
    /// - **No interaction with world**: the items does not have interaction with the world.
    /// </summary>

    // Clase base para objetos de inventario como Scriptable Objects
    [CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]
    public class CInventoryItemData : ScriptableObject, IInventoryItem
    {
        /// <summary>
        /// The name of the item. This is used to identify the item and can be displayed in the UI.
        /// </summary>
        public string Name => itemName;
        /// <summary>
        /// The icon representing the item. This is used for visual representation in the inventory or other UI elements.
        /// </summary>
        public Sprite Icon => icon;

        /// <summary>
        /// the item name. This data is set up in the editor.
        /// </summary>
        [SerializeField] private string itemName;
        /// <summary>
        /// The sprite of the item. This data is set up in the editor.
        /// </summary>
        [SerializeField] private Sprite icon;

        /// <summary>
        ///  This is the action to be executed when an object is use.
        /// This method is called when the item is "used" by the player.
        /// Derived classes can override this method to implement specific item usage logic.
        /// </summary>
        public virtual void Use()
        {
            Debug.Log($"Usando {itemName}");
            // Implementa la lógica de uso del objeto aquí
        }
    }
}
