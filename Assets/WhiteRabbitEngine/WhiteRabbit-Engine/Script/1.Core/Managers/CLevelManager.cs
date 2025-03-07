using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


 
 namespace WhiteRabbit.Core
  {
public class CLevelManager : MonoBehaviour
{
  
    /// <summary>
    /// Singleton instance of the CLevelManager.
    /// Provides a global access point to the level management functionality.
    /// </summary>
    public static CLevelManager Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CLevelManager component.
            if (_inst == null)
            {
                Debug.Log("CLevelManager instance not found, creating a new one.");
                GameObject obj = new GameObject("Level");
                return obj.AddComponent<CLevelManager>();
            }
            Debug.Log("CLevelManager instance found.");
            return _inst;

        }
    }
    private static CLevelManager _inst;

    /// <summary>
    /// Stores the reference to the current asynchronous scene loading operation.
    /// </summary>
    private AsyncOperation _CurrentLoadScene;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CLevelManager exists (Singleton pattern).
    /// </summary>
  public void Awake()
    {
    // If an instance already exists and it's not this one, destroy this one.
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(this.gameObject); //removed this as this level manager is only for a scene.
        _inst = this;
    }


    /// <summary>
    /// Checks if a scene is currently being loaded asynchronously.
    /// </summary>
    /// <returns>True if a scene is loading, false otherwise.</returns>
    public bool IsLoadingScene()
    {
        // Returns true if _CurrentLoadScene is not null and the scene is not finished loading.
        return _CurrentLoadScene != null && !_CurrentLoadScene.isDone;
    }

    /// <summary>
    /// Loads a scene synchronously by its build index.
    /// </summary>
    /// <param name="index">The build index of the scene to load.</param>
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Loads a scene synchronously by its name.
    /// </summary>
    /// <param name="name">The name of the scene to load.</param>
    public void LoadScene(string name)

    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Loads a scene asynchronously by its name.
    /// </summary>
    /// <param name="name">The name of the scene to load asynchronously.</param>
    public void LoadSceneAsync(string name)
    {
        _CurrentLoadScene = SceneManager.LoadSceneAsync(name);
        //the scene is loading.
    }

    /// <summary>
    /// Loads a scene asynchronously additively by its name.
    /// </summary>
    /// <param name="name">The name of the scene to load additively.</param>
    public void LoadSceneAsyncAdditive(string name)
    {
        _CurrentLoadScene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
         //Loads the scene on the top.
    }

    
    /// <summary>
    /// Quits the application.
    /// </summary>
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    /*
     // removed this function. Not necesary for this class
  public void LateUpdate()
  {
       if(_CurrentLoadScene.isDone)
      {
          _CurrentLoadScene = null;
      }
  }
*/
}
}
