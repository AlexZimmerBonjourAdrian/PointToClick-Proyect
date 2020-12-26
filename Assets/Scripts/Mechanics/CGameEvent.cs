using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CGameEvent : MonoBehaviour
{

    public static CGameEvent current;
    // Start is called before the first frame update

    private void Awake()
    {
        current = this;
    }

    public event Action OnChangeColor;

    public void OnChangeTrigger()
    {
        if(OnChangeColor != null)
        {
            OnChangeColor();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
