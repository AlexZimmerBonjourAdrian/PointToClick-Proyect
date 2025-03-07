using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;


 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// The `Cinventory` class manages the player's inventory in the game.
    /// It uses a singleton pattern to ensure that only one inventory exists
    /// and provides methods to add and use items.
    ///
    /// **Key Responsibilities:**
    /// 1. **Singleton Pattern:** Ensures only one instance of `Cinventory` exists throughout the game.
    /// 2. **Item Storage:** Stores a list of items the player has collected (`inventory`).
    /// 3. **Item Management:** Provides methods to add items to the inventory and to use items.
    /// 4. **Global Access:** Allows any other script to access the inventory using `Cinventory.Instance`.
    ///
    /// **How to Use:**
    /// 1. **Accessing the Inventory:** Other scripts can access the inventory using `Cinventory.Instance`.
    /// 2. **Adding Items:** Use `Cinventory.Instance.AddItem(CInventoryItemData itemData)` to add an item to the inventory.
    ///     - `CInventoryItemData` should implement the `IInventoryItem` interface.
    /// 3. **Using Items:** Use `Cinventory.Instance.UseItem(int index)` to "use" an item from the inventory, specifying its index.
    ///     - The `Use()` method of the `IInventoryItem` implementation will be called.
    /// 4. **Check if an item is in the inventory:** At this moment, this functionality is not implement yet.
    ///     - We need to implement a method to check if an object is in the inventory.
    /// 5. **Get Item:** At this moment, this functionality is not implement yet.
    ///     - We need to implement a method to get an specific item.
    /// 6. **Remove Item:** At this moment, this functionality is not implement yet.
    ///     - We need to implement a method to remove an item.
    ///
    /// **Future Improvements:**
    /// - Implement methods to remove items.
    /// - Implement methods to check if an item is in the inventory.
    /// - Implement methods to get an item.
    /// - Add events or callbacks to notify other scripts when the inventory changes (e.g., an item is added or removed).
    /// - Add methods to manage the number of objects that you can have.
    /// - Add methods to save and load the inventory.
    /// - Improve the way of using item.
    ///
    /// **Current Limitations**
    /// - Only have methods to add and use objects.
    /// - The way to use an item is by index. This can be problematic in the future.
    /// </summary>
public class Cinventory : MonoBehaviour
{
    // Singleton para acceder al inventario desde cualquier lugar
    /// <summary>
    /// Singleton instance of the Cinventory.
    /// Provides a global access point to the inventory functionality.
    /// </summary>
    public static Cinventory Instance { get; private set; }

    /// <summary>
    /// List to store the items in the inventory.
    /// </summary>
    private List<IInventoryItem> inventory = new List<IInventoryItem>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of Cinventory exists (Singleton pattern).
    /// </summary>
    private void Awake()
    {
        // Asegurar que solo haya una instancia del inventario
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Método para agregar un objeto al inventario
    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    /// <param name="itemData">The item data to add. This should be an instance of a class that implements IInventoryItem.</param>
    public void AddItem(CInventoryItemData itemData)
    {
        inventory.Add(itemData);
        Debug.Log($"{itemData.Name} añadido al inventario.");
    }

    // Método para usar un objeto del inventario por su índice
    /// <summary>
    /// Uses an item from the inventory based on its index.
    /// </summary>
    /// <param name="index">The index of the item to use in the inventory list.</param>
    public void UseItem(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            // Call the Use method of the item.
            inventory[index].Use();
        }
        else
        {
            Debug.LogError("Índice de inventario inválido.");
        }
    }
}
}
