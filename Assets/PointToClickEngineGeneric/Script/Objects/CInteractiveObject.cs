using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInteractiveObject : MonoBehaviour,Iinteract
{
    public int id;


    //Temp Prototipe
    private SpriteRenderer SpriteRenderer;

    public void Awake()
    {
        CPointToClick.Inst.CreatePoint();
        CGameEvent.current.OnChangeColor += Selected;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Oninteract()
    {
        Selected(id);
    }

    public void Selected(int id)
    {
        SpriteRenderer.color = Color.blue;
        CLevel1.Inst.CheckSuccesfull(id);
    }

    public void Deselected()
    {
        SpriteRenderer.color = Color.white;
    }
  
    public void Complete()
    {
        SpriteRenderer.color = Color.yellow;
    }
    


}
