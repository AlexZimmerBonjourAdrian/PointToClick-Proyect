using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhileClear
{
    public class CMovement : MonoBehaviour
    {
         [SerializeField]
   private int id;
   public void Oninteract()
   {
    
       CGameManager.Inst.MoveLocation(id);
       CManagerSFX.Inst.PlaySFX(0);
   }

  
    }
}
