using UnityEngine;
using WhiteRabbit.Core;
 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// CQTEData is a ScriptableObject that stores the configuration data for a Quick Time Event (QTE).
    /// It allows designers to easily define the parameters of a QTE in the Unity Editor, 
    /// such as the type of QTE, the key to press, the duration, and other specific settings.
    /// 
    /// **Key Responsibilities:**
    /// 1. **QTE Configuration:** Holds all the necessary data to define the behavior of a specific QTE.
    /// 2. **ScriptableObject:** Enables easy creation, storage, and modification of QTE settings within the Unity Editor.
    /// 3. **Data Container:** Acts as a data container that is passed to the CQTEController to initialize a QTE.
    /// 4. **QTE Customization:** Allows for different types of QTEs and unique settings for each.
    /// 5. **Editor Friendly:** Makes it easy for designers to create and adjust QTEs without needing to write code.
    ///
    /// **How it Works:**
    /// - **Creation:** Create instances of this ScriptableObject in the Unity Editor (e.g., by right-clicking in the Project window and selecting "Create/Wherearethealices/QTE").
    /// - **Configuration:** Each instance contains the following information about a QTE:
    ///   - `QTEId`: A unique integer identifier for the QTE.
    ///   - `TypePuzzle`: An enum (`QTETypePuzzle`) that determines the type of QTE (e.g., KeyPress, Sequence, Selection).
    ///   - `KeyToPress`: The `KeyCode` that the player must press for KeyPress QTEs.
    ///   - `Duration`: The total duration of the QTE in seconds.
    ///   - `RequiredPresses`: The number of times the player needs to press the key for KeyPress QTEs.
    ///   - `IncrementSpeed`: A speed modifier for some QTE types.
    ///   - `DebugText`: A string used for debugging, displayed in the console when `DebugFunction` is called.
    ///   - `SuccessThreshold`: A value that define what is the success value.
    ///   - `PartialSuccessThreshold`: A value that define what is a partial success value.
    /// - **Usage:** The `CQTEController` reads the data from a `CQTEData` asset to start and manage the QTE.
    /// - **Debug Function:** the `DebugFunction()` method is used for debugging.
    /// 
    /// **How to Use:**
    /// 1. **Create QTE Assets:** In the Unity Editor, create new `CQTEData` assets for each QTE in your game.
    /// 2. **Set QTE Properties:** Set the properties of the QTE, including the type and specific settings in the Inspector.
    /// 3. **Assign to CQTEController:** Assign the created `CQTEData` asset to the `Data` field of the `CQTEController` in the scene.
    /// 4. **Trigger QTE:** Trigger the QTE from another script.
    /// 
    /// **Example Use Case:**
    /// - **Key Press QTE:** Create a `CQTEData` asset with `TypePuzzle` set to `KeyPress`, set the `KeyToPress` to `Space`, and set `Duration` and `RequiredPresses`.
    /// - **Sequence QTE:** Create a `CQTEData` asset with `TypePuzzle` set to `Sequence`, define the sequence order and the `Duration`.
    /// - **Selection QTE:** Create a `CQTEData` asset with `TypePuzzle` set to `Selection` and the `Duration`.
    /// - **Launch a Debug:** Call the DebugFunction() to launch a debug.
    /// 
    /// **Future Improvements:**
    /// - **More QTE Types:** Add more QTE types like "Hold Key," "Button Mash," or others.
    /// - **Complex Sequences:** Implement a more complex way to define sequences.
    /// - **Variable Thresholds:** Allow setting different success and failure thresholds.
    /// - **Visual Feedback Data:** Add properties to manage the visual feedback for the QTE.
    /// - **Event Handling:** Add properties to trigger specific events when the QTE succeeds or fails.
    ///
    /// **Current Limitations:**
    /// - **Fixed QTE Types:** The current implementation only supports a limited number of QTE types.
    /// - **Basic Sequence:** The way to define a sequence is very basic.
    /// - **Basic Thresholds:** The way to define the threshold is very basic.
    /// </summary>
[CreateAssetMenu(fileName = "New QTE", menuName = "Wherearethealices/QTE")]
[System.Serializable]
public class CQTEData : ScriptableObject

{
   
    /// <summary>
    /// A unique identifier for this QTE.
    /// </summary>
    public int QTEId;

    /// <summary>
    /// The type of QTE. This determines the interaction logic.
    /// </summary>
    public QTETypePuzzle TypePuzzle;
    /// <summary>
    /// The key that the player must press for KeyPress QTEs.
    /// </summary>
    public KeyCode KeyToPress; // Example for KeyPress type
    /// <summary>
    /// The duration of the QTE in seconds.
    /// </summary>
    public float Duration; 
    /// <summary>
    /// The number of times the player needs to press the key in KeyPress QTEs.
    /// </summary>
    public int RequiredPresses; 

    /// <summary>
    /// A speed modifier for the QTE.
    /// </summary>
    public float IncrementSpeed;
    /// <summary>
    /// A debug text to be displayed when the debug function is called.
    /// </summary>
    public string DebugText;

    /// <summary>
    /// The threshold for a successful QTE.
    /// </summary>
    public float SuccessThreshold;
    /// <summary>
    /// The threshold for a partially successful QTE.
    /// </summary>
    public float PartialSuccessThreshold;





    /// <summary>
    /// A debug function that prints the debug text to the console.
    /// </summary>
    public void DebugFunction()
    {
        Debug.Log(DebugText);
    }
   

}

/// <summary>
/// Enum representing different types of QTE push comportament.
/// </summary>
public enum QTETypePushComportament
{
    KeyPress,
    HoldKey,
    ButtonMash
};

/// <summary>
/// Enum representing different types of QTE puzzles.
/// </summary>
public enum QTETypePuzzle
{
    KeyPress,
    Sequence,
    Selection,
};
}
