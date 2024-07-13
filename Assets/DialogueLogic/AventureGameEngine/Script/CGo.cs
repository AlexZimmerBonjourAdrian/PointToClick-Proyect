using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Input")]
public class CGo : CInputAction
{
   public override void RespondToInput(CGameController controller,string[] separatedInputWords)
    {
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}
