using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 namespace WhiteRabbit.Core
  {

/// <summary>
/// The CGameManager class serves as the central hub for managing the overall game state and coordinating various game systems.
/// It utilizes the Singleton pattern to ensure that only one instance of this manager exists throughout the game's lifecycle.
/// This class is designed to persist across scene changes and maintain global game data.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures a single, global instance of the GameManager.
/// 2. **Persistence:** Persists across scene loads using `DontDestroyOnLoad`.
/// 3. **Manager References:** Holds references to other essential managers like the `CManagerSFX`.
/// 4. **Game State Tracking:** Manages fundamental game state variables, including:
///     - `score`: The player's current score.
///     - `currentLevel`: The level the player is currently in.
///     - `playerLives`: The number of lives the player has remaining.
///     - `progressPorcement`: A progress value.
///     - `isEndGame`: A flag indicating whether the game has ended.
/// 5. **Scene Management:** Provides the potential for handling scene loading and transitions, although currently only a private `_CurrentLoadScene` exists.
/// 6. **Room Navigation:** Implements a method `MoveLocation` to control the activation of rooms (locations).
/// 7. **Central Access Point:** Provides a single access point (`CGameManager.Inst`) for other scripts to interact with global game data and systems.
/// 
/// **How to Use:**
/// 1. **Accessing the Manager:** Other scripts can access the CGameManager using `CGameManager.Inst`.
/// 2. **Accessing Game State:** Retrieve or modify game state variables directly (e.g., `CGameManager.Inst.score = 100;`).
/// 3. **Referencing Other Managers:** Access other managers through this manager. For example, using CManagerSFX `CGameManager.Inst.sfxManager.PlaySFX()`.
/// 4. **Moving Between Locations (Rooms):** Call `CGameManager.Inst.MoveLocation(int id)` to activate a specific room, given its id.
///     - You need to add a `CLevelGeneric` component to a Gameobject in order to use this method.
///     - If not an error will be throw.
/// 
/// **Future Improvements:**
/// - Implement the `_CurrentLoadScene` or other method to manage the scene.
/// - Add more data management functionality (e.g., saving/loading more complex data).
/// - Add events or callbacks to notify other scripts when game data changes.
/// - Add more methods to control the game.
/// - Add more functionality to control the state of the game.
/// - Refactor the name of the variables to be more clear.
/// - Add methods to control the player lives.
/// - Add methods to control the progress porcent.
/// 
/// **Current Limitations**
/// - The scene control is not implemented.
/// - There is no saving/loading of data.
/// - There are not events.
/// - The `_CurrentLoadScene` is not used.
/// - the `progressPorcement` and `isEndGame` are not used.
/// </summary>
public class CGameManager : MonoBehaviour
{
    // Referencias a otros managers
    /// <summary>
    /// Reference to the CManagerSFX, which manages sound effects in the game.
    /// </summary>
    public CManagerSFX sfxManager;

    // Estado del juego
    /// <summary>
    /// The player's current score.
    /// </summary>
    public int score;
    /// <summary>
    /// The current level the player is in.
    /// </summary>
    public int currentLevel;
    /// <summary>
    /// The number of lives the player has.
    /// </summary>
    public int playerLives;

    /// <summary>
    /// The progress of the player. This varible is not used in this moment.
    /// </summary>
    public float progressPorcement;

    /// <summary>
    /// A flag indicating if the game is end. This varible is not used in this moment.
    /// </summary>
    public bool isEndGame;

    //Singleton
    /// <summary>
    /// Singleton instance of the CGameManager.
    /// Provides a global access point to the game management functionality.
    /// </summary>
     public static CGameManager Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CGameManager component.
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameManager");
                return obj.AddComponent<CGameManager>();
            }
            return _inst;

        }
    }
    private static CGameManager _inst;

    /// <summary>
    /// Stores the reference to the current asynchronous scene loading operation.
    /// This varible is not used in this moment.
    /// </summary>
    private AsyncOperation _CurrentLoadScene;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CGameManager exists (Singleton pattern).
    /// It also ensures that this object will be no destroy when a new scene is load.
    /// </summary>
   public void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        //This line makes the GameObject persist across scene loads.
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }

    /// <summary>
    /// Activates a room (location) in the game based on its ID.
    /// </summary>
    /// <param name="id">The ID of the room to activate.</param>
  public void MoveLocation(int id)
  {
     // Find the active CLevelGeneric component in the scene.
     CLevelGeneric Level = FindAnyObjectByType<CLevelGeneric>();

     //Log the level name.
     Debug.Log(Level.name);
    //call to the method to active the room.
     Level.SetRoomActive(id,true);
  }
}
}
