using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDoor : MonoBehaviour, Iinteract
{
    [SerializeField]
    private int IndexLevel = 0;
    private bool ThisLevelIsComplete = false;
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
