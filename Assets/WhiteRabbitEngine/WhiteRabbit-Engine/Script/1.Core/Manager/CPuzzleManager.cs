using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
/// <summary>
/// This class is a singleton that manages all the puzzles in the game.
/// It allows other classes to access and interact with the puzzles.
/// It is responsible for controlling the overall puzzle state and coordinating different puzzle types.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures only one instance of CPuzzleManager exists throughout the game, providing a central point of access.
/// 2. **Puzzle Management:** Holds the logic to manage and control all the puzzles present in the game.
/// 3. **Puzzle Interaction:** Allows other classes to interact with and manipulate the puzzles (e.g., activate, solve, reset).
/// 4. **Puzzle State Tracking:** Keeps track of the current state of each puzzle (e.g., solved, active, inactive).
/// 5. **Puzzle Type Handling:** Responsible for handling different types of puzzles (e.g., inventory-based, logic-based, sequence-based).
/// 6. **Persistence:** Using DontDestroyOnLoad to keep the manager between scene.
/// 
/// **How to Use:**
/// 1. **Accessing the Manager:** Other scripts can access the puzzle manager using `CPuzzleManager.Inst`.
/// 2. **Puzzle Creation:**  Puzzles (likely custom classes or prefabs) should be registered with the manager upon initialization or instantiation.
///     - this is not implement yet. This is an intended functionality
/// 3. **Puzzle Interaction:** Other game components (e.g., player, objects) can interact with puzzles via methods provided by the manager.
///     - this is not implement yet. This is an intended functionality
/// 4. **Puzzle State Checks:** The manager can be queried to determine if a puzzle is solved or what its current state is.
///     - this is not implement yet. This is an intended functionality
/// 5. **Puzzle Events:** The manager can trigger events when a puzzle is solved, activated, or reset.
///      - this is not implement yet. This is an intended functionality
///
/// **Future Implementations:**
/// 1. **Puzzle Registration:** Add functionality to allow different puzzles to be registered to the manager.
/// 2. **Puzzle Methods:** Implement methods to activate, deactivate, solve, or reset individual puzzles.
/// 3. **Puzzle State:** Add a state for the puzzles and methods to change or know the state of the puzzles.
/// 4. **Puzzle Events:** Add events that can be triggered when a puzzle's state changes.
/// 5. **Puzzle Data:** Add logic to save the state of the puzzles.
/// 6. **Puzzle type:** Add logic to manage the different types of puzzles.
/// </summary>

 namespace WhiteRabbit.Core
  {

public class CPuzzleManager : MonoBehaviour
{
    //Responsable de controlar todos los puzzles y de cada tipo 

    /// <summary>
    /// Singleton instance of the CPuzzleManager.
    /// Provides a global access point to the puzzle management functionality.
    /// </summary>
    public static CPuzzleManager Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CPuzzleManager component.
            if (_inst == null)
            {
                Debug.Log("CPuzzleManager instance not found, creating a new one.");
                GameObject obj = new GameObject("PuzzleManager");
                return obj.AddComponent<CPuzzleManager>();
            }
            Debug.Log("CPuzzleManager instance found.");
            return _inst;

        }
    }
    private static CPuzzleManager _inst;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CPuzzleManager exists (Singleton pattern).
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
}
}
