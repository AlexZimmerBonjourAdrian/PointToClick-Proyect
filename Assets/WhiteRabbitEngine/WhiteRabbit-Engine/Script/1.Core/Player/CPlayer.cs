using System.Collections.Generic;
using UnityEngine;

 namespace WhiteRabbit.Core
{
public enum PlayerState
{
    Idle,
    Walking,
    Interacting
}

public class CPlayer : MonoBehaviour
{
    // --- Atributos ---
    [Header("Player Attributes")]
    public Vector2 position; // Posición del jugador en el mundo.
    public Room currentRoom; // Habitación actual del jugador.
    public List<CItem> inventory = new List<CItem>(); // Inventario del jugador.
    public string playerName = "Player"; // Nombre del jugador (puedes cambiarlo desde el inspector).
    public PlayerState state = PlayerState.Idle; // Estado actual del jugador.
    public float speed = 5f; // Velocidad del jugador.

    // --- Referencias ---
    [Header("References")]
    public CInputManager inputManager; // Referencia al gestor de input.
    public CLevelManager levelManager; // Referencia al gestor de niveles.
    public CUIManager uiManager; // Referencia al gestor de la UI.
    public CAnimation animationController; // Referencia al controlador de animaciones.

    // --- Métodos ---

    private void Awake()
    {
        //Inicializar en el awake
        if (inputManager == null)
        {
            inputManager = FindObjectOfType<CInputManager>();
            if (inputManager == null)
            {
                Debug.LogError("No hay inputManager en la escena.");
            }
        }
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<CLevelManager>();
            if (levelManager == null)
            {
                Debug.LogError("No hay levelManager en la escena.");
            }
        }
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<CUIManager>();
            if (uiManager == null)
            {
                Debug.LogError("No hay uiManager en la escena.");
            }
        }
    }

    private void Start()
    {
        // Inicializar la posición del jugador.
        position = transform.position;
        //Buscar la sala en la que esta el jugador.
        currentRoom = levelManager.GetRoomFromPosition(position);

    }
    private void Update()
    {
        //Actualizar la posicion del jugador
        position = transform.position;
    }

    public void MoveTo(Vector2 targetPosition)
    {
        // Por ahora, solo teletransporte (luego se podría añadir animaciones)
        state = PlayerState.Walking;
        transform.position = targetPosition;
        state = PlayerState.Idle;
        // Comprobar si se ha cambiado de habitacion.
        currentRoom = levelManager.GetRoomFromPosition(position);
    }

    public void Interact(CInteractableObject interactableObject)
    {
        state = PlayerState.Interacting;
        interactableObject.Oninteract();
        state = PlayerState.Idle;
    }

    public void PickUp(CItem item)
    {
        inventory.Add(item);
        uiManager.UpdateInventoryUI();
        // Eliminar el objeto de la escena.
        Destroy(item.gameObject);
    }
    public void RemoveItem(CItem item){
        if(inventory.Contains(item))
        {
            inventory.Remove(item);
            uiManager.UpdateInventoryUI();
        }
    }
    

    public void UseItem(CItem item, CInteractableObject target)
    {
        //Comprobar si el player tiene el objeto
        if (inventory.Contains(item))
        {
            //Implementar la logica de uso del objeto.
            Debug.Log("Usando " + item.name + " en " + target.name);
            // eliminar el item del inventario
            RemoveItem(item);
        }
        else
        {
            Debug.Log("No tienes " + item.name + " en el inventario.");
        }
    }

    public void Examine(CInteractableObject interactableObject)
    {
        // Mostrar una descripción del objeto (puede ser un mensaje, un texto en la UI, etc.)
        Debug.Log("Examinando: " + interactableObject.objectName+ ". Descripción: " + interactableObject.objectDescription);
    }

    public void ChangeRoom(Room room)
    {
        currentRoom = room;
        //Cargar la nueva sala
        levelManager.ChangeRoom(room.name);

    }

    public void TalkTo(CDialogueTrigger dialogueTrigger)
    {
        Debug.Log("Talk to: " + dialogueTrigger.name);
        //Iniciar el dialogo
        //Se podria hacer en otra clase
    }
}
}