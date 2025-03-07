using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;
using WhiteRabbit.Core;
using WhiteRabbit.FirstPrototype;


namespace WhiteRabbit.Tests
{
    public class CLevel2Tests
    {
        private GameObject _gameObject;
        public CLevel2 _level2;

        [SetUp]
        public void Setup()
        {
            _gameObject = new GameObject();
            _level2 = _gameObject.AddComponent<CLevel2>();

            // Create mock data for testing
            _level2.POV = new List<GameObject>
            {
                new GameObject("POV1"),
                new GameObject("POV2"),
                new GameObject("POV3")
            };
            _level2.Mesa = new List<GameObject>
            {
                new GameObject("Mesa1"),
                new GameObject("Mesa2"),
                new GameObject("Mesa3")
            };
            _level2.LevelRooms = new List<GameObject>
            {
                new GameObject("Room1"),
                new GameObject("Room2"),
                new GameObject("Room3")
            };

           //_level2.rooms = new List<StructRoom.Room>();
           // _level2.rooms.Add(new StructRoom.Room { id = 0, RoomImage = null, IsAccessible = false, tag = "Tag1" });
           // _level2.rooms.Add(new StructRoom.Room { id = 1, RoomImage = null, IsAccessible = false, tag = "Tag2" });
           // _level2.rooms.Add(new StructRoom.Room { id = 2, RoomImage = null, IsAccessible = false, tag = "Tag3" });
           // _level2.rooms.Add(new StructRoom.Room { id = 3, RoomImage = null, IsAccessible = false, tag = "Tag4" });

            //Initialize Room component for LevelRooms to avoid NullReferenceException
            foreach (GameObject roomObj in _level2.LevelRooms)
            {
                roomObj.AddComponent<Room>();
            }

            //Create Mock MapData
            _level2.Routerooms = ScriptableObject.CreateInstance<MapData>();
           _level2.Routerooms.rooms = new List<StructRoom.Room>
           {
               new StructRoom.Room { id = 0, RoomImage = null, IsAccessible = false, tag = "Tag1" },
               new StructRoom.Room { id = 1, RoomImage = null, IsAccessible = false, tag = "Tag2" },
               new StructRoom.Room { id = 2, RoomImage = null, IsAccessible = false, tag = "Tag3" },
               new StructRoom.Room { id = 3, RoomImage = null, IsAccessible = false, tag = "Tag4" }
           };

            _level2.rooms = _level2.Routerooms.GetRooms();
            //Make one room accesible
            var room = _level2.rooms[0];
            room.IsAccessible = true;
            _level2.rooms[0] = room;
             _level2.Awake();
            _level2.Start();
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_gameObject);
        
            
             Object.DestroyImmediate(_level2.Routerooms);

        }

        [Test]
        public void SetIsShootMusicBox_SetsCorrectValue()
        {
            _level2.SetIsShootMusicBox(true);
            Assert.IsTrue(_level2.GetIsShootMusicBox());

            _level2.SetIsShootMusicBox(false);
            Assert.IsFalse(_level2.GetIsShootMusicBox());
        }

        [Test]
        public void SetIsRevolver_SetsCorrectValue()
        {
            _level2.SetIsRevolver(true);
            Assert.IsTrue(_level2.GetIsRevolver());

            _level2.SetIsRevolver(false);
            Assert.IsFalse(_level2.GetIsRevolver());
        }

        [Test]
        public void SetIsMagRevolver_SetsCorrectValue()
        {
            _level2.SetIsMagRevolver(true);
            Assert.IsTrue(_level2.GetIsMagRevolver());

            _level2.SetIsMagRevolver(false);
            Assert.IsFalse(_level2.GetIsMagRevolver());
        }

        [Test]
        public void SetIsTakeShootgun_SetsCorrectValue()
        {
            _level2.SetIsTakeShootgun(true);
            Assert.IsTrue(_level2.GetIsTakeShootGun());

            _level2.SetIsTakeShootgun(false);
            Assert.IsFalse(_level2.GetIsTakeShootGun());
        }

        [Test]
        public void SetIsShootGunShell_SetsCorrectValue()
        {
            _level2.SetIsShootGunShell(true);
            Assert.IsTrue(_level2.GetIsShootGunShell());

            _level2.SetIsShootGunShell(false);
            Assert.IsFalse(_level2.GetIsShootGunShell());
        }

        [Test]
        public void GetIsFinishLevel_SetsCorrectValue()
        {
            //Before Test create a door temp
            _level2.SetIsFinished(true);
            Assert.IsTrue(_level2.GetIsFinishLevel());

            _level2.SetIsFinished(false);
            Assert.IsFalse(_level2.GetIsFinishLevel());
        }
        [Test]
        public void SetRoomActive_ActivatesCorrectRoom()
        {
             //Initialize Room component for LevelRooms to avoid NullReferenceException
            foreach (GameObject roomObj in _level2.LevelRooms)
            {
                 roomObj.SetActive(false);
            }
            _level2.SetRoomActive(1, true);
            Assert.IsTrue(_level2.LevelRooms[1].activeSelf);
            Assert.IsFalse(_level2.LevelRooms[0].activeSelf);
            Assert.IsFalse(_level2.LevelRooms[2].activeSelf);
        }

        [Test]
        public void SetRoomActive_InvalidIndex_LogsError()
        {
            LogAssert.Expect(LogType.Error, "Invalid room index: 99");
            _level2.SetRoomActive(99, true);
        }
         [Test]
        public void SetPovActive_ActivatesCorrectPov()
        {
             //Initialize Room component for LevelRooms to avoid NullReferenceException
             foreach (GameObject roomObj in _level2.POV)
            {
                 roomObj.SetActive(false);
            }
            _level2.SetPovActive(2, true);
            Assert.IsTrue(_level2.POV[2].activeSelf);
            Assert.IsFalse(_level2.POV[0].activeSelf);
            Assert.IsFalse(_level2.POV[1].activeSelf);
        }

        [Test]
        public void SetPovActive_InvalidIndex_LogsError()
        {
            LogAssert.Expect(LogType.Error, "Invalid room index: 99");
            _level2.SetPovActive(99, true);
        }

         [Test]
        public void SetMesaActive_ActivatesCorrectMesa()
        {
             foreach (GameObject roomObj in _level2.Mesa)
            {
                 roomObj.SetActive(false);
            }
            _level2.SetMesaActive(0, true);
            Assert.IsTrue(_level2.Mesa[0].activeSelf);
            Assert.IsFalse(_level2.Mesa[1].activeSelf);
            Assert.IsFalse(_level2.Mesa[2].activeSelf);
        }

        [Test]
        public void SetMesaActive_InvalidIndex_LogsError()
        {
            LogAssert.Expect(LogType.Error, "Invalid room index: 99");
            _level2.SetMesaActive(99, true);
        }
        [Test]
        public void LoadRoom_AccessibleRoom_SetsCurrentRoomIndex()
        {
            
            _level2.LoadRoom(0);
            Assert.AreEqual(0, _level2.GetCurrentRoomIndex());
            LogAssert.Expect(LogType.Warning, "La room 0Es");
        }

        [Test]
        public void LoadRoom_InaccessibleRoom_LogsWarning()
        {
            
            _level2.LoadRoom(1);
            LogAssert.Expect(LogType.Warning, "La room 1 no es accesible.");
        }

       [Test]
        public void LoadRoomByTag_CorrectlyUpdatesIsAccessible()
        {
             
            _level2.LoadRoomByTag("Tag3");
            Assert.IsTrue(_level2.rooms[2].IsAccessible);
            LogAssert.Expect(LogType.Warning, "La room 2 con tag Tag3 es accesible.");

            for (int i = 0; i < _level2.rooms.Count; i++)
            {
                if (i != 2)
                {
                  LogAssert.Expect(LogType.Warning, $"La room {i} con tag Tag{i+1} no es accesible.");

                }
               
            }

             
        }

        [Test]
        public void GetRouterooms_ReturnsCorrectMapData()
        {
            Assert.AreEqual(_level2.Routerooms, _level2.GetRouterooms());
        }

        [Test]
        public void SetRouterooms_SetsCorrectMapData()
        {
            MapData newMapData = ScriptableObject.CreateInstance<MapData>();
            _level2.SetRouterooms(newMapData);
            Assert.AreEqual(newMapData, _level2.GetRouterooms());
              Object.DestroyImmediate(newMapData);
        }

    }
}
