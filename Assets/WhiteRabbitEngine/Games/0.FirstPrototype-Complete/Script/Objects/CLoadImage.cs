using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WhiteRabbit.Core;

namespace WhiteRabbit.FirstPrototype
{
public class CLoadImage : MonoBehaviour, Iinteract
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private bool isLoad = false;
    public void Oninteract()
    {
        if(!isLoad)
        {
            image.sprite = sprite;
            isLoad = true;
        }
        else
        {
            image.sprite = null;
            isLoad = false;
        }
    }
    
    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + gameObject.name);
    }
}

}
