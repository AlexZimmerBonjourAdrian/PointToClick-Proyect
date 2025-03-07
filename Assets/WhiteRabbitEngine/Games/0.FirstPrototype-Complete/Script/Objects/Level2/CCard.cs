using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.FirstPrototype
{
public class CCard : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int idRoom;
     public void Oninteract()
     {
        Selected();
     }

     public void Selected()
     {
       CManagerSFX.Inst.PlaySound(6);
        CLevel2.Inst.SetIsTakeCard(true);
        CLevel2.Inst.SetIsFinished(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
     }
}
}
