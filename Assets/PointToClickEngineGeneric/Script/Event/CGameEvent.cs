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
                GameObject obj = new GameObject("PointMechanic");

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

    public void OnSwitchLight()
    {
        if(OnLight != null)
        {
            OnLight();
        }
    }

}
