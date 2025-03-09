using UnityEngine;

 namespace WhiteRabbit.Core
{

public class CInteractableObject : MonoBehaviour, Iinteract 
{
    public string objectName = "Interactable Object";
    public string objectDescription = "This is an interactable object.";
    public bool isInteractable = true;

    public void  Oninteract()
    {
        Debug.Log("Interacting with " + objectName);
    }

    public void OnStopInteract()
    {
        Debug.Log("Stopped interacting with " + objectName);
    }
}

}
