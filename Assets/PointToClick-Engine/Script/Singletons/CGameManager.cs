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


    // Métodos para inicializar y finalizar el juego
    public void InitializeGame()
    {
        // Cargar niveles, configurar controles, etc.

    }

    public void EndGame()
    {
        // Guardar puntuación, mostrar pantalla de game over, etc.
        
    }

    // Métodos para manejar eventos del juego
    public void OnPlayerDeath()
    {
        // Restar vida al jugador, mostrar efecto de muerte, etc.
    }

    public void OnLevelComplete()
    {
        // Incrementar nivel, mostrar pantalla de victoria, etc.
    }

    // Métodos para actualizar y renderizar el juego
    public void UpdateGame()
    {
        // Actualizar física, renderizar gráficos, etc.
    }

    public void RenderGame()
    {
        // Renderizar gráficos, mostrar HUD, etc.
    }


    public void SaveGame()
    {
        // Guardar puntuación, nivel actual, Data del inventario, Progreso, niveles completados
    }

    public void LoadGame()
    {
        // Cargar puntuación, nivel actual, Data del inventario, Progreso, niveles completados
    }

    public void CreateNewSaveGame()
    {
        // Crea una partida nueva en un slot, que gurda el progreso
    }

    public void AutoloadGamePostDeath()
    {
        // Carga el juego después de la muerte del jugador cuando se presiona cualquier tecla
    }

    public void DeleteInventarieItem()
    {

    }
}
