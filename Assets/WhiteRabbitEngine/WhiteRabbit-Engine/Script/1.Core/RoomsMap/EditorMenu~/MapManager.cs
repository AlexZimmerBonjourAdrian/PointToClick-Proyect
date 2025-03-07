using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The MapManager class is responsible for managing the in-game map, including its UI,
/// room representation, and the player's current location within the map.
/// 
/// **Key Responsibilities:**
/// 1. **Map UI Management:** Controls the visibility of the map UI (opening and closing).
/// 2. **Room Representation:** Creates and manages RoomNode objects that represent rooms on the map.
/// 3. **Current Room Tracking:** Keeps track of the player's current room using the `currentRoomNode` variable.
/// 4. **Room Lookup:** Provides a fast lookup mechanism for rooms using the `roomNodes` dictionary.
/// 5. **Map Update:** Updates the map's state when the player moves to a new room.
/// 6. **Room Icon:** use a prefab to create an instance in the map to represent a room.
/// 
/// **How it Works:**
/// 1. **Initialization (Start):**
///    - The `Start()` method initializes the `roomNodes` dictionary, which will store the rooms of the map.
/// 2. **Updating the Map (UpdateMap):**
///    - The `UpdateMap(int currentRoomId)` method is called whenever the player enters a new room.
///    - It takes the ID of the current room as a parameter.
///    - It checks if a RoomNode with the given ID already exists in the `roomNodes` dictionary.
///    - If the room exists, it sets `currentRoomNode` to the corresponding RoomNode.
///    - If the room doesn't exist, it throws an exception. This means that all rooms must be previously added to the roomNodes Dictionary.
/// 3. **Opening the Map (OpenMap):**
///    - The `OpenMap()` method sets the `MapUI` GameObject to active, making the map visible to the player.
/// 4. **Closing the Map (CloseMap):**
///    - The `CloseMap()` method sets the `MapUI` GameObject to inactive, hiding the map from the player.
/// 5. **Room Representation:**
///     - In the variable roomNodes we store a diccionary.
///     - Each key is an ID, an unique ID of the room.
///     - Each value is a RoomNode.
///     - RoomNode class is not provided but is assumed to hold data about a room (e.g., name, connected rooms, position on the map).
/// 6. **Room Icon Prefab:**
///     - The room is visually represented in the map by the RoomIconPrefab.
///     - The RoomNode class is the responsible to Instantiate this icon.
///
/// **How to Use:**
/// 1. **Create a MapUI:** Create a UI element (e.g., a Canvas) in your scene and assign it to the `MapUI` public variable in the Inspector.
/// 2. **Create a RoomIconPrefab:** Create a prefab that represents a room on the map and assign it to the `RoomIconPrefab` public variable in the Inspector.
/// 3. **Create the rooms:** before to call the UpdateMap, add all the rooms to the roomNodes dictionary.
/// 4. **Instantiate the MapManager:** Add the MapManager script to a GameObject in your scene.
/// 5. **Call UpdateMap:** When the player moves to a new room, call `MapManager.UpdateMap(roomId)` with the ID of the new room.
/// 6. **Open/Close the Map:** Call `MapManager.OpenMap()` and `MapManager.CloseMap()` to control the visibility of the map UI.
///
/// **Future Improvements:**
/// 1. **RoomNode Creation:** Implement logic to create RoomNode objects and add them to the `roomNodes` dictionary when a room is created or loaded.
/// 2. **Map Visualization:** Implement the visualization of the rooms in the MapUI.
/// 3. **Connection Representation:** Add the logic to display the connections between the rooms in the map.
/// 4. **Map Zoom/Panning:** Add functionality to allow the player to zoom and pan the map.
/// 5. **Current Room Highlight:** Add logic to highlight the `currentRoomNode` on the map.
/// 6. **More data in the RoomNode:** Add more data to the RoomNode class.
/// 7. **Use the map data:** Use the map data class to load the rooms.
/// 8. **Save the map:** Add the logic to save and load the map.
///
/// **Current Limitations:**
/// 1. **No Room Creation:** Currently, there's no code to create RoomNode objects or add them to the `roomNodes` dictionary.
///    - The developer must add the rooms to the roomNodes before to call the UpdateMap
/// 2. **No Visual Map:** There's no code to display the map visually or represent the connections between rooms.
/// 3. **No Room data** No data is added to the RoomNode.
/// 4. **No Load/Save map:** The map is not saved or loaded.
/// </summary>
public class MapManager : MonoBehaviour
{
     /// <summary>
     /// The UI element that represents the in-game map.
     /// Assign your map UI GameObject here in the Inspector.
     /// </summary>
     public GameObject MapUI; 
     /// <summary>
     /// A prefab representing a room icon on the map.
     /// This prefab will be instantiated on the map to visually represent a room.
     /// </summary>
     public GameObject RoomIconPrefab;
 
     /// <summary>
     /// The RoomNode that represents the player's current location.
     /// </summary>
     private RoomNode currentRoomNode; 
     /// <summary>
     /// A dictionary that stores all the RoomNodes in the map, keyed by their unique room ID.
     /// This allows for fast lookup of rooms by their ID.
     /// </summary>
     public Dictionary<int, RoomNode> roomNodes; 
 
    
  
     private void Start()
     {
         // Initialize the roomNodes dictionary when the game starts.
         roomNodes = new Dictionary<int, RoomNode>();
       
     }
 
     /// <summary>
     /// Updates the map to reflect the player's current room.
     /// </summary>
     /// <param name="currentRoomId">The ID of the room the player is currently in.</param>
     /// <exception cref="Exception">Throws an exception if a room with the given ID doesn't exist in the map.</exception>
     public void UpdateMap(int currentRoomId)
     {
         // Check if the room with the given ID exists in the roomNodes dictionary.
         if (roomNodes.ContainsKey(currentRoomId))
         {
             // If it exists, set the currentRoomNode to the corresponding RoomNode.
             currentRoomNode = roomNodes[currentRoomId];
            
         }
         else
         {
             // If the room doesn't exist, throw an exception.
             throw new Exception("La habitación con ID " + currentRoomId + " no existe en el mapa.");
         }
      
     }
 
     /// <summary>
     /// Opens the map UI, making it visible to the player.
     /// </summary>
     public void OpenMap()
     {
         // Activate the MapUI GameObject.
         MapUI.SetActive(true);
     }
 
     /// <summary>
     /// Closes the map UI, hiding it from the player.
     /// </summary>
     public void CloseMap()
     {
         // Deactivate the MapUI GameObject.
         MapUI.SetActive(false);
     }
 }
  }
 

