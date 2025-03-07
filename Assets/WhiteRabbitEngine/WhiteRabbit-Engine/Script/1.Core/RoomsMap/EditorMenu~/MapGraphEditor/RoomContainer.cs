using System;
using System.Collections.Generic;
using UnityEngine;
 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The RoomContainer class is a ScriptableObject designed to store and manage data related to a collection of rooms and their relationships within a game's map.
/// It acts as a container for the information needed to represent the structure and connections of a level or area.
/// 
/// **Key Responsibilities:**
/// 1. **Node Links Management:** Stores connections between different rooms (nodes) using a list of `NodeLinkRoom` objects.
/// 2. **Room Node Data:** Holds a list of `RoomNode` objects, each representing a single room with its unique properties.
/// 3. **Exposed Properties:** Manages a list of `ExposedProperties`, which can be used to define custom variables or parameters related to the rooms or map.
/// 4. **Comment Block Data:** Stores information about `CommentBlockDataRoom` objects, which are used to visually group and annotate related nodes in the map editor.
/// 5. **ScriptableObject:** Leverages Unity's ScriptableObject system, making it easy to create, store, and edit map data in the Unity Editor.
/// 
/// **How it Works:**
/// - **Node Links (`NodeLinks`):** This list stores the connections between rooms. Each `NodeLinkRoom` object would contain information about a source room, a destination room, and possibly other details about the connection.
/// - **Room Nodes (`DialogueNodeData`):** This list holds the data for each individual room. Each `RoomNode` object will represent a room in the game, holding data like its name, ID, position in the editor, and potentially other custom data.
/// - **Exposed Properties (`ExposedProperties`):** This list allows you to add custom variables to the map data. For example, you might add a property called "IsLocked" to a room to indicate whether the player can access it. Each `ExposedProperties` object would contain the property name, type, and value.
/// - **Comment Blocks (`CommentBlockData`):** This list manages comment blocks in the map editor. Each `CommentBlockDataRoom` object represents a visual block that groups together multiple `RoomNode` objects. It holds the position, title, and a list of child nodes (rooms) that it contains.
/// 
/// **How to Use:**
/// 1. **Creation:** Create instances of this ScriptableObject in the Unity Editor (e.g., by right-clicking in the Project window and selecting "Create/RoomContainer").
/// 2. **Population:** The lists in this container are typically populated by a custom editor tool that creates the map graph visually. When create a new map, the tools must be used to create a new graph.
/// 3. **Access:** Other scripts can then load this `RoomContainer` ScriptableObject and access its lists to get information about the rooms, their connections, exposed properties, and comment blocks.
/// 
/// **Example Use Case:**
/// - A "Map Graph Editor" tool might use this class to store the layout of rooms designed in the editor.
/// - The game's logic could then load the `RoomContainer` to know which rooms exist, how they are connected, and if they have any special properties.
/// - You could also use the `ExposedProperties` to add custom conditions to the rooms (for instance: if a room is locked or not, if an item is present there, etc)
/// 
/// **Future Enhancements:**
/// - Add methods for finding specific rooms or connections.
/// - Add methods for validating the data in the container.
/// - Add more data type to the exposed properties.
/// - Add logic to automatize the load of the data.
/// - Add methods to save the data.
/// 
/// **Current Limitations:**
/// - All the data is added by hand.
/// - Currently there is not a way to automatize the creation of this object and its data.
/// - There is not a method to get the data.
/// - The use of this data is dependent to other classes.
/// </summary>
public class RoomContainer : ScriptableObject
{
    /// <summary>
    /// A list of connections between rooms.
    /// Each NodeLinkRoom represents a link from one room to another.
    /// </summary>
   public List<NodeLinkRoom> NodeLinks = new List<NodeLinkRoom>();
    /// <summary>
    /// A list of RoomNode objects, each representing a room in the map.
    /// </summary>
    public List<RoomNode> DialogueNodeData = new List<RoomNode>();
    /// <summary>
    /// A list of custom properties that can be associated with the rooms or the map.
    /// </summary>
    public List<ExposedProperties> ExposedProperties = new List<ExposedProperties>();
    /// <summary>
    /// A list of CommentBlockDataRoom objects, which are used to visually group and annotate nodes in the map editor.
    /// </summary>
    public List<CommentBlockDataRoom> CommentBlockData = new List<CommentBlockDataRoom>();
}
}
