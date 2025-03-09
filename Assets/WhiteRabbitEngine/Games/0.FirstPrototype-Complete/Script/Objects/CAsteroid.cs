using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;
namespace WhiteRabbit.FirstPrototype
{
public class CAsteroid : MonoBehaviour, Iinteract
{
    [SerializeField]
    private SpriteRenderer spriterender;
    private Color ColorNormal = Color.white;
    Color ColorAlterate = new Color(232, 255, 0, 255);
    private bool bul = false;
    void Awake()
    {
        spriterender = GetComponent<SpriteRenderer>();
    }
  
    public void Oninteract()
    {
        ChangeColor();
    }


    private void ChangeColor()
    {

        switch(bul)
        {
            case false:
                spriterender.color = ColorNormal;
                break;
            case true:
                spriterender.color = ColorAlterate;
                break;
        }

        bul = !bul;
        
    }

    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }

}
}
