using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.FirstPrototype
{
public class CObjectColor : MonoBehaviour, Iinteract
{
    public int id;
    public void Oninteract()
    {

        CGameEvent.current.OnChangeTrigger(id);
    }
    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}
}
