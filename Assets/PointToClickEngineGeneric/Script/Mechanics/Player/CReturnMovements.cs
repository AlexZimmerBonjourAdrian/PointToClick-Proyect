using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReturnMovements : MonoBehaviour, Iinteract
{
   [SerializeField]
   private int id;
   public void Oninteract()
   {
     if(CLevel2.Inst.GetIsComplete())
     {
      id = 12;
      CLevel2.Inst.SetRoomActive(id,true);
     }

      else if(CLevel2.Inst.GetIsTakeShootGun() == true)
      {
         id = 14;
         CLevel2.Inst.SetRoomActive(id,true);
      }
      else
      {
         id = 0;
         CLevel2.Inst.SetRoomActive(id,true);
      }
   }


//    public CheckConditionFinish()
//    {

//    }
}
   
