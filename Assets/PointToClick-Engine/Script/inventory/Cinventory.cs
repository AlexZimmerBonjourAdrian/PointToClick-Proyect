using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinventory : MonoBehaviour
{
    // Singleton para acceder al inventario desde cualquier lugar
    public static Cinventory Instance { get; private set; }

    private List<IInventoryItem> inventory = new List<IInventoryItem>();

    private void Awake()
    {
        // Asegurar que solo haya una instancia del inventario
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Método para agregar un objeto al inventario
    public void AddItem(CInventoryItemData itemData)
    {
        inventory.Add(itemData);
        Debug.Log($"{itemData.Name} añadido al inventario.");
    }

    // Método para usar un objeto del inventario por su índice
    public void UseItem(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            inventory[index].Use();
        }
        else
        {
            Debug.LogError("Índice de inventario inválido.");
        }
    }
}
