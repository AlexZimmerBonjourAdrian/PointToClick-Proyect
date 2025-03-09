using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CPickupObject : MonoBehaviour, Iinteract
{
    public void Oninteract()
    {
        throw new System.NotImplementedException();
    }
    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}
}
