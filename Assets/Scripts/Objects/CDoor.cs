using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoor : MonoBehaviour, Iinteract
{
    [SerializeField]
    private string nameScene = " ";

    private void Awake()
    {
        CPointToClick.Inst.CreatePoint();
    }
    public void Oninteract()
    {
     
        CSwitch.Inst.SwitchScene(nameScene);
    }
}
