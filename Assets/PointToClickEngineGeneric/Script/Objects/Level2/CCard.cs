using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCard : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int idRoom;
     public void Oninteract()
     {
        CLevel2.Inst.SetIsTakeCard(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
     }
}
