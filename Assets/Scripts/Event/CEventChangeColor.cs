using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEventChangeColor : MonoBehaviour 
{
    public int id; 

    public void Awake()
    {
        CPointToClick.Inst.CreatePoint();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        CGameEvent.current.OnChangeColor += OnChangeColorNow;
      
    }

    private void OnChangeColorNow(int id)
    {
        if(id == this.id)
        { 
        Color col = new Color(Random.value, Random.value, Random.value);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = col;
        }
    }
    // Update is called once per frame

    
    }



