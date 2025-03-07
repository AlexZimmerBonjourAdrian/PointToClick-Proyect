using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Dynamic;
using UnityEditor;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The Principal class serves as the central manager for the game's core functionality.
/// It acts as a singleton, ensuring that only one instance of this class exists throughout the game's lifecycle.
/// This class is designed to persist across scene changes and manage global game data and operations.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures a single, global instance of the Principal manager.
/// 2. **Persistence:** Persists across scene loads using `DontDestroyOnLoad`.
/// 3. **Global ID Management:** Manages a global ID that can be saved and loaded.
/// 4. **Save/Load System:** Implements methods to save and load game data using `PlayerPrefs`.
/// 5. **Central Access Point:** Provides a single access point (`Principal.Inst`) for other scripts to interact with global game data and systems.
/// 6. **Potential for Expansion:** It has a placeholder for future "InteractObjects" functionality, indicating it can be expanded to handle broader game interactions.
/// 
/// **How to Use:**
/// 1. **Accessing the Manager:** Other scripts can access the Principal manager using `Principal.Inst`.
/// 2. **Saving Data:** Call `Principal.Inst.Save()` to save the current ID to `PlayerPrefs`.
/// 3. **Getting the ID:** Use `Principal.Inst.GetId()` to retrieve the current global ID.
/// 4. **Setting the ID:** Use `Principal.Inst.SetId(int id)` to set a new value for the global ID.
/// 5. **ID Persistence:** The ID is automatically loaded from `PlayerPrefs` when the game starts if a saved ID exists.
/// 
/// **Future Improvements:**
/// - Implement the `InteractObjects` method to manage interactions with objects in the game world.
/// - Add more data management functionality (e.g., saving/loading more complex data).
/// - Add events or callbacks to notify other scripts when data changes.
/// - Consider a more robust saving system instead of PlayerPrefs.
/// - Consider implement more methods to manage other global systems.
/// 
/// **Current Limitations**
/// - The InteractObjects is not used.
/// - Only the ID is saved.
/// - Only PlayerPrefs is used to save the data.
/// </summary>
public class Principal : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the Principal.
    /// Provides a global access point to the principal management functionality.
    /// </summary>
    public static Principal Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the Principal component.
            if (_inst == null)
            {
                GameObject obj = new GameObject("Principal");
                return obj.AddComponent<Principal>();
            }

            return _inst;
        }
    }

    private static Principal _inst;

    /// <summary>
    /// The global ID that is managed by this class.
    /// </summary>
    public int ID;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of Principal exists (Singleton pattern).
    /// It also ensures that this object will be no destroy when a new scene is load.
    /// </summary>
    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        //This line makes the GameObject persist across scene loads.
        DontDestroyOnLoad(gameObject);
        _inst = this;

        // Load the ID from PlayerPrefs if it exists.
        if(PlayerPrefs.HasKey("ID"))
        {
            ID = PlayerPrefs.GetInt("ID");
        }

    }

    /// <summary>
    /// Saves the current ID to PlayerPrefs.
    /// </summary>
    public void Save()
    {
        PlayerPrefs.SetInt("ID", ID);
    }

    /// <summary>
    /// Gets the current ID.
    /// </summary>
    /// <returns>The current ID.</returns>
    public int GetId()
    {
        return ID;
    }

    /// <summary>
    /// Sets a new ID.
    /// </summary>
    /// <param name="id">The new ID to set.</param>
    public void SetId(int id)
    {
        ID = id;
    }

    /// <summary>
    /// This method is intended to manage interactions with objects in the game world.
    /// However, it is currently not implemented.
    /// </summary>
    public void InteractObjects()
    {
       
    }

    
}
}
