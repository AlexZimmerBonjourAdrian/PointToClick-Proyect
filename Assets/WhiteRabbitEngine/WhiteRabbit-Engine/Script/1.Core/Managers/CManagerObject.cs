using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class is a singleton that manages all the objects in the game.
/// It allows other classes to access the objects in the game.
/// </summary>

 
 namespace WhiteRabbit.Core
  {

public class CManagerObject : MonoBehaviour
{
    //Por ahora, hay que ignorarlo
   //En cada nivel debe guardar todos lso objetos en el nivel en el que este Que tengan un CObjectInventorie Como padre

    /// <summary>
    /// Singleton instance of the CManagerObject.
    /// Provides a global access point to the object management functionality.
    /// </summary>
     public static CManagerObject Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CManagerObject component.
            if (_inst == null)
            {
                Debug.Log("CManagerObject instance not found, creating a new one.");
                GameObject obj = new GameObject("ObjectManager"); // Changed name for clarity
                return obj.AddComponent<CManagerObject>();
            }
            Debug.Log("CManagerObject instance found.");
            return _inst;

        }
    }
    private static CManagerObject _inst;

  /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CManagerObject exists (Singleton pattern).
    /// It also marks this GameObject to persist across scene loads.
    /// </summary>
  public void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject); // This line makes the GameObject persist across scene loads.
        _inst = this;
    }
    
    //------------------------------------------
    // How this class is intended to function:
    //------------------------------------------
    /*
    *  Intended Functionality:
    *
    *  1. Centralized Object Management:
    *     - This class aims to be the central hub for managing all interactive and important objects in the game.
    *     - This means it will keep track of things like items, clues, or any other GameObject that the player might interact with.
    *
    *  2. Level-Specific Object Tracking:
    *     - Each level (or scene) in the game will have its own set of objects that this manager should be aware of.
    *     - The intention is to have this manager store a list of objects that belong to the currently loaded level.
    *     - It is ment to only manage the objects from a level.
    *
    *  3. Object Inventory (CObjectInventorie):
    *     - The comment mentions "CObjectInventorie". This suggests that each object managed by this class will have a `CObjectInventorie` component attached to it.
    *     - `CObjectInventorie` is likely a custom script (not shown in the provided files) that holds data about an object, such as its properties, state, or inventory-related information.
    *
    *  4. Global Access:
    *     - As a singleton, other scripts in the game can easily access `CManagerObject` through `CManagerObject.Inst`.
    *     - This allows any other class to easily query the manager to get lists of objects, find specific objects, or perform operations on objects.
    *
    * 5. Persistent Across Scenes:
    *    - DontDestroyOnLoad is call in Awake method. Because this, this object will be no destroy when a new scene is load.
    *    - This is necesary as this manager need to hold the status of the object for all the game.
    *
    * 6. Future Implementations:
    *   - This class currently does not implement any methods to handle object. This means that we need to implemnt more logic in order to use this class.
    *  
    *  Example (Hypothetical Use Case):
    *
    *  - Imagine a puzzle where the player needs to collect three keys.
    *  - Each key would be a GameObject with a `CObjectInventorie` component.
    *  - When the level loads, `CManagerObject` would find all objects with a `CObjectInventorie` and store them in its internal list.
    *  - A `PuzzleScript` could then ask `CManagerObject` how many keys have been collected or where a specific key is located.
    *  - It can be also call to know if an object was collect or not.
    * 
    */

     //------------------------------------------
    // Current Limitations:
    //------------------------------------------
     /*
    *  1. Empty: 
    *      - At this moment, the manager does not implement any methods to manage the objects.
    *   
    * 2. No public method
    *   - This class only implements the methods related to a singleton.
    *   - Need to add methods to find objects, get objects. etc...
    */
}
}
