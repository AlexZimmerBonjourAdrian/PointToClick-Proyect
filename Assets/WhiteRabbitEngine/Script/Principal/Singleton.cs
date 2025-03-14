using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


public class GameManager : Singleton<GameManager>
{
    // Your GameManager logic here
    public void DoSomething()
    {
        Debug.Log("GameManager is doing something!");
    }

    // Optional: override Awake if needed
    public override void Awake()
    {
        base.Awake(); // Call the base Awake() to ensure singleton logic
        // Additional initialization logic for GameManager.
    }
}

public class SomeOtherScript : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.DoSomething(); // Access the GameManager instance
    }
}
