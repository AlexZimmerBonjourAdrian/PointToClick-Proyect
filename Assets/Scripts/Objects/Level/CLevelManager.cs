using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelManager : MonoBehaviour
{
  
    public static CLevelManager Inst
    {
        get
        {
            if (_inst == null)
            {
                Debug.Log("Entra?");
                GameObject obj = new GameObject("Level");
                return obj.AddComponent<CLevelManager>();
            }
            Debug.Log("Entra en el return");
            return _inst;

        }
    }
    private static CLevelManager _inst;

    private AsyncOperation _CurrentLoadScene;

    public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }

  /*

    public void LateUpdate()
    {
         if(_CurrentLoadScene.isDone)
        {
            _CurrentLoadScene = null;
        }
    }
  */

    public bool IsLoadingScene()
    {
        return _CurrentLoadScene != null && !_CurrentLoadScene.isDone;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string name)

    {
        SceneManager.LoadScene(name);
    }

    public void LoadSceneAsync(string name)
    {
        _CurrentLoadScene = SceneManager.LoadSceneAsync(name);
    }

    public void LoadSceneAsyncAdditive(string name)
    {
        _CurrentLoadScene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
}
