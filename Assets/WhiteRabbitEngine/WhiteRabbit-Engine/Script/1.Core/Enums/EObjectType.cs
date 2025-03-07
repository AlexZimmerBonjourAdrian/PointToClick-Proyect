using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// Enum to define the type of object in the game.
/// </summary>

 namespace WhiteRabbit.Core
  {

    public static class EObjectType
    {
        public enum Object
        {
        None,
        Interact,
        Puzzle,
        Collectable,
        Dangerous,
        Auid,
        Weapon,   
        };
    }
}