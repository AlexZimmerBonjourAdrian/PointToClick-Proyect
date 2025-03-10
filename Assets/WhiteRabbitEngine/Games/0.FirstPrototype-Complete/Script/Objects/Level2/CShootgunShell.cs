using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CShootgunShell : MonoBehaviour, Iinteract
{
    // Start is called before the first frame update

    [SerializeField]
    private int idRoom;
    public void Oninteract()
    {
        CManagerSFX.Inst.PlaySound(0);
        CLevel2.Inst.SetIsShootGunShell(true);
        CLevel2.Inst.SetRoomActive(idRoom, true);
    }

    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}
}