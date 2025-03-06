using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CClick : MonoBehaviour,Iinteract
{
    
    public void Oninteract()
    {
        if(CLevelController.Inst.GetLevel() == 1)
        {
          CManagerSFX.Inst.PlaySound(0);
          CGameEvent.current.OnSwitchLight();
        }
        
    }
}
