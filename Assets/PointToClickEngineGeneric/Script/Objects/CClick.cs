using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CClick : MonoBehaviour,Iinteract
{
    public void Oninteract()
    {
        CGameEvent.current.OnSwitchLight();
    }
}
