using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CMusicBox : MonoBehaviour, Iinteract
{
   [SerializeField]
    private int idRoom;
  public void Oninteract()
  {
    if(CLevel2.Inst.GetIsShootGunShell() && CLevel2.Inst.GetIsTakeShootGun())
    {
       CManagerSFX.Inst.PlaySound(7);
        CLevel2.Inst.SetIsShootMusicBox(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }
  }
  
  public void OnStopInteract()
  {
    Debug.Log("Stopped interacting with " + gameObject.name);
  }


}
}
