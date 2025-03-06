using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CGameEvent : MonoBehaviour
{

    public static CGameEvent current
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("GameEvent");

                return obj.AddComponent<CGameEvent>();
            }
            return _inst;
        }
    }
    private static CGameEvent _inst;
    // Start is called before the first frame update

    private void Awake()
    {
        _inst = this;
    }

    public event Action<int> OnChangeColor;

    public event Action OnLight;

    public event Action<int> OnSelected;

    public event Action OnMove;

    // public event Action<int> OnSelectedMove;
    //Remove
    public void OnChangeTrigger(int id)
    {
        if(OnChangeColor != null)
        {
            OnChangeColor(id);
        }
    }
    public void Selected(int id)
    {
        if(OnSelected != null)
        {
            OnSelected(id);
        }
    }

    // public void SelectedMove(int id)
    // {
    //     if(OnSelectedMove != null)
    //     {
    //         OnSelectedMove(id);
    //     }
    // }
    //Repair
    public void OnSwitchLight()
    {
        if(OnLight != null)
        {
            OnLight();
        }
    }

    public void Move()
    {
        if(OnMove != null)
        {
            OnMove();
        }
    }
}
