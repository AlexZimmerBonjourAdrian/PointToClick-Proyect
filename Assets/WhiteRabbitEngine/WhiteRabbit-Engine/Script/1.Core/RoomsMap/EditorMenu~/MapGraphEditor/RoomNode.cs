using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Experimental.GraphView;

namespace WhiteRabbit.Core
{
    /// <summary>
    /// Represents a single room within a room map or graph structure.
    /// This class holds data about a room, such as its unique identifier, name, connected rooms, and properties indicating if it's an entry or exit point.
    /// It's designed to be used within a visual editor to construct a graph of connected rooms,
    /// and the data can be used by the game's logic to manage room transitions and gameplay.
    ///
    /// **Key Responsibilities:**
    /// 1. **Room Representation:** Stores data for a single room.
    /// 2. **Unique Identification:** Provides a unique identifier (GUID) and a room ID for each room.
    /// 3. **Connectivity:** Maintains a list of connected rooms to define the room's relationships within the map.
    /// 4. **Entry/Exit Points:** Indicates if the room is an entry point or an end room in the map.
    /// 5. **Interactable Objects:** Allows for a GameObject to be associated with the room to represent interactable objects.
    /// 
    /// **How It Works:**
    /// - Each instance of `RoomNode` represents one room in the game's world.
    /// - The `RoomId` is an integer that can be used to identify the room.
    /// - The `RoomName` is a string that gives a descriptive name to the room.
    /// - The `GUID` is a globally unique identifier, ensuring that each room can be uniquely identified, even if they have the same name.
    /// - `Interacts` is a GameObject that can be associate with this room, in order to be manage.
    /// - The `ConnectedRooms` list stores other `RoomNode` objects that are directly connected to this room. This forms the graph-like structure of the room map.
    /// - `EntryPoint` is a boolean flag that, when true, indicates that this room is an entry point into the level or area.
    /// - `EndRoom` is a boolean flag that, when true, indicates that this room is the endpoint or exit of a level or area.
    ///
    /// **How to Use:**
    /// 1. **Creation:** `RoomNode` objects are typically created within a custom editor tool used for designing room layouts.
    /// 2. **Population:** When a new room is added in the editor, a new `RoomNode` is created.
    /// 3. **Connection:** The `ConnectedRooms` list is populated when the user creates connections between rooms in the editor.
    /// 4. **Identification:** Each `RoomNode` needs a `RoomId`, a `RoomName`, and a `GUID` to be uniquely identified.
    /// 5. **Entry/Exit Points:** The `EntryPoint` and `EndRoom` flags are set in the editor to designate specific rooms.
    /// 6. **Interactable Objects:** the `Interacts` propertie can be set to assosiate a gameobject to the room.
    /// 7. **Accessing Data:** At runtime, the game's logic can access the data stored in `RoomNode` objects to determine room connectivity, entry/exit points, or other properties.
    ///
    /// **Example Use Cases:**
    /// - **Room Map Editor:** A custom editor might use this class to visually represent rooms and their connections.
    /// - **Navigation Logic:** The game can use `RoomNode` data to know which rooms are connected and how the player can move between them.
    /// - **Level Setup:** The `EntryPoint` and `EndRoom` properties can be used to determine where the player starts or finishes a level.
    /// - **Interactable Objects:** The `Interacts` property can be use to assosiate gameobjects with the room and manage them.
    ///
    /// **Future Considerations:**
    /// 1. **More Properties:** Add more properties to represent additional room attributes (e.g., difficulty, type, items).
    /// 2. **Data Validation:** Implement checks to ensure that `RoomId` and `GUID` are unique.
    /// 3. **Serialization:** Add logic to save and load `RoomNode` data to/from files.
    /// 4. **Visual Representation:** Add methods or properties to influence how a `RoomNode` is visually represented in the editor.
    /// 5. **More Logic:** Add methods to search connected rooms, or search for a room by id.
    /// 6. **More Properties:** This class can be extended with more propertie depending on the context.
    /// 
    /// **Current Limitations:**
    /// 1. **Basic Data Structure:** It's currently a basic data structure and requires other systems to use it effectively.
    /// 2. **Manual Population:** It doesn't have built-in functionality to automatically populate or connect rooms.
    /// 3. **No Editor Integration:** It doesn't provide any built-in UI elements for a visual editor.
    /// 4. **No Save/Load Logic:** Does not have any methods to automatize the save and load of the data.
    /// </summary>
    public class RoomNode //:  Node
    {
        /// <summary>
        /// A unique numerical identifier for the room.
        /// </summary>
        public int RoomId;

        /// <summary>
        /// The name of the room, for display and identification purposes.
        /// </summary>
        public string RoomName;

        /// <summary>
        /// A globally unique identifier (GUID) for the room, ensuring uniqueness even across different maps.
        /// </summary>
        public string GUID;

        /// <summary>
        /// A Game object related to this room. It can be use to manage interactable objects on this room.
        /// </summary>
        public GameObject Interacts;
        /// <summary>
        /// A list of RoomNode objects that are directly connected to this room.
        /// This defines the connectivity of the room within the map.
        /// </summary>
        public List<RoomNode> ConnectedRooms;

        /// <summary>
        /// Indicates if this room is an entry point into the level or area.
        /// </summary>
        public bool EntryPoint = false;

        /// <summary>
        /// Indicates if this room is the end or exit room of the level or area.
        /// </summary>
        public bool EndRoom = false;


    }

}
