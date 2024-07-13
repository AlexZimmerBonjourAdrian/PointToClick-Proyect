using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Las habitaciones son objetos virtuales que almacenan informacion 
//La informacion se guarda de forma individual por objeto en vez de en uno solo

[CreateAssetMenu (menuName = "TextAdventure/Room")]
public class CRoom : ScriptableObject
{
    [TextArea(20, 20)]
    public string description;
    public string roomName;
    public CExit[] exits;
}
