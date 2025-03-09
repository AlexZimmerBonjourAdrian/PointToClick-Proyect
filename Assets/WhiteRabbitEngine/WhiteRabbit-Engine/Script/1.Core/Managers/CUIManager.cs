using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

namespace WhiteRabbit.Core
{
    public class CUIManager : MonoBehaviour
    {
        // --- Inventory UI ---
        [Header("Inventory UI")]
        public Transform inventoryPanel; // Panel to hold inventory items
        public GameObject inventoryItemPrefab; // Prefab for an inventory item slot

        // --- References ---
        private CPlayer player;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // Find the player on start
            player = FindObjectOfType<CPlayer>();
            if(player == null)
            {
                Debug.LogError("No player found in the scene");
            }
             if (inventoryPanel == null)
            {
                Debug.LogError("Inventory Panel not assigned in CUIManager.");
            }
            if (inventoryItemPrefab == null)
            {
                Debug.LogError("Inventory Item Prefab not assigned in CUIManager.");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        // --- Inventory UI Methods ---
        public void UpdateInventoryUI()
        {
            if (player == null) return;
            if (inventoryPanel == null) return;
            if (inventoryItemPrefab == null) return;

            // Clear existing items
            foreach (Transform child in inventoryPanel)
            {
                Destroy(child.gameObject);
            }

            // Add new items
            foreach (CItem item in player.inventory)
            {
                GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel);
                // Get the Image component of the new Item.
                Image itemImage = newItem.GetComponent<Image>();

                if (itemImage != null && item.itemIcon != null)
                {
                    // Set the image icon of the item.
                    itemImage.sprite = item.itemIcon;
                }
                else
                {
                    Debug.LogWarning("No se pudo establecer la imagen del icono del item." + item.name);
                    if(item.itemIcon == null)
                     Debug.LogWarning("Icon is null." + item.name);
                }
            }
        }
    }
}
