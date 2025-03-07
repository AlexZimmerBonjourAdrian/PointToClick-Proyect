using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

// Interfaz para interacciones con objetos del inventario
 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// `IInventoryItem` is an interface that defines the basic requirements for an item that can be stored in the player's inventory.
    /// Any class that implements this interface can be managed by the inventory system.
    ///
    /// **Key Responsibilities:**
    /// 1. **Item Definition:** Defines the common properties and behaviors of items that can be in an inventory.
    /// 2. **Inventory Integration:** Ensures that all inventory items have a consistent way of being handled by the inventory system.
    /// 3. **Polymorphism:** Allows different types of items to be treated uniformly when stored in the inventory.
    /// 4. **Centralized Logic:** By implementing `IInventoryItem`, items can use methods of the inventory.
    ///
    /// **How It Works:**
    /// - An interface defines a contract that any implementing class must follow.
    /// - `IInventoryItem` requires implementing classes to provide a `Name`, `Icon`, and a `Use()` method.
    /// - The inventory system (e.g., `Cinventory`) can then manage a list of `IInventoryItem` objects without needing to know their specific types.
    /// - When you want to interact with the object you must use the interface method.
    ///
    /// **How to Use:**
    /// 1. **Create Item Data Classes:** Create new classes (e.g., `CInventoryItemData`, `MyConsumableItem`, `MyQuestItem`) that inherit from `ScriptableObject` and implement this interface.
    /// 2. **Implement Properties:** In each of your item classes, implement the `Name` and `Icon` properties, which are used to get the item's name and visual representation.
    /// 3. **Implement Use Method:** Implement the `Use()` method to define what happens when the item is used.
    /// 4. **Add to Inventory:** Use `Cinventory.Instance.AddItem()` to add items to the inventory. The `Cinventory` class can hold a list of `IInventoryItem` objects.
    /// 5. **Use Items:** When an item is "used", the `Use()` method defined in its specific class will be called.
    ///
    /// **Example Use Cases:**
    /// - **Consumable Items:** Create a `ConsumableItem` class that implements `IInventoryItem`. The `Use()` method might restore health or mana.
    /// - **Quest Items:** Create a `QuestItem` class. The `Use()` method might advance a quest or display a message.
    /// - **Key Items:** Create a `KeyItem` class that unlocks doors or areas.
    /// - **Collectibles**: create an item to be collect in the game.
    ///
    /// **Future Improvements:**
    /// - **More Methods:** Add more methods to this interface to manage other item behaviors (e.g., `Equip()`, `Drop()`, `Combine()`).
    /// - **Item States:** Add properties to track the state of the item (e.g., durability, charges).
    /// - **Complex Use:** Improve the method Use to manage a complex use.
    ///
    /// **Current Limitations:**
    /// - **Basic Interaction:** It only defines a basic interaction method (`Use`).
    /// - **No Item States:** It does not handle the different states that an item can have.
    /// - **No Type**: there is not a type for the items.
    /// </summary>
    public interface IInventoryItem
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The icon representing the item.
        /// </summary>
        Sprite Icon { get; }
        /// <summary>
        /// Defines the action to be taken when the item is used.
        /// </summary>
        void Use();
    }
}
