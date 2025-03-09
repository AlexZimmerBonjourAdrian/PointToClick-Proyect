using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.FirstPrototype
{
public class CDoor : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int IndexLevel = 0;
    [SerializeField]private bool ThisLevelIsComplete = false;
    private SpriteRenderer SpriteRender;
    private void Awake()
    {
        CPointToClick.Inst.CreatePoint(); 
    }
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }
    public void Oninteract()
    {
        Debug.Log(ThisLevelIsComplete);
        if(ThisLevelIsComplete == true)
        {
            CLevelManager.Inst.LoadScene(IndexLevel);
        }
        else
        {
            Debug.LogError("El nivel no esta completo");
        }
    }
    
    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }

    public void SetRoom(int idex)
    {
         IndexLevel = idex;
    }
    public void SetThisLevelIsComplete(bool isBool)
    {
        ThisLevelIsComplete = isBool;
    }

    public void ViewDoor()
    {
        SpriteRender.color = new Color(255f, 255f, 255f, 255f);
    }
}
}
