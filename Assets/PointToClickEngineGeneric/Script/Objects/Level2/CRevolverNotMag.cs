using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRevolverNotMag : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        CLevel2.Inst.SetIsRevolver(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }
}
