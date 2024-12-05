using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace WhileClear
{
public class CLevel1 : CLevelGeneric

{
  
        [System.Serializable]
        public class RoomConnection
        {
            public GameObject fromRoom;
            public GameObject toRoom;
        }

        public List<RoomConnection> roomConnections;

        [SerializeField] public List<GameObject> LevelRooms;
        private int currentRoomIndex;

        public static CLevel1 Inst
        {
            get
            {
                if (_inst == null)
                {
                    GameObject obj = new GameObject("Level1");
                    return obj.AddComponent<CLevel1>();
                }

                return _inst;
            }
        }

        private static CLevel1 _inst;

        public void Awake()
        {
            LevelRooms = GetComponentsInChildren<Room>(true).Select(room => room.gameObject).ToList(); // Include inactive children
            _inst = this;

            // Deactivate all rooms initially
            foreach (var room in LevelRooms)
            {
                room.SetActive(false);
            }
        }

        public void Start()
        {
            SetRoomActive(0); // Activate the first room
        }



        public void SetRoomActive(int roomIndex)
        {
            if (roomIndex >= 0 && roomIndex < LevelRooms.Count)
            {
                // Deactivate current room (if any)
                if (currentRoomIndex >= 0 && currentRoomIndex < LevelRooms.Count)
                {
                    LevelRooms[currentRoomIndex].SetActive(false);
                }

                // Activate new room
                LevelRooms[roomIndex].SetActive(true);
                currentRoomIndex = roomIndex;
            }
            else
            {
                Debug.LogError("Invalid room index: " + roomIndex);
            }
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            for (int i = 0; i < roomConnections.Count; i++)
            {
                if (roomConnections[i].fromRoom != null && roomConnections[i].toRoom != null)
                {
                    Gizmos.DrawLine(roomConnections[i].fromRoom.transform.position, roomConnections[i].toRoom.transform.position);
                }
                else
                {
                    Debug.LogWarning("Room connection has null references.");
                }
            }
        }
    }

}
