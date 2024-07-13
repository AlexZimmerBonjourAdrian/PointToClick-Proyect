using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CGameController : MonoBehaviour
{
    //Texto que es mostrado al ugador
    public Text displayText;
    public CInputAction[] inputActions;
    //instancia de la clase CroomNavigation
    [SerializeField] public CRoomNavigation roomNavigation;
    //Lista de las Descripcioones de la Habitacion
    //Esta Es cargada Desde el Editor
    [SerializeField] public List<string> IneractionDescriptionInRoom = new List<string>();

    //Almacena el log de las acciones hechas en el juego
    List<string> actionLog = new List<string>();

    private void Awake()
    {
        //Se carga el el componente de la clase
        roomNavigation = GetComponent<CRoomNavigation>();
    }

    private void Start()
    {
        //Muestra el Texto de inicio
        DisplayRoomText();
        //Muestra los logs disponibles
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        //Carga uno de los elemenos mas recientes en el log de las acciones
        string logAsText = string.Join("\n", actionLog.ToArray());
        //Muestra  La accion Reciente en el Display del Texto
        displayText.text = logAsText;
    }
    public void DisplayRoomText()
    {
        //Borra la colecion de elementos de en una nueva Room para poder tener las opciones de esa habitacion
        ClearCollectionsForNewRoom();
        //
        UnpackRoom();
        //Esto Almacena en una variable Temporal la Descripcion de las interacciones del arreglo
        string joinedInteractionDescriptions = string.Join("\n", IneractionDescriptionInRoom.ToArray());
        //En un archivo temporal se almacena la lista de combinaciones posibles a efectuar en la abitacion
        string combinedText = roomNavigation.currentRoom.description +
            "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);

        
    }
    void UnpackRoom()
    {
        roomNavigation.UnpackExistsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        IneractionDescriptionInRoom.Clear();
        // roomNavigation.cl
        roomNavigation.ClearExits();
    }
    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}
