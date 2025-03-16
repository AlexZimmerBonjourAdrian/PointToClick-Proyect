using System;
using System.Collections.Generic;
using UnityEngine;

namespace WhiteRabbit.Core
{
    public abstract class CGameManager : MonoBehaviour
    {
        #region Singleton (Unchanged)

        public static CGameManager Inst { get; private set; }

         public Dictionary<string, string> saveData = new Dictionary<string, string>();
        private void Awake()
        {
            if (Inst != null && Inst != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            Inst = this;
            InitializeGame();
        }

        #endregion

        #region Core Game State (Unchanged)

        public CManagerSFX sfxManager;
        public int score { get; protected set; } = 0;
        public int currentLevel { get; protected set; } = 0;
        public int playerLives { get; protected set; } = 3;
        public float progressPercentage { get; protected set; } = 0f;
        public bool isGameEnded { get; protected set; } = false;

        #endregion

        #region Level Management

        
        /// <summary>
        /// List of all levels in the game.
        /// </summary>
        public List<CLevelGeneric> levels = new List<CLevelGeneric>();

        /// <summary>
        /// Dictionary to quickly access levels by their ID (e.g., level index).
        /// </summary>
        public Dictionary<int, CLevelGeneric> levelsById = new Dictionary<int, CLevelGeneric>();

        /// <summary>
        /// The currently active level.
        /// </summary>
        public CLevelGeneric currentLevelObject { get; protected set; }

        /// <summary>
        /// The level where the game starts.
        /// </summary>
        public CLevelGeneric startLevel;

        /// <summary>
        /// Delegate for the OnLevelChanged event.
        /// </summary>
        public delegate void LevelChangedDelegate(CLevelGeneric newLevel);

        /// <summary>
        /// Event triggered when the current level changes.
        /// </summary>
        public event LevelChangedDelegate OnLevelChanged;

        /// <summary>
        /// Loads a specific level.
        /// </summary>
        /// <param name="levelId">The ID of the level to load (e.g., level index).</param>
        public virtual void LoadLevel(int levelId)
        {
            if (levelsById.ContainsKey(levelId))
            {
                CLevelGeneric newLevel = levelsById[levelId];
                if (currentLevelObject != null)
                {
                    currentLevelObject.gameObject.SetActive(false);
                }
                currentLevelObject = newLevel;
                currentLevelObject.gameObject.SetActive(true);
                currentLevel = levelId; // Update currentLevel
                OnLevelChanged?.Invoke(currentLevelObject);
                Debug.Log($"Loaded level: {levelId}");
            }
            else
            {
                Debug.LogError($"Level with ID {levelId} not found.");
            }
        }

        #endregion

        #region Game Flow (Mostly Unchanged)

        protected virtual void InitializeGame()
        {
            // Reset game state variables
            score = 0;
            currentLevel = 0;
            playerLives = 3;
            progressPercentage = 0f;
            isGameEnded = false;

            // Initialize levels
            InitializeLevels();

            // Set the start level
            if (startLevel != null)
            {
                LoadLevel(levels.IndexOf(startLevel)); // Load by index
            }
            else
            {
                Debug.LogWarning("No start level defined.");
            }
        }

        protected virtual void InitializeLevels()
        {
            // Find all levels in the scene and add them to the list and dictionary.
            CLevelGeneric[] foundLevels = FindObjectsOfType<CLevelGeneric>();
            foreach (CLevelGeneric level in foundLevels)
            {
                levels.Add(level);
                levelsById.Add(levels.IndexOf(level), level); // Use index as ID
                level.gameObject.SetActive(false);
            }
        }

        public virtual void StartNewGame() { InitializeGame(); }
        public virtual void EndGame() { isGameEnded = true; Debug.Log("Game Ended!"); }
        public virtual void RestartLevel() { Debug.Log("Level Restarted!"); }
        public virtual void LoadNextLevel() { currentLevel++; Debug.Log($"Loading Level: {currentLevel}"); }
        public virtual void DecreasePlayerLives()
        {
            playerLives--;
            if (playerLives <= 0) { GameOver(); }
        }
        public virtual void IncreaseScore(int points) { score += points; }
        public virtual void IncreaseProgressPercentage(float percentage)
        {
            progressPercentage += percentage;
            if (progressPercentage > 1f) { progressPercentage = 1f; }
        }
        public virtual void GameOver() { Debug.Log("Game Over!"); EndGame(); }

        public void MoveLocation(int id)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
}


