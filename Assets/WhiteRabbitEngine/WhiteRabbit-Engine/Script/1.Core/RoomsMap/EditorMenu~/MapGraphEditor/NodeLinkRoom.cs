using System;
using System.Linq;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// Represents a link between two nodes within the Room Map graph editor.
/// This class defines the connection details between a source node and a destination node.
/// It's used to represent the flow or relationship between different rooms in the game's map.
///
/// **Key Components:**
/// 1. **BaseNodeGUID:** The unique identifier (GUID) of the source node where the link originates.
/// 2. **PortName:** The name of the output port on the source node that this link is connected to.
/// 3. **TargetNodeGUID:** The unique identifier (GUID) of the destination node where the link leads.
///
/// **How It Works:**
/// - In a visual graph editor for creating room maps, each room is represented by a node.
/// - Links (connections) between these nodes represent transitions or relationships between rooms.
/// - This `NodeLinkRoom` class stores the information about one such link.
/// - When a link is created between two nodes in the editor:
///   - The GUID of the node from which the link starts is saved as `BaseNodeGUID`.
///   - The name of the specific output port on the source node (if nodes have multiple outputs) is saved as `PortName`.
///   - The GUID of the node to which the link goes is saved as `TargetNodeGUID`.
///
/// **Example Scenario:**
/// - Suppose you have two room nodes: "RoomA" (GUID: "123") and "RoomB" (GUID: "456").
/// - In the visual editor, you draw a link from "RoomA" to "RoomB" through the "Exit" port.
/// - This connection would be represented by a `NodeLinkRoom` object with:
///   - `BaseNodeGUID` = "123" (RoomA's GUID)
///   - `PortName` = "Exit" (the output port's name)
///   - `TargetNodeGUID` = "456" (RoomB's GUID)
///
/// **Use Cases:**
/// 1. **Saving the Room Map:** When saving the room map layout, these `NodeLinkRoom` objects are serialized and stored.
/// 2. **Loading the Room Map:** When loading the room map, these objects are deserialized, allowing the editor to recreate the connections.
/// 3. **Navigation Logic:** At runtime, the game can use these link relationships to determine which rooms are accessible from other rooms.
/// 4. **Editor Visualization:** The `NodeLinkRoom` data is essential for drawing the visual links between nodes in the room map editor.
///
/// **Future Considerations:**
/// 1. **Link Types:** In the future, this class could be extended to support different types of links (e.g., one-way, two-way, locked).
/// 2. **Link Data:** Additional properties could be added to store information about the link itself, such as conditions for traversal.
/// 3. **Visual Style:** The class does not handle the visual aspect of the links, only the data they represent.
///
/// **Current Limitations:**
/// 1. **Basic Connection:** It only defines a basic link between two nodes.
/// 2. **No Link Data:** It does not support storing any extra information about the link (like conditions or properties).
/// 3. **Port Logic:** The logic to manage the ports is not implemented in this class.
/// 4. **No visual data:** This class does not store any visual data of the link.
/// </summary>
   [Serializable]
public class NodeLinkRoom 
{
   
        /// <summary>
        /// The unique identifier (GUID) of the source node where the link originates.
        /// </summary>
        public string BaseNodeGUID;
        /// <summary>
        /// The name of the output port on the source node that this link is connected to.
        /// </summary>
        public string PortName;
        /// <summary>
        /// The unique identifier (GUID) of the destination node where the link leads.
        /// </summary>
        public string TargetNodeGUID;
}
}
