using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CShootGunNotAmmo : MonoBehaviour, Iinteract
{
     [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
           Selected();
    }

    private void Selected()
    {
            CManagerSFX.Inst.PlaySound(0);
            CLevel2.Inst.SetIsTakeShootgun(true);
             CLevel2.Inst.SetRoomActive(idRoom, true);
    }

    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}
}
