using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using WhiteRabbit.Core;

/// <summary>
/// CFlashBackManager is a MonoBehaviour singleton responsible for managing the playback of flashback sequences.
/// It handles loading scenes, displaying dialogues, and navigating through the different parts of a flashback.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures that only one CFlashBackManager exists throughout the game, allowing easy access from any script.
/// 2. **Flashback Management:** Controls the playback of a flashback defined by a CFlashBackData object.
/// 3. **Scene Loading:** Loads scenes associated with each part of the flashback sequence.
/// 4. **Dialogue Display:** Displays dialogue text from the CFlashBackData.
/// 5. **UI Integration:** Manages UI elements such as dialogue text, background image, and navigation buttons.
/// 6. **Navigation:** Allows players to navigate forward and backward through the flashback scenes.
/// 7. **Persistence:** Persists across scene changes to maintain the flashback state.
/// 8. **End Flashback**: Return to the main scene when the flashback end.
/// 
/// **How it works:**
/// 1. **Initialization:**
///    - The `Awake()` method implements the singleton pattern, ensuring only one instance exists and persists across scenes using `DontDestroyOnLoad`.
///    - UI elements (dialogue text, background image, buttons) must be assigned in the Unity Editor's Inspector.
/// 2. **Starting a Flashback:**
///    - `StartFlashback(CFlashBackData flashback)` is called with a CFlashBackData object, which contains the data of the flashback.
///    - It initializes the current flashback data and scene index, then loads the first scene.
/// 3. **Loading Scenes:**
///    - `LoadCurrentScene()`: Loads the scene based on the `currentSceneIndex` and the scene name defined in the `CFlashBackData`.
///    - It also sets the background image and prepares to display dialogue.
/// 4. **Displaying Dialogue:**
///    - `DisplayNextDialogueLine()`: Displays the next line of dialogue from the current scene.
///    - If there are no more dialogue lines in the current scene, the dialogue text is cleared.
///    - The method also remove the dialogue from the list, to avoid repeat dialogs.
/// 5. **Navigation:**
///    - `NextScene()`: Moves to the next scene in the flashback. If it's the last scene, it calls `EndFlashback()`.
///    - `PreviousScene()`: Moves to the previous scene.
///    - `UpdateNavigationButtons()`: Enables or disables the Next and Previous buttons based on the current scene index.
/// 6. **Ending a Flashback:**
///    - `EndFlashback()`: Clears the flashback data, resets the scene index, and returns to the main scene (scene index 0).
/// 7. **Updating:**
///     - `Update()`: is used to show the next dialog using the space bar.
/// 
/// **How to use:**
/// 1. **Create a CFlashBackManager GameObject:** Add an empty GameObject to your scene and attach this script.
/// 2. **Create CFlashBackData Assets:** Create instances of `CFlashBackData` in the Project window (right-click -> Create -> Flashback Data) and configure each flashback with scenes, dialogue, etc.
/// 3. **Assign UI Elements:** In the CFlashBackManager component in the Inspector, assign the Text object for dialogue (`dialogueText`), the Image object for the background (`backgroundImage`), and the Next and Previous buttons (`nextButton`, `previousButton`).
/// 4. **Trigger a Flashback:** Call `CFlashBackManager.Instance.StartFlashback(yourFlashbackData)` from another script to start a flashback. For example, you can call this method when a player interacts with a specific object.
/// 5. **Scene Setup:** Ensure your game has scenes set up in the Build Settings, and that the names of the scenes in the `CFlashBackData` objects match the scene names in the Build Settings.
/// 6. **UI Canvas:** The UI elements (`dialogueText`, `backgroundImage`, `nextButton`, `previousButton`) should be part of a UI Canvas in your scene.
/// 
/// **Future improvements:**
/// - Add the posibility to handle the dialogues with yarn.
/// - Add a method to cancel the flashback.
/// - Add the posibility to replay a flashback.
/// - Add events when the flashback start, next scene, previous scene or end.
/// - Add more controls to the flashback (for example pause).
/// - add a callback when the scene load is finish.
/// - add a transition when change between scene.
/// 
/// **Current Limitations:**
/// - The implementation of the scene loading is basic, using `SceneManager.LoadSceneAsync()`. For production, you might need a more sophisticated scene loading system.
/// - Only have basic UI.
/// -  The UI elements are assumed to be in a persistent scene, or a scene that is always loaded. If they are in a scene that is unloaded, they will be destroyed.
/// - The current code assume that all the scene are added in the build index, this means that the main scene is the scene number 0.
/// - The dialogs are display in order, without any control.
/// </summary>
public class CFlashBackManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the CFlashBackManager.
    /// Provides a global access point to the flashback management functionality.
    /// </summary>
    public static CFlashBackManager Instance { get; private set; } // Singleton instance

    /// <summary>
    /// The current flashback data that is being played.
    /// </summary>
    private CFlashBackData currentFlashback;
    /// <summary>
    /// The index of the current scene within the flashback.
    /// </summary>
    private int currentSceneIndex = 0;
    // Add UI elements here (e.g., Text for dialogue, Image for background, Buttons for navigation)
    /// <summary>
    /// The Text UI element to display dialogue.
    /// </summary>
    public UnityEngine.UI.Text dialogueText;
    /// <summary>
    /// The Image UI element to display the background image of the scene.
    /// </summary>
    public UnityEngine.UI.Image backgroundImage;
    /// <summary>
    /// The Button UI element to move to the next scene.
    /// </summary>
    public UnityEngine.UI.Button nextButton;
    /// <summary>
    /// The Button UI element to move to the previous scene.
    /// </summary>
    public UnityEngine.UI.Button previousButton;



    private void Awake()
    {
        // Singleton implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }

    /// <summary>
    /// Starts the flashback sequence.
    /// </summary>
    /// <param name="flashback">The CFlashBackData object containing the flashback information.</param>
    public void StartFlashback(CFlashBackData flashback)
    {
        currentFlashback = flashback;
        currentSceneIndex = 0;
        LoadCurrentScene();



    }

    /// <summary>
    /// Loads the current scene in the flashback sequence.
    /// </summary>
    private void LoadCurrentScene()
    {
        if (currentFlashback == null || currentFlashback.Scenes.Count == 0)
        {
            Debug.LogError("No flashback data or scenes found!");
            return;
        }



        CFlashBackData.SceneData currentScene = currentFlashback.Scenes[currentSceneIndex];
        // Load the scene (replace with your actual scene loading method)
        SceneManager.LoadSceneAsync(currentScene.SceneName);

        // Set the background image
        backgroundImage.sprite = currentScene.BackgroundImage;


        // Start displaying the dialogue for the current scene
        DisplayNextDialogueLine();

        // Update navigation buttons
        UpdateNavigationButtons();
    }

    /// <summary>
    /// Displays the next line of dialogue in the current scene.
    /// </summary>
    private void DisplayNextDialogueLine()
    {
         CFlashBackData.SceneData currentScene = currentFlashback.Scenes[currentSceneIndex];


        if(currentScene.DialogueLines.Count > 0)
        {
            CFlashBackData.DialogueLine currentLine = currentScene.DialogueLines[0];
            dialogueText.text = currentLine.DialogueText;
            currentScene.DialogueLines.RemoveAt(0); //this line remove the dialog to avoid repeat it.
        }
        else
        {
            dialogueText.text = "";
        }
    }

    /// <summary>
    /// Moves to the next scene in the flashback sequence.
    /// </summary>
    public void NextScene()
    {
        currentSceneIndex++;
        if (currentSceneIndex < currentFlashback.Scenes.Count)
        {
            LoadCurrentScene();
        }
        else
        {
            EndFlashback();
        }
        UpdateNavigationButtons();
    }

    /// <summary>
    /// Moves to the previous scene in the flashback sequence.
    /// </summary>
    public void PreviousScene()
    {
        currentSceneIndex--;
        if (currentSceneIndex >= 0)
        {
            LoadCurrentScene();
        }
        UpdateNavigationButtons();


    }

    /// <summary>
    /// Updates the interactability of the navigation buttons based on the current scene index.
    /// </summary>
    private void UpdateNavigationButtons()
    {

        previousButton.interactable = currentSceneIndex > 0;
        nextButton.interactable = currentSceneIndex < currentFlashback.Scenes.Count - 1;


    }


    /// <summary>
    /// Ends the flashback sequence and returns to the main scene.
    /// </summary>
    private void EndFlashback()
    {
        currentFlashback = null;
        currentSceneIndex = 0;

        
        SceneManager.LoadSceneAsync(0); //load the main scene.
    }



    /// <summary>
    /// This method is call every frame.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           DisplayNextDialogueLine();

        }
    }
    
}
