using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WhiteRabbit.Core;
 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// CQTEController is a MonoBehaviour class responsible for managing the execution and lifecycle of various Quick Time Events (QTEs) in the game.
    /// It acts as a central hub for starting, monitoring, and concluding QTE sequences, utilizing the abstract CQTEBase class and specific QTE implementations.
    ///
    /// **Key Responsibilities:**
    /// 1. **QTE Initialization:** Instantiates the appropriate QTE type based on provided QTE data.
    /// 2. **QTE Execution:** Starts and manages the execution of a QTE sequence using coroutines.
    /// 3. **QTE State Management:** Tracks the current state of the QTE (None, Start, Player, Finish).
    /// 4. **Data Handling:** Receives and processes QTE data (CQTEData) to configure and customize the QTE's behavior.
    /// 5. **QTE Type Selection:** Dynamically selects the appropriate QTE implementation (KeyPressQTE, SequenceQTE, etc.) based on the specified QTE type.
    ///
    /// **How It Works:**
    /// - The CQTEController receives a CQTEData object, which contains information about the type of QTE to run.
    /// - Based on the QTE type, the controller creates an instance of the corresponding QTE class (e.g., KeyPressQTE).
    /// - The StartQTE method initiates the QTE sequence, which is handled as a coroutine within the specific QTE class.
    /// - The state of the QTE is managed through the QTEState enum.
    /// - This class is meant to be attached to a GameObject in the scene.
    /// - Other scripts can interact with this class to launch a QTE.
    ///
    /// **How to Use:**
    /// 1. **Attach to GameObject:** Attach this script to a GameObject in your scene.
    /// 2. **Create CQTEData:** Create a `CQTEData` ScriptableObject asset in your project. This asset will hold the details about the specific QTE you want to trigger (type, target, etc.). Assign the ScriptableObject in the inspector.
    /// 3. **Set the Type:** In the CQTEData asset, choose the desired QTE type (KeyPress, Sequence, etc.).
    /// 4. **Trigger StartQTE:** From another script, obtain a reference to the `CQTEController` and call its `StartQTE()` method.
    /// 5. **SetState:** In order to control the state you should use the SetState(QTEState state) method.
    ///
    /// **Example**
    /// `
    ///   // In another script.
    ///   CQTEController qteController = FindObjectOfType<CQTEController>();
    ///   qteController.StartQTE(); // This will start the QTE define in the inspector.
    /// `
    /// 
    /// **Future Improvements:**
    /// - Add a method to stop the coroutine externally.
    /// - Implement events for QTE start, success, and failure for better communication with other game systems.
    /// - Add a manager to handle all the QTE, in order to use this controller from other scripts.
    /// - Implement methods to return the QTE state.
    ///
    /// **Current Limitations:**
    /// - The connection with other scripts is only by launching the QTE.
    /// - The QTEs results are only manage by the QTE.
    /// - Only can run one QTE at a time.
    /// </summary>
public class CQTEController : MonoBehaviour
{
    /// <summary>
    /// Enumeration defining the possible states of a QTE sequence.
    /// </summary>
    public enum QTEState
    {
        /// <summary>
        /// No QTE is currently active.
        /// </summary>
        None,
        /// <summary>
        /// The QTE sequence is starting.
        /// </summary>
        Start,
        /// <summary>
        /// The player is currently interacting with the QTE.
        /// </summary>
        Player,
        /// <summary>
        /// The QTE sequence has finished.
        /// </summary>
        Finish
    }


    // public CanvasGroup QTEInterface;
    

    // public TextMeshProUGUI Counter;

    // public TextMeshProUGUI Force;

    // public TextMeshProUGUI Result;

    /// <summary>
    /// Data object that holds the configuration for the QTE.
    /// </summary>
    public CQTEData Data;

    /// <summary>
    /// The currently active QTE instance.
    /// </summary>
    private CQTEBase qte;
    /// <summary>
    /// The current state of the QTE.
    /// </summary>
    private QTEState currentState = QTEState.None;
    /// <summary>
    /// Sets the current state of the QTE.
    /// </summary>
    /// <param name="state">The new state of the QTE.</param>
    public void SetState(QTEState state)
    {
        currentState = state;
    }

    
    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes the QTE instance and starts the QTE.
    /// </summary>
    void Start()
    {
       // Check if a QTE object already exists.
       if(qte == null)
         // Create the instance using the data provided.
         qte = CreateQTEInstance(Data);
         // Call the method to launch the QTE.
         StartQTE();

    }

    /// <summary>
    /// Starts the QTE sequence.
    /// </summary>
    public void StartQTE()
    {
        //Check if there is a QTE.
        if (qte == null)
        {
            // If there is no QTE, display an error.
            Debug.LogError("QTE is not initialized!");
            return;
        }

        // Use a lambda expression to wrap the IEnumerator
        // Launch the QTE.
        StartCoroutine(qte.EjecuteQTE(Data)); 
    }
  
    /// <summary>
    /// Creates a new instance of the appropriate QTE type based on the provided data.
    /// </summary>
    /// <param name="data">The QTE data containing the type of QTE to create.</param>
    /// <returns>A new instance of CQTEBase or null if the type is invalid.</returns>
    private CQTEBase CreateQTEInstance(CQTEData data)
    {
        // Check the data type.
        switch (data.TypePuzzle)
        {
            case QTETypePuzzle.KeyPress:
                // Create a KeyPressQTE.
                return new KeyPressQTE();
            case QTETypePuzzle.Sequence:
                //Create a SequenceQTE.
                return new SequenceQTE(); // Assuming you create this class
            case QTETypePuzzle.Selection:
                // Create a SelectionQTE.
                return new SelectionQTE(); // Assuming you create this class
            default:
                // If not match with any type, return null.
                return null; // Or throw an exception
        }
    }


 

    
}

    
}
