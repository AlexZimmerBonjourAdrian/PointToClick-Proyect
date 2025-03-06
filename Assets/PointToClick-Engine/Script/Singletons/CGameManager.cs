using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    // Referencias a otros managers
    public CManagerSFX sfxManager;

    // Estado del juego
    public int score;
    public int currentLevel;
    public int playerLives;

    public float progressPorcement;

    public bool isEndGame;

    //Singleton
     public static CGameManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameManager");
                return obj.AddComponent<CGameManager>();
            }
            return _inst;

        }
    }
    private static CGameManager _inst;

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

  public void MoveLocation(int id)
  {
     CLevelGeneric Level = FindAnyObjectByType<CLevelGeneric>();

     Debug.Log(Level.name);
     Level.SetRoomActive(id,true);
  }
}
