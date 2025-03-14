using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.WhileClear
{
    public class CMovement : MonoBehaviour
    {
         [SerializeField]
   private int id;
   public void Oninteract()
   {
    
       CGameManager.Inst.MoveLocation(id);
       CManagerSFX.Inst.PlaySound(0);
   }

  
    }
}
