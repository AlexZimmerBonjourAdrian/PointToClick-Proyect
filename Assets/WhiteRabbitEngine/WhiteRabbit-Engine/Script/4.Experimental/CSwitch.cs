using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

/// <summary>
/// The CSwitch class provides a simple mechanism for switching between different scenes in the game.
/// It's primarily designed for testing and debugging scene transitions during development,
/// but could be adapted for in-game scene changes as well.
/// It uses the Singleton pattern to ensure that only one instance of this manager exists throughout the game.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures a single, global instance of the CSwitch manager.
/// 2. **Persistence:** Persists across scene loads using `DontDestroyOnLoad`.
/// 3. **Scene Switching:** Provides methods to switch between scenes synchronously and asynchronously.
/// 4. **Debug Input:** Implements debug key inputs (Alpha1-Alpha4) to quickly load specific scenes.
/// 5. **Centralized Scene Loading:** Centralizes the logic for loading scenes, making it easier to manage and modify.
/// 
/// **How to Use:**
/// 1. **Accessing the Manager:** Other scripts can access the CSwitch manager using `CSwitch.Inst`.
/// 2. **Switching Scenes (Synchronous):** Use the method `CLevelManager.Inst.LoadScene(int sceneBuildIndex)` or `CLevelManager.Inst.LoadScene(string sceneName)` from the CLevelManager to change the current scene.
///     - The method `LoadScene` in CLevelManager changes immediately to the scene.
///     - You can change using the BuildIndex or the scene Name.
/// 3. **Switching Scenes (Asynchronous):** Use the method `SwitchScene(string sceneName)` to load a scene asynchronously.
///     - The scene will be loaded in the background, while the current scene remains active until the new scene is fully loaded.
/// 4. **Debug Scene Switching:** Press the keys Alpha1, Alpha2, Alpha3, or Alpha4 to quickly switch to scenes with build index 0, 1, 2, or 3 respectively.
///     - this input is only check in the `Update` method.
///     - you can change the functionality of the input using the `Update` method.
///     - This is useful for testing different levels or areas of the game during development.
///     - You can disable this functionality by removing the `Update` method.
/// 
/// **Future Improvements:**
/// - Add more sophisticated scene loading logic, such as loading screens or transition effects.
/// - Add a system for managing scene dependencies (e.g., loading multiple scenes additively).
/// - Add events or callbacks to notify other scripts when a scene load starts or finishes.
/// - Add methods to set a default scene.
/// - Add methods to get the name of the current scene.
/// - Consider a more robust saving system instead of PlayerPrefs.
/// - Consider implement more methods to manage other global systems.
/// - Add more option to the input, to be more flexible.
/// 
/// **Current Limitations**
/// - The `Update` method is only for test and debug, it will not be a method to use in the final version.
/// - Only support the loading of one scene.
/// - Only support to switch between scene.
/// - Only use the `CLevelManager` class to load the scene.
/// - Only support to load by the name or the build index.
/// </summary>
namespace WhiteRabbit.Experimental
{

    public class CSwitch : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the CSwitch.
        /// Provides a global access point to the switch management functionality.
        /// </summary>
        public static CSwitch Inst
        {
            get
            {
                // If the instance doesn't exist, create a new GameObject and add the CSwitch component.
                if (_inst == null)
                {
                    GameObject obj = new GameObject("Switch");

                    return obj.AddComponent<CSwitch>();
                }
                return _inst;
            }
        }
        private static CSwitch _inst;
        // Start is called before the first frame update
        private void Awake()
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
        }

        //You can Modification this method to switch between scenes
        // Update is called once per frame
        void Update()
        {
            //Example Change Map in te Game using an input key. This is only for testing.
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //Load the scene with the build index 0.
                CLevelManager.Inst.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //Load the scene with the build index 1.
                CLevelManager.Inst.LoadScene(1);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //Load the scene with the build index 2.
                CLevelManager.Inst.LoadScene(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //Load the scene with the build index 3.
                CLevelManager.Inst.LoadScene(3);
            }
        }

        /// <summary>
        /// Loads a scene asynchronously by its name.
        /// </summary>
        /// <param name="name">The name of the scene to load asynchronously.</param>
        public void SwitchScene(string name)
        {
            //call to the method in CLevelManager to load the scene asynchronous.
            CLevelManager.Inst.LoadSceneAsync(name);
        }


    }
}
