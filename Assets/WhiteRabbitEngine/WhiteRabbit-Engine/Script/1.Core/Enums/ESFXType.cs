using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// Enum to define the type of sound effect in the game.
/// </summary>

 namespace WhiteRabbit.Core
  {

  public static class ESFXType 
  {
    
      public enum SFXType
      {
        None,
        Selected,
        Unselected,
        Click,
        pickUp,
        Drop,

        Talk,

        Walk,

        Reload,

        Boom,

        Shoot,

        Quack,

        Death,
        Save,
        Load,
        Exit,

        SuccesfullDialog,

        NothingToInteract,

        SpotLight,
        Door,
        Elevator,
        



      }
  }
}
