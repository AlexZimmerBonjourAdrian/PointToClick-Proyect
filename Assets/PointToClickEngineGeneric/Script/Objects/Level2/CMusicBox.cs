using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMusicBox : MonoBehaviour, Iinteract
{
   [SerializeField]
    private int idRoom;
  public void Oninteract()
  {
    if(CLevel2.Inst.GetIsShootGunShell() && CLevel2.Inst.GetIsTakeShootGun())
    {
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }
  }
    


}
