using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNode 
{
      public int RoomId;
      public List<RoomNode> ConnectedRooms;
      
  
      public RoomNode(int roomId)
      {
          RoomId = roomId;
          ConnectedRooms = new List<RoomNode>();
      }
  }
  

