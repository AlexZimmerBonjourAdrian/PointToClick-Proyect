using System;
using System.Collections.Generic;
using UnityEngine;
 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// MapData is a ScriptableObject that stores and manages data related to a collection of rooms within a game.
/// It serves as a data container for defining the structure of the game's map, including room information and their connections.
/// This class is designed to be used with the Unity Editor, allowing for easy creation and editing of map data.
/// </summary>
[CreateAssetMenu(fileName = "MapData", menuName = "PointToClickEngine/MapData")]
[Serializable]
public class MapData : ScriptableObject
{    
    /// <summary>
    ///  A list that stores all the rooms contained in this map.
    ///  Each element in the list is of type `StructRoom.Room`, which represents a single room with its properties.
    ///  `StructRoom.Room` is a custom struct (not shown in the provided code, but assumed to exist) that likely holds data like room ID, name, connected rooms, etc.
    /// </summary>
    public List<StructRoom.Room> rooms;

    /// <summary>
    /// A dictionary that maps room IDs (int) to `StructRoom.Room` objects.
    /// This provides a quick lookup mechanism to find a specific room by its ID.
    /// The keys are the unique IDs of the rooms, and the values are the corresponding `StructRoom.Room` objects containing the room's data.
    /// </summary>
    public Dictionary<int, StructRoom.Room> roomNodes = new Dictionary<int, StructRoom.Room>();
    
    /// <summary>
    /// Returns the list of rooms.
    /// This function allow other classes to get all the room from the map data.
    /// This function is used to get the information about the rooms.
    /// </summary>
    /// <returns>A list of `StructRoom.Room` objects representing all the rooms in the map.</returns>
    public List<StructRoom.Room> GetRooms()
    {
        return rooms;
    }

    //------------------------------------------
    // How this class is intended to function:
    //------------------------------------------
     /*
    *  Intended Functionality:
    *
    *  1. Centralized Map Management:
    *     - This class aims to be the central hub for managing all rooms in the game.
    *     - This means it will keep track of all rooms, its attributes and connections.
    *
    *  2. Data Structure:
    *     - Use a List to hold all the rooms.
    *     - Use a Dictionary to quick access to a specific room by id.
    *
    *  3. Scriptable object
    *     - Using a scriptable object, this class is easy to save and load.
    *     - It allows to edit and visualize the data from the editor.
    *     - It makes easy to have multiple maps.
    *
    * 4. Data container:
    *   - At this moment, this class only contains data and a method to access to that data.
    *   - It does not have methods to search, change, delete or add data.
    *
    * 5. Future Implementations:
    *   - This class currently does not implement any methods to handle rooms. This means that we need to implemnt more logic in order to use this class.
    *   - Add methods to search a room by name, by id or by connections.
    *   - Add methods to add or remove rooms.
    *   - Add a method to change a room values.
    *  
    *  Example (Hypothetical Use Case):
    *
    *  - Imagine a map with 5 rooms.
    *  - Each room will be add to the rooms list.
    *  - Also, each room will be add to the roomNodes dictionary with its id.
    *  - The level manager will load this scriptable object.
    *  - Then, the level manager can call the GetRooms() method to get all the rooms.
    *  - Also, the level manager can get a specific room by calling the roomNodes with the room id.
    * 
    */

     //------------------------------------------
    // Current Limitations:
    //------------------------------------------
     /*
    *  1. Empty: 
    *      - At this moment, the class does not implement any methods to manage the rooms.
    *   
    * 2. No public method (besides GetRooms())
    *   - This class only implements the methods related to a data container.
    *   - Need to add methods to find rooms, add rooms, delete rooms, modify rooms. etc...
    */
}
}
