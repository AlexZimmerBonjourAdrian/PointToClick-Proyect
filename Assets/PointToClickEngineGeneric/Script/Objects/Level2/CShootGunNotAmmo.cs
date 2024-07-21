using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShootGunNotAmmo : MonoBehaviour, Iinteract
{
     [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        
            CLevel2.Inst.SetIsTakeShootgun(true);
             CLevel2.Inst.SetRoomActive(idRoom, true);
    }
}
