using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 namespace WhiteRabbit.Core
 {
 
/// <summary>
/// Represents a room in the game.
/// This class is a MonoBehaviour that defines a single room within the game world.
/// It stores basic information about the room and can be used to represent a discrete location in the game.
///
/// **Key Responsibilities:**
/// 1. **Room Representation:**  Provides a game object component that represents a room in the Unity scene.
/// 2. **Unique Identification:** Each room has a unique integer ID (`IdRoom`) to identify it.
/// 3. **Name Storage:** Stores the name of the room (`RoomName`), which is initialized to the name of the GameObject.
/// 4. **Basic Room Data:** Holds the essential data associated with a room, such as its ID and name.
/// 
/// **How It Works:**
/// - This script is intended to be attached to a GameObject in a Unity scene.
/// - That GameObject will represent a single room in the game.
/// - The `IdRoom` property is a unique identifier that you should set manually for each room in the editor.
/// - The `RoomName` will automaticaly be equal to the game object name.
/// - This class does not define how rooms are connected or how the player transitions between them.
///   That logic would be handled by other systems, such as a `CLevelManager` or a room map system using the data from `MapData` and `RoomNode`.
/// 
/// **How to Use:**
/// 1. **Create a Room:** In your Unity scene, create a new GameObject (e.g., an empty GameObject or a room with visual elements).
/// 2. **Attach the Script:** Add this `Room` script as a component to the newly created GameObject.
/// 3. **Set the ID:** In the Inspector panel, set the `IdRoom` property to a unique integer. Make sure each room has a distinct ID.
/// 4. **Organize:** You can parent other GameObjects (e.g., walls, furniture, interactable objects) to this Room GameObject.
/// 5. **Access Information:** Other scripts can access the `IdRoom` and `RoomName` properties using `GetComponent<Room>()` to get information about the room.
/// 
/// **Example Use Cases:**
/// - **Level Design:** Use this class to represent rooms in a game level.
/// - **Room Management:** Other scripts can interact with `Room` components to manage room-specific logic or data.
/// - **Room Transitions:** A level manager can use `IdRoom` to load or transition between rooms.
/// - **Interactable Objects:** the room can hold interactable objects and manage them.
/// 
/// **Future Considerations:**
/// 1. **More Properties:** Add more properties to represent additional room attributes (e.g., type, items, connected rooms).
/// 2. **Room Logic:** Add methods to handle room-specific events or actions.
/// 3. **Room Connections:** You might add logic to connect rooms with each other in the future.
/// 4. **Room Data:** Add more properties to represent additional data related to the room.
/// 
/// **Current Limitations:**
/// 1. **Basic Data Structure:** It's currently a basic data structure and requires other systems to use it effectively.
/// 2. **No connection:** At this moment, this class does not have any logic related to how the rooms are connect.
/// 3. **No visual data:** This class does not have any visual data.
/// </summary>
public class Room : MonoBehaviour
{
   /// <summary>
   /// The unique identifier for the room.
   /// This ID should be unique across all rooms in the game.
   /// It is use to identify this room.
   /// </summary>
   [SerializeField]
   private int IdRoom;

   /// <summary>
   /// The name of the room.
   /// This name is automatically set to the name of the GameObject to which this script is attached.
   /// It is use to identify the room.
   /// </summary>
   private string RoomName;

   /// <summary>
   /// Initializes the room name to the name of the game object.
   /// This method is called automatically when the script instance is loaded.
   /// In this method, the RoomName is set to the name of the game object.
   /// </summary>
   private void Awake()
   {
      RoomName = gameObject.name;
   }
}
}
