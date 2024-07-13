using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRoomNavigation : MonoBehaviour
{
    //Carga la conrrespondiente habitacioj
    public CRoom currentRoom;
    //Todo: investigar Diccionario

    Dictionary<string, CRoom> exitDictionary = new Dictionary<string, CRoom>();
    //se carga el controller 
    CGameController controller;

    private void Awake()
    {
        //Carga el GameController
        controller = GetComponent<CGameController>();
    }

    public void UnpackExistsInRoom()
    {
        //Desenpaqueta buscando la habitacion conrrespondiente con sus respectivas salidas
        for(int i = 0; i< currentRoom.exits.Length;i++)
        {
            //añade al dicionario de las salidas la salida de la habitacion correspondiente buscada por la clave y el valod de la abitacion
            exitDictionary.Add(currentRoom.exits[i].keystring, currentRoom.exits[i].valueRoom);
            //se añadeden las interacion de las habitaciones y su descripcion 
            controller.IneractionDescriptionInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }
    public void AttemptToChangeRooms(string directionNoun)
    {
        //Todo Investigar esto
        if(exitDictionary.ContainsKey (directionNoun))
        {
            //
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You head off to the" + directionNoun);

            // Muestra los El Texto en la habitacion
            controller.DisplayRoomText();
        }
        else
        {
            // Error general.
            controller.LogStringWithReturn("There is no path to the " + directionNoun);
        }

    }
    public void ClearExits()
    {
        //vacia eñ dicionario con la salida correspondiente 
        exitDictionary.Clear();
    }
}
