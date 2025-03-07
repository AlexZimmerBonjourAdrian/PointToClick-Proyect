using UnityEngine;
using System.Collections.Generic; // For List
using WhiteRabbit.Core;

/// <summary>
/// CFlashBackData is a ScriptableObject that defines the data for a flashback sequence in the game.
/// It structures the scenes, dialogues, and other elements involved in a flashback.
/// This class acts as a data container for a flashback, defining the sequence of events and scenes within it.
/// 
/// **Key Responsibilities:**
/// 1. **Flashback Definition:** Defines a single flashback, including its unique ID, name, and the sequence of scenes and dialogues it contains.
/// 2. **Scene Management:** Holds a list of `SceneData`, each representing a scene within the flashback, including the scene's name, background image, and associated dialogues.
/// 3. **Dialogue Management:** Contains a list of `DialogueLine` for each scene, specifying the character's name, dialogue text, and optional voice clip.
/// 4. **Played Status Tracking:** Tracks whether the flashback has already been played using the `_hasPlayed` flag.
/// 5. **Flashback Initiation:** Provides a method (`StartFlashback`) to initiate the flashback sequence, typically managed by a separate FlashbackManager.
/// 6. **Prevent replay:** the method StartFlashBack prevent replay the flashback if it is already played.
/// 
/// **How It Works:**
/// - This class is designed to be used with the Unity Editor's ScriptableObject system, allowing easy creation and editing of flashback data.
/// - Each flashback is uniquely identified by an `Id` and can have a descriptive `FlashbackName`.
/// - `Scenes` list: defines the structure of the flashback.
///   - each `SceneData` contains a scene name, a background image, and a list of dialogs.
///     - `DialogueLines` list: each `DialogueLine` holds a character's name, dialogue text, and an optional voice clip.
/// - `StartFlashback()` method:
///   - checks if the flashback has already been played (`HasPlayed`).
///   - If not, it should trigger the `FlashbackManager` to start the flashback using `FlashbackManager.Instance.StartFlashback(this);`.
///   - sets the `_hasPlayed` flag to true to prevent replaying the flashback.
/// - `_hasPlayed` and `HasPlayed`:
///   - `_hasPlayed` is a private boolean that tracks whether the flashback has been played.
///   - `HasPlayed` is a public read-only property that provides access to the `_hasPlayed` flag.
/// 
/// **How to Use:**
/// 1. **Create Flashback Data:** In the Unity Editor, create a new `CFlashBackData` asset by right-clicking in the Project window and selecting "Flashback Data".
/// 2. **Populate Data:** Fill in the `Id`, `FlashbackName`, and add `SceneData` elements to define the scenes within the flashback.
/// 3. **Define Scenes:** For each `SceneData`, specify the `SceneName`, `BackgroundImage`, and add `DialogueLine` elements.
/// 4. **Add Dialogue:** For each `DialogueLine`, add the `CharacterName`, `DialogueText`, and optionally a `VoiceClip`.
/// 5. **Initiate Flashback:** In another script (e.g., a trigger or event handler), call the `StartFlashback()` method of a `CFlashBackData` instance to begin the flashback sequence.
/// 6. **Flashback Manager:** there should be a `FlashbackManager` that handle the flashback logic.
/// 
/// **Example Use Cases:**
/// - **Storytelling:** Create flashback sequences to reveal past events or character backstories.
/// - **Tutorials:** Use flashbacks as interactive tutorials to teach the player about game mechanics.
/// - **Memory Sequences:** Create fragmented memories that unlock as the player progresses.
/// 
/// **Future Improvements:**
/// - **Conditional Scenes:** Add support for branching flashback paths based on player choices or game state.
/// - **Scene Transitions:** Implement custom scene transitions (e.g., fade effects) between flashback scenes.
/// - **Advanced Dialogue:** Integrate with a dialogue system (like Yarn Spinner) for more complex dialogue interactions.
/// - **More data:** add more data to the scene or the dialogue line.
/// - **More control:** add more control in the flashback (pause, resume, etc...)
/// 
/// **Current Limitations:**
/// - **Linear Flashbacks:** The current design only supports linear flashback sequences.
/// - **No Active Management:** It's only a data container, requiring an external FlashbackManager to handle the playback logic.
/// - **Basic Scene/Dialogue Structure:** The scene and dialogue data structure is relatively simple and could be expanded for more complex needs.
/// - **No conditional logic**: the flashback is only linear, it does not support any conditional logic.
/// </summary>
[CreateAssetMenu(fileName = "New Flashback Data", menuName = "Flashback Data")] // Easier creation in the editor
public class CFlashBackData : ScriptableObject
{
    /// <summary>
    /// Unique identifier for this flashback.
    /// </summary>
    public int Id;
    /// <summary>
    /// Descriptive name for this flashback.
    /// </summary>
    public string FlashbackName; // Give each flashback a descriptive name

    // Scene Management
    /// <summary>
    /// List of scenes that compose this flashback.
    /// </summary>
    public List<SceneData> Scenes; 

    /// <summary>
    /// Represents a single scene within the flashback.
    /// </summary>
    [System.Serializable] // Make SceneData visible in the inspector
    public class SceneData
    {
        /// <summary>
        /// Name of the scene to load.
        /// </summary>
        public string SceneName; // Scene to load (build index or scene path)
        /// <summary>
        /// Optional background image for the scene.
        /// </summary>
        public Sprite BackgroundImage; // Optional background image for the scene
        /// <summary>
        /// List of dialogue lines for this scene.
        /// </summary>
        public List<DialogueLine> DialogueLines; // Dialogue for this scene
    }

    /// <summary>
    /// Represents a single line of dialogue within a scene.
    /// </summary>
    [System.Serializable]
    public class DialogueLine
    {
        /// <summary>
        /// Name of the character speaking this line.
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Text of the dialogue line.
        /// </summary>
        [TextArea] public string DialogueText;
        /// <summary>
        /// Optional voice acting clip for this line.
        /// </summary>
        public AudioClip VoiceClip; // Optional voice acting clip
    }

    /// <summary>
    /// Flag to track whether this flashback has already been played.
    /// </summary>
    [SerializeField, HideInInspector] private bool _hasPlayed = false;
    /// <summary>
    /// Public property to check if the flashback has been played.
    /// </summary>
    public bool HasPlayed => _hasPlayed;

    /// <summary>
    /// Starts the flashback sequence.
    /// </summary>
    public void StartFlashback() // More descriptive method name
    {
        // if the flashback is already play, return and do nothing.
        if (HasPlayed) return; // Don't replay in the same playthrough

       // FlashbackManager.Instance.StartFlashback(this);  // Use a FlashbackManager (see below)
       //it is necesary to have a FlashbackManager in order to manage the flashback.
        _hasPlayed = true; // set the flag to true, to avoid replay.
    }

    
}
