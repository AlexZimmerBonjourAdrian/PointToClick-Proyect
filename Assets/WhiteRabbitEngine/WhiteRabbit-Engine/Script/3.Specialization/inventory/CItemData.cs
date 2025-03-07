using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WhiteRabbit.Core;
 namespace WhiteRabbit.Specialization
{

/// <summary>
/// `CItemData` is a ScriptableObject that defines the data for an item in the game.
/// It is designed to be used as a template for creating various items that can be stored in the inventory.
///
/// **Key Responsibilities:**
/// 1. **Item Data Storage:** Stores essential information about an item, such as its ID, name, description, image, and whether it is optional.
/// 2. **ScriptableObject:** Leverages Unity's ScriptableObject system, allowing for easy creation, storage, and management of item data within the Unity Editor.
/// 3. **Item Definition:** Acts as a blueprint for creating items, defining their properties.
/// 4. **Inventory Integration:** Intended to be used with an inventory system, such as the `Cinventory` class, to manage items in the game.
/// 5. **Visualization:** Allows to have a image to visualize the item in the inventory.
///
/// **How It Works:**
/// - **ScriptableObject:** `CItemData` is a ScriptableObject, meaning you can create assets based on this class in the Unity Editor.
/// - **Item Properties:** Each `CItemData` instance will contain the following information about an item:
///   - `Id`: A unique integer identifier for the item.
///   - `Name`: The name of the item.
///   - `description`: A short text that describes the item.
///   - `imageInventory`: A `Sprite` that will be used to display the item in the inventory.
///   - `Optional`: A boolean that determines if the item is optional or not. It might be used to know if this item is needed to finish the game or not.
/// - **Creation in the Editor:** You create instances of `CItemData` in the Unity Editor (e.g., by right-clicking in the Project window and selecting "Create/PointToClick/Item").
/// - **Data Population:** Once created, you fill in the item's properties in the Inspector panel.
///
/// **How to Use:**
/// 1. **Create Item Data Assets:** In the Unity Editor, create new `CItemData` assets for each item in your game.
/// 2. **Populate Item Data:** Fill in the `Id`, `Name`, `description`, `imageInventory`, and `Optional` fields for each item in the Inspector.
/// 3. **Reference in Inventory:** When adding an item to the player's inventory (e.g., using the `Cinventory` class), you will reference a `CItemData` asset.
/// 4. **Display in UI:** You can use the `imageInventory` property to display the item's image in the inventory UI.
/// 5. **Access Item Information:** Other scripts can access the properties of the `CItemData` asset to get information about the item.
/// 6. **Use the optional field:** The optional field can be used to determine if the item is optional or not.
///
/// **Example Use Case:**
/// - **Creating a Key:** You create a `CItemData` asset for a "Key" item, set its `Id`, `Name`, `description`, `imageInventory`, and `Optional`.
/// - **Adding to Inventory:** When the player finds the key, you add the `CItemData` asset to the player's inventory.
/// - **Displaying the Key:** The inventory UI uses the `imageInventory` to show the key's image.
/// - **Checking the Key:** The game logic can check if the item is optional or not.
///
/// **Future Improvements:**
/// - **Item Use Logic:** In the future, we can create a new class to define the logic of how an item is used.
/// - **Item Types:** Add an enum to define different types of items (e.g., key, weapon, potion).
/// - **Item Stats:** Add more properties to define item stats (e.g., durability, damage).
/// - **Stackable Items:** Add functionality to handle stackable items.
/// - **More propertys:** Add more property to the item.
///
/// **Current Limitations:**
/// - **Data Container:** This class only stores data; it does not contain logic for using the item.
/// - **No Use Method:** There is no method to define how the item can be used.
/// - **No type:** There is not a type associated with the item.
/// </summary>
[CreateAssetMenu(fileName = "NewItemData",menuName ="PointToClick/Item")]
[Serializable]
public class CItemData : ScriptableObject
{
    
    // Start is called before the first frame update
    /// <summary>
    /// The unique identifier for this item.
    /// </summary>
    [SerializeField]
    private int Id;
    /// <summary>
    /// The name of the item.
    /// </summary>
    [SerializeField]
    private string Name;

    /// <summary>
    /// A description of the item.
    /// </summary>
    [TextArea(2, 2)]
    [SerializeField]
    private string description;

    /// <summary>
    /// The sprite that will be used to represent the item in the inventory.
    /// </summary>
    [SerializeField]
    private Sprite imageInventory;

    /// <summary>
    /// Indicates whether this item is optional or not.
    /// </summary>
    [SerializeField]
    private bool Optional;


}

}
