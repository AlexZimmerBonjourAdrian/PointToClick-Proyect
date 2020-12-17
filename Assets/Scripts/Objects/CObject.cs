using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObject : MonoBehaviour, Iinteract
{
    [SerializeField]
    private string Texto= " ";
   public void Oninteract()
    {
        Debug.Log(Texto);
    }
}
