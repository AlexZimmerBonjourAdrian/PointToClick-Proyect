using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Revolver", menuName = "Inventory/Revolver")]
public class CRevolver : CInventoryItemData
{
    
    public override void Use()
    {
        Debug.Log($"Disparando el {Name}");
        // Lógica específica para usar el revólver
    }

     public void Oninteract() // Implementa el método Oninteract
    {
        // Agrega este revolver al inventario
        Cinventory.Instance.AddItem(this);
       
        // Destroy(gameObject); 
    }
}
