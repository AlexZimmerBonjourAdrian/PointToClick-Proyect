using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 namespace WhiteRabbit.Core
  {
/// <summary>
/// Interface for objects that can be interacted with all elements to touch or click.
/// </summary>

public interface Iinteract 

{
    // Start is called before the first frame update
    void Oninteract();
    
    void OnStopInteract();
    
}
}
