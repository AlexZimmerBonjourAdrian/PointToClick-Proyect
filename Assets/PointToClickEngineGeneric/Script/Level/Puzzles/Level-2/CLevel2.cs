using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevel2 : CLevelGeneric
{
    [System.Serializable] // Permite editar la estructura en el Inspector de Unity
    public struct Room
    {
        public int id;
        public Sprite RoomImage;
        public bool IsAccessible;


    };

    [SerializeField] private List<Room> rooms; // Lista de todas las rooms

    public SpriteRenderer _SprtR;
    private int currentRoomIndex; // Índice de la room actual

    [SerializeField]
    private List<int> SequencePuzzle;
    
    [SerializeField]
    private List<int> CorrectSequence;
   
     [SerializeField]
      private EPuzzleType.Puzzle TypePuzzle;
    public static CLevel2 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level2");
                return obj.AddComponent<CLevel2>();
            }

            return _inst;
        }
    }

    private static CLevel2 _inst;


    public void Awake()
    {
        TypePuzzle = EPuzzleType.Puzzle.Sequence;
         List<int> SequencePuzzle = new List<int>();
        _SprtR = GetComponent<SpriteRenderer>();
        currentRoomIndex = 1;
        LoadRoom(currentRoomIndex); // Cargar la primera room al inicio
        _inst = this;
    }


public void LoadRoom(int index)
{
    Debug.Log("Ubicacion " + currentRoomIndex);
    // Validar el índice
    foreach (Room R in rooms)
    {
        if (R.id == index)
        {
            if (R.IsAccessible)
            {
                 Debug.Log("habitacion correspondiente" + currentRoomIndex);
                Debug.LogWarning("La room " + index + "Es");
                currentRoomIndex = index;
                _SprtR.sprite = R.RoomImage;
               
                break;
            }
            else
            {
                Debug.LogWarning("La room " + index + " no es accesible.");
                break;
            }
        }
    }
}




    // // Método público para cambiar a la siguiente room
    // public void GoToNextRoom()
    // {
    //     LoadRoom(currentRoomIndex + 1);
    // }

    // // Método público para cambiar a la room anterior
    // public void GoToPreviousRoom()
    // {
    //     LoadRoom(currentRoomIndex - 1);
    // }

    // public List<Room> GetRooms()
    // {
    //     return rooms;
    // }

    // public int GetCurrentRoomIndex()
    // {
    //     return currentRoomIndex;
    // }

}