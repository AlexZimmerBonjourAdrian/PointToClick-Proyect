using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CLightSwitch : CGenericObject
{
    
    public bool IsActive;
    public bool IsComplete = false;
    public SpriteRenderer SpriteBackGround;
    public Sprite[] SpriteLight;


    public void Awake()
    {
        SpriteBackGround = GetComponent<SpriteRenderer>();
        CPointToClick.Inst.CreatePoint();
        CGameEvent.current.OnLight += SwitchLight;
    }


    public void SwitchLight()
    {
        if(IsComplete == false)
        {

        IsActive = !IsActive;
        if (IsActive)
        {
            SpriteBackGround.sprite = SpriteLight[0];
        }
        else
        {
            SpriteBackGround.sprite = SpriteLight[1];
        }

        }
    }

    public void ExtraTypes()
    {
        if(SpriteLight == null)
        {
            SpriteBackGround.sprite = SpriteLight[2];
        }
    }

    public void CompleteLight()
    {
        IsComplete = true;
        if (IsComplete == true)
        {
            SpriteBackGround.sprite = SpriteLight[3]; 
        }
    }

    public void ResetLight()
    {
        SpriteBackGround.sprite = SpriteLight[0];
        IsActive = false;
    }



}
