using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using WhiteRabbit.Core;

 namespace WhiteRabbit.Specialization
{
    /// <summary>
    /// This abstract class serves as a base for all Quick Time Event (QTE) types in the game.
    /// It defines the common interface and structure for different QTE implementations.
    /// 
    /// **Key Responsibilities:**
    /// 1. **QTE Interface:** Defines the basic methods that all QTEs must implement.
    /// 2. **QTE State:** Enumerates possible result states for a QTE.
    /// 3. **Abstraction:** Provides an abstract framework for different QTE mechanics.
    /// 4. **Polymorphism:** Allows handling different QTE types uniformly through a common base class.
    /// 
    /// **How it Works:**
    /// - This class is abstract, meaning it cannot be instantiated directly.
    /// - Concrete QTE implementations (e.g., KeyPressQTE, SequenceQTE, SelectionQTE) inherit from this class.
    /// - Each concrete class overrides the abstract methods to provide its specific QTE logic.
    /// - The CQTEData class (not included in this file, but assumed to exist) is used to pass data to each QTE.
    /// 
    /// **How to Use:**
    /// 1. **Create QTE Types:** Create new classes that inherit from CQTEBase to define different QTE types.
    /// 2. **Implement Abstract Methods:** Override the `QTEReturnState`, `StopQTE`, and `EjecuteQTE` methods in each subclass.
    /// 3. **Create QTE Data:** Create instances of CQTEData (or a subclass) to provide specific data to the QTEs.
    /// 4. **Start a QTE:** Start the QTE by calling the `EjecuteQTE` method in the desired QTE type.
    /// 5. **Check the State:** Call the `QTEReturnState` method to check the result of the QTE.
    /// 6. **Stop a QTE:** Call the `StopQTE` method to stop the QTE.
    /// 
    /// **Future Improvements:**
    /// - Add more robust state management (e.g., states like "Running", "Paused").
    /// - Implement event-driven communication for QTE results.
    /// - Implement a manager to handle all the QTEs.
    /// 
    /// **Current Limitations:**
    /// - Relies on concrete classes for actual QTE logic.
    /// - The state change is handled inside the Coroutine and not as an event.
    /// - No Manager to handle all the QTE.
    /// </summary>
public abstract class CQTEBase
{


     public enum StateResultQTE { FailDramatico, Sucessfull, SucessfullFailed }

    /// <summary>
    /// Abstract method to get the state of the QTE execution.
    /// </summary>
    /// <returns>The StateResultQTE enum value representing the QTE's outcome.</returns>
    public abstract StateResultQTE QTEReturnState();
    /// <summary>
    /// Abstract method to stop the QTE execution.
    /// </summary>
    public abstract void StopQTE();
    /// <summary>
    /// Abstract method to execute the QTE.
    /// </summary>
    /// <param name="data">The data needed for the QTE execution.</param>
    /// <returns>An IEnumerator to run as a coroutine.</returns>
    public abstract IEnumerator EjecuteQTE(CQTEData data);

}





    /// <summary>
    /// This class implements a QTE where the player needs to press a specific key within a time limit.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Key Press Detection:** Detects if the player presses the correct key.
    /// 2. **Time Limit:** Executes the QTE within a specified duration.
    /// 3. **Success/Failure:** Determines if the QTE was successful or not based on key press timing.
    /// 4. **Coroutine-Based:** Uses a coroutine to manage time and key press detection.
    /// 5. **State management:** use a variable to hold the state of the QTE.
    /// 
    /// **How it Works:**
    /// 1. **EjecuteQTE Coroutine:**
    ///    - Starts a coroutine that runs for a set duration.
    ///    - In each frame, it checks if the player pressed the correct key.
    ///    - If the key is pressed, the QTE is marked as successful and the coroutine ends.
    ///    - If the time runs out, the QTE is marked as failed.
    /// 2. **StateResult:**
    ///    - The result is stored in a stateResultQTE variable.
    /// 3. **StopQTE:**
    ///    - Not used in this class, no logic was implemented.
    /// 
    /// **How to Use:**
    /// 1. **Create an Instance:** Instantiate a KeyPressQTE object.
    /// 2. **Create QTE Data:** Create a CQTEData instance with the required data (key to press, duration).
    /// 3. **Start the QTE:** Call `EjecuteQTE` with the data, in a MonoBehaviour, using StartCoroutine.
    /// 4. **Check the State:** Call `QTEReturnState` to check if the QTE was successful or failed.
    /// 5. **StopQTE**: Call `StopQTE` when you want to stop the QTE.
    /// 
    /// **Example**
    /// 
    /// ```
    ///    KeyPressQTE qte = new KeyPressQTE();
    ///    CQTEData data = new CQTEData(KeyCode.Space, 5f);
    ///    StartCoroutine(qte.EjecuteQTE(data));
    ///    //after some time
    ///    StateResultQTE state = qte.QTEReturnState();
    /// ```
    /// 
    /// **Future Improvements:**
    /// - Implement a method to change the state during the execution of the Coroutine.
    /// - Add events for success and failure.
    /// - Add a way to change the key that need to be press during the execution of the coroutine.
    /// - Add a way to pass the result of the QTE to another class.
    /// 
    /// **Current Limitations:**
    /// - No way to change the state of the QTE during its execution.
    /// - It do not call to the StopQTE method.
    /// - The result of the QTE is only show in the log.
    /// </summary>
    public class KeyPressQTE : CQTEBase
{



    /// <summary>
/// System to manage a simple QTE that is based on the input of one Key.
/// </summary>

    public StateResultQTE stateResultQTE;
    private Coroutine runningCoroutine; // To store the running coroutine
    float elapsedTime = 0f;


    /// <summary>
    /// Coroutine to execute the KeyPress QTE.
    /// </summary>
    /// <param name="data">The QTE data, including the key to press and the duration.</param>
    /// <returns>An IEnumerator for coroutine execution.</returns>
   public override IEnumerator EjecuteQTE(CQTEData data) // Use the non-generic IEnumerator
    {

       elapsedTime = 0f;
        bool qteSuccessful = false;

        while (elapsedTime < data.Duration)
        {
            elapsedTime += Time.deltaTime;

            if (Input.GetKeyDown(data.KeyToPress)) // Check for correct key press
            {
                qteSuccessful = true;
                break; // Exit the loop if successful
            }

            yield return null;
        }

        if (qteSuccessful)
        {
            Debug.Log("QTE Success!");
            stateResultQTE = StateResultQTE.Sucessfull;
            // Handle QTE success, e.g., play animation, progress dialogue
        }
        else
        {
            Debug.Log("QTE Failure!");
            stateResultQTE = StateResultQTE.FailDramatico;
            // Handle QTE failure
        }

        // Optionally reset the state:
       
    }

   

   /// <summary>
   /// Returns the final state of the QTE.
   /// </summary>
   /// <returns>the state of the QTE.</returns>
    public override StateResultQTE QTEReturnState()
    {
        return stateResultQTE;
    }

    /// <summary>
    /// This function does not implement any logic for this class.
    /// </summary>
    public override void StopQTE()
    {
     

           
    }
    
}







    
    /// <summary>
    /// This class implements a QTE where the player needs to input a sequence of keys.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Key Sequence Detection:** Detects if the player inputs a correct sequence of keys.
    /// 2. **Time Limit:** Executes the QTE within a specified duration.
    /// 3. **Success/Failure:** Determines if the QTE was successful or not based on the sequence correctness.
    /// 4. **Coroutine-Based:** Uses a coroutine to manage time and key press detection.
    /// 5. **Not implemented:** This is only a placeholder.
    /// 
    /// **How to Use:**
    /// 1. **Create an Instance:** Instantiate a SequenceQTE object.
    /// 2. **Create QTE Data:** Create a CQTEData instance with the required data (sequence of key, duration).
    /// 3. **Start the QTE:** Call `EjecuteQTE` with the data, in a MonoBehaviour, using StartCoroutine.
    /// 4. **Check the State:** Call `QTEReturnState` to check if the QTE was successful or failed.
    /// 5. **StopQTE**: Call `StopQTE` when you want to stop the QTE.
    /// 
    /// **Current Limitations:**
    /// - This class does not implement any logic.
    /// - The abstract method are not used.
    /// </summary>
public class SequenceQTE : CQTEBase
    {
        public override IEnumerator EjecuteQTE(CQTEData data)
        {
            Debug.Log("Starting Sequence QTE");
            // Implement sequence QTE logic here...
            yield break; // Placeholder. Replace with actual sequence logic.
        }
    /// <summary>
    /// This function is not implement yet.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override StateResultQTE QTEReturnState()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// This function is a placeholder.
    /// </summary>
    public override void StopQTE()
        {
            Debug.Log("Stop");
        }

         
    }

    /// <summary>
    ///  This class implements a QTE where the player needs to make a selection among multiple options.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Selection Input:** Handles input for selecting an option.
    /// 2. **Time Limit:** Executes the QTE within a specified duration.
    /// 3. **Success/Failure:** Determines if the QTE was successful or not based on the selection.
    /// 4. **Coroutine-Based:** Uses a coroutine to manage time and selection input.
    /// 5. **Not implemented:** This is only a placeholder.
    /// 
    /// **How to Use:**
    /// 1. **Create an Instance:** Instantiate a SelectionQTE object.
    /// 2. **Create QTE Data:** Create a CQTEData instance with the required data (options, duration).
    /// 3. **Start the QTE:** Call `EjecuteQTE` with the data, in a MonoBehaviour, using StartCoroutine.
    /// 4. **Check the State:** Call `QTEReturnState` to check if the QTE was successful or failed.
    /// 5. **StopQTE**: Call `StopQTE` when you want to stop the QTE.
    /// 
    /// **Current Limitations:**
    /// - This class does not implement any logic.
    /// - The abstract method are not used.
    /// </summary>
    public class SelectionQTE : CQTEBase
    {
        public override IEnumerator EjecuteQTE(CQTEData data)
        {
            Debug.Log("Starting Selection QTE");
            // Implement selection QTE logic here...
            yield break;  // Placeholder. Replace with actual selection logic.
        }
    /// <summary>
    /// This function is not implement yet.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override StateResultQTE QTEReturnState()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// This function is a placeholder.
    /// </summary>
    public override void StopQTE()
        {
            Debug.Log("Stop");
        }

    
    }
    }
