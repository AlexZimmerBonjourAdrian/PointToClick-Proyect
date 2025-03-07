using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The `StructRoom` static class is designed to manage and define the structure of rooms within the game.
/// It provides a way to store room-related data using a nested struct called `Room`.
/// This class is intended to be used as a data container for rooms, particularly in conjunction with the `MapData` ScriptableObject.
/// 
/// **Key Responsibilities:**
/// 1. **Room Data Definition:** Defines the `Room` struct, which holds various data points associated with a single room (ID, Image, Accessibility, Tag).
/// 2. **Centralized Room Storage:** Provides a static list (`rooms`) to store multiple instances of the `Room` struct.
/// 3. **Data Container:** Serves as a data container for room-related information, making it easily accessible to other parts of the game.
/// 4. **Serialization:** The `Room` struct is marked as `[Serializable]`, allowing it to be serialized and stored in other data structures or files (e.g., within a ScriptableObject like `MapData`).
/// 5. **Accessibility Control:** The room can have an accessibility state and can be changed.
/// 
/// **How It Works:**
/// - **Static Class:** `StructRoom` is a static class, meaning it cannot be instantiated. You access its members directly via `StructRoom.rooms` or `StructRoom.Room`.
/// - **Room Struct:** The `Room` struct is a nested data structure inside `StructRoom`. Each `Room` instance represents a single room in the game.
/// - **Room Data:** A `Room` instance contains the following data:
///   - `id`: A unique integer identifier for the room.
///   - `RoomImage`: A `Sprite` that can be used to represent the room visually (e.g., in a map or UI).
///   - `IsAccessible`: A boolean indicating whether the room is currently accessible to the player.
///   - `tag`: A string that can be used to categorize or tag the room (e.g., "main", "secret", "boss").
/// - **Static List:** The `rooms` list (a static `List<Room>`) stores all the `Room` instances. This list can be accessed from anywhere in the code using `StructRoom.rooms`.
/// - **SetIsAccessible()**: This method allow to change the IsAccessible value for the room.
///
/// **How to Use:**
/// 1. **Create Room Data:** Create instances of the `Room` struct and set their properties (ID, Image, etc.).
/// 2. **Store Rooms:** Add these `Room` instances to the `StructRoom.rooms` list to make them available to other parts of the game.
/// 3. **Access Room Data:** Access the `StructRoom.rooms` list from other scripts to get data about the rooms.
/// 4. **Serialization:** You can use the `Room` struct in data structures that need to be serialized.
/// 5. **Change Room data:** You can use the `SetIsAccessible()` method to change the IsAccessible value of the room.
/// 
/// **Example Use Case:**
/// - **Map Data:** The `MapData` ScriptableObject can use the `Room` struct to store data about each room in the game map.
/// - **Room Manager:** A room manager class can use `StructRoom.rooms` to access and manage all the rooms in the game.
/// - **UI:** UI elements can use `RoomImage` to display visual representations of the rooms.
/// - **Game Logic:** Game logic can use `IsAccessible` to determine whether the player can enter a room or not.
///
/// **Future Improvements:**
/// - **Methods for Room Management:** Add methods within `StructRoom` to search, add, remove, or modify rooms in the `rooms` list.
/// - **Room Connections:** Add a property to each `Room` struct to store information about the rooms connected to it.
/// - **More properties:** Add more property to the room if it is necessary.
/// - **Dictionary implementation:** Consider replace the list with a dictionary to make a faster search.
/// 
/// **Current Limitations:**
/// - **Manual Room Management:** Rooms need to be manually added to the `rooms` list.
/// - **No Search/Filter:** There are no methods to find, filter, or sort rooms within the `rooms` list.
/// - **Static:** All the rooms are storaged in one list. If you need to have differents rooms groups, this class will not be useful.
/// </summary>
public static class StructRoom 
{
    // Static list to store Room structs
    /// <summary>
    /// A static list that stores all the Room structs.
    /// This list is a central repository for all room data in the game.
    /// </summary>
    public static List<Room> rooms = new List<Room>();

    // Nested struct to represent a room
    /// <summary>
    /// A struct representing a single room within the game.
    /// It holds various properties related to a room, such as its ID, image, accessibility, and tag.
    /// </summary>
    [Serializable] // Ensures that the Room struct can be serialized.
    [SerializeField] // Makes the struct fields visible in the Unity Editor's Inspector.
    public struct Room
    {
        /// <summary>
        /// The unique ID of the room.
        /// </summary>
        public int id;
        /// <summary>
        /// A sprite representing the room visually.
        /// </summary>
        public Sprite RoomImage;
        /// <summary>
        /// Indicates whether the room is currently accessible to the player.
        /// </summary>
        public bool IsAccessible;
        /// <summary>
        /// A tag for categorizing or identifying the room.
        /// </summary>
        public string tag;

        /// <summary>
        /// Sets the IsAccessible property of the room.
        /// </summary>
        /// <param name="v">The new value for IsAccessible.</param>
        public void SetIsAccessible(bool v)
        {
            IsAccessible = v;
        }
    }
}
}
