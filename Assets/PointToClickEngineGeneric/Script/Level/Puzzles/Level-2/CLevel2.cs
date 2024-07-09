using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands;
using System.Linq;
using UnityEngine;
using JetBrains.Annotations;

public class CLevel2 : CLevelGeneric
{
 
    // [System.Serializable] // Permite editar la estructura en el Inspector de Unity
    // public struct Room
    // {
    //     public int id;
    //     public Sprite RoomImage;
    //     public bool IsAccessible;

    //     public string tag;


    //     public void SetIsAccessible(bool v)
    //     {
    //         IsAccessible = true;
    //     }
        
    // }
    [SerializeField] public MapData Routerooms;

    [SerializeField] public List<StructRoom.Room> rooms; // Lista de todas las rooms

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
        //rooms = new List<Room>();
        //rooms = Routerooms.Rooms.ToList();
        //rooms = Routerooms.Rooms.Select(x => new Room { id = x.id, RoomImage = x.RoomImage, IsAccessible = x.IsAccessible }).ToList();
        //rooms = Routerooms.Rooms.Select(x => new Room { id = x.id, RoomImage = x.RoomImage, IsAccessible = x.IsAccessible }).ToList();
      //  rooms = Routerooms.GetRooms().Select(x => new StructRoom.Room { id = x.id, RoomImage = x.RoomImage, IsAccessible = x.IsAccessible,  tag = x.tag }).ToList();
        rooms = Routerooms.GetRooms();
        TypePuzzle = EPuzzleType.Puzzle.Sequence;
        SequencePuzzle = new List<int>();
        _SprtR = GetComponent<SpriteRenderer>();
        currentRoomIndex = rooms[0].id;
        LoadRoom(currentRoomIndex); // Cargar la primera room al inicio
        _inst = this;
        
    }


public void LoadRoom(int index)
    {
        // Validar el índice
        foreach (StructRoom.Room R in rooms)
        {
            if (R.id == index)
            {
                if (R.IsAccessible)
                {
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




    public void LoadRoomByTag(string roomTag)
    {
        // Iterate through all rooms and update IsAccessible based on the tag
        foreach (var R in rooms)
        {
            if (R.tag == roomTag)
            {
                R.SetIsAccessible(true);
                Debug.LogWarning("La room " + R.id + " con tag " + roomTag + " es accesible.");
            }
            else
            {   
             
                R.SetIsAccessible(false);
                Debug.LogWarning("La room " + R.id + " con tag " + roomTag + " no es accesible.");
            }
        }
        
    }

    // ... (Rest of the code)

 
   
     public int GetCurrentRoomIndex()
     {
         return currentRoomIndex;
     }

     public MapData GetRouterooms()
     {
        return Routerooms;
     }

    public void SetRouterooms(MapData Data)
    {
        Routerooms = Data;
    }

    // public void SetCurrentRoomIndex(int index)
    // {
    //     currentRoomIndex = index;
    // }
}
