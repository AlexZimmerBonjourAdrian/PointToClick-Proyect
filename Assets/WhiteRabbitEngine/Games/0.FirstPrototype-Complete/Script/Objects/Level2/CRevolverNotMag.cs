using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CRevolverNotMag : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        CLevel2.Inst.SetIsRevolver(true);
        CManagerSFX.Inst.PlaySound(0);
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }

    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}
}

