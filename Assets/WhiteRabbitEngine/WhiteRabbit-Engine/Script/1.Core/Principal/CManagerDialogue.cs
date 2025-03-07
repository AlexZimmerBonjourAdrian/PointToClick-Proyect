using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Yarn;
using Yarn.Compiler;
using Yarn.Unity;
using Yarn.Unity.Example;
using UnityEngine.TextCore.Text;

using System.Linq;

namespace WhiteRabbit.Core

{
    /// <summary>
    /// The CManagerDialogue class is a singleton that manages dialogue within the game using the Yarn Spinner dialogue system.
    /// It handles loading and running Yarn scripts, storing dialogue variables, and controlling the flow of conversation.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Singleton Pattern:** Ensures only one instance of CManagerDialogue exists, providing a central point of access for dialogue-related functionality.
    /// 2. **Yarn Project Management:** Allows for multiple Yarn projects to be defined and loaded, enabling the use of different dialogue sets.
    /// 3. **Dialogue Runner Integration:** Utilizes a `DialogueRunner` component to run Yarn scripts and manage dialogue state.
    /// 4. **Variable Storage:** Employs an `InMemoryVariableStorage` component to store and retrieve dialogue variables.
    /// 5. **Yarn Project Switching:** Provides methods to switch between different Yarn projects dynamically.
    /// 6. **Dialogue Control:** Offers methods to start and check the state of the dialogue.
    /// 7. **Persistence:** Ensure the manager persist between scenes.
    /// 
    /// **How to Use:**
    /// 1. **Adding Yarn Projects:** Drag and drop Yarn projects (compiled .yarnc files) into the `ListYarnProyect` list in the Inspector.
    /// 2. **Setting a Yarn Project:**
    ///     - Use `SetYarnProject(YarnProject Dialogs)` to set a specific Yarn project directly.
    ///     - Use `SetListYarn(int IndexYarn)` to set a Yarn project by its index in the `ListYarnProyect` list.
    /// 3. **Starting Dialogue:** Call `StartDialogueRunner()` to begin running the dialogue from the first node of the currently set Yarn project.
    /// 4. **Checking Dialogue State:** Use `GetIsDialogueRunning()` to determine if a dialogue is currently active.
    /// 5. **Accessing Yarn Project Information** use GetYarnProject to access the current yarn project.
    /// 6. **Access Variable**: access directly to the variableStorage to get or set variable.
    /// 
    /// **Future Improvements:**
    /// - Add more control over dialogue flow, such as pausing, resuming, and skipping lines.
    /// - Add error handling for invalid Yarn project settings.
    /// - Add methods for directly interacting with the `InMemoryVariableStorage` to manipulate variables.
    /// - Add Events when the dialogs start or end.
    /// </summary>
    public class CManagerDialogue : MonoBehaviour
    {
        /// <summary>
        /// The DialogueRunner component that will run the Yarn scripts.
        /// </summary>
        [SerializeField]
        private DialogueRunner dialogueRunner;

        /// <summary>
        /// The InMemoryVariableStorage component that will store dialogue variables.
        /// </summary>
        [SerializeField]
        private InMemoryVariableStorage varibleStorage;

        /// <summary>
        /// Singleton instance of the CManagerDialogue.
        /// Provides a global access point to the dialogue management functionality.
        /// </summary>
        public static CManagerDialogue Inst
        {
            get
            {
                // If the instance doesn't exist, create a new GameObject and add the CManagerDialogue component.
                if (_inst == null)
                {
                    GameObject obj = new GameObject("ManagerDialogue");
                    return obj.AddComponent<CManagerDialogue>();
                }
                return _inst;

            }
        }
        private static CManagerDialogue _inst;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// It ensures that only one instance of CManagerDialogue exists (Singleton pattern).
        /// It also ensures that this object will be no destroy when a new scene is load.
        /// </summary>
        public void Awake()
        {
            // If an instance already exists and it's not this one, destroy this one.
            if (_inst != null && _inst != this)
            {
                Destroy(gameObject);
                return;
            }
            //This line makes the GameObject persist across scene loads.
            DontDestroyOnLoad(this.gameObject);
            _inst = this;

            // Find DialogueRunner and InMemoryVariableStorage components in the scene.
            //This line is necesary as this object will be instanciate when the game start.
            //This means that it is neccesary to search the components in the scene.
            dialogueRunner = GameObject.FindAnyObjectByType<DialogueRunner>();
            varibleStorage = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
        }




        /// <summary>
        /// A list of Yarn projects that can be used for dialogue.
        /// </summary>
        [SerializeField]
        private List<YarnProject> ListYarnProyect;

        // [SerializeField]
        // public Dictionary<YarnProject, string> DialogsDir = new Dictionary<YarnProject, string>();

        /// <summary>
        /// The currently selected Yarn project.
        /// </summary>
        [SerializeField]
        private YarnProject ActualYarn;

        /// <summary>
        /// Sets the current Yarn project for the DialogueRunner.
        /// </summary>
        /// <param name="Dialogs">The YarnProject to set.</param>
        public void SetYarnProject(YarnProject Dialogs)
        {
            dialogueRunner.SetProject(Dialogs);
        }

        /// <summary>
        /// Gets the current YarnProject.
        /// </summary>
        public YarnProject GetYarnProject()
        {
            return dialogueRunner.GetYarnProject();
        }

        /// <summary>
        /// Sets the current Yarn project based on its index in the ListYarnProyect.
        /// </summary>
        /// <param name="IndexYarn">The index of the Yarn project in the ListYarnProyect.</param>
        public void SetListYarn(int IndexYarn)
        {
            //Assign the yarn project
            ActualYarn = ListYarnProyect[IndexYarn];
            //Update the project
            dialogueRunner.SetProject(ActualYarn);
        }

        /// <summary>
        /// Starts the dialogue runner using the first node of the currently set Yarn project.
        /// </summary>
        public void StartDialogueRunner()
        {
            //Check if the yarn project have any node.
            if(ActualYarn.NodeNames.Count() > 0)
            {
                //Start the dialog with the first node
                dialogueRunner.StartDialogue(ActualYarn.NodeNames[0]);
            }
            else
            {
                Debug.LogError("The yarn project does not have any node");
            }
        
        }

        /// <summary>
        /// Checks if the dialogue runner is currently running a dialogue.
        /// </summary>
        /// <returns>True if a dialogue is running, false otherwise.</returns>
        public bool GetIsDialogueRunning()
        {
            return dialogueRunner.IsDialogueRunning;
        }

        private void GetVariableStorage()
        {

        }
    }

}
