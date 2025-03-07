using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CMag : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        CLevel2.Inst.SetIsMagRevolver(true);
         CManagerSFX.Inst.PlaySound(0);
         CLevel2.Inst.SetRoomActive(idRoom, true);
    }
}
}
