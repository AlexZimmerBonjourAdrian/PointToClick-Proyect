using System.Collections.Generic;
using UnityEngine;

namespace WhiteRabbit.Core
{
    /// <summary>
    /// Represents a container that can hold items.
    /// This class allows the player to interact with a container, view its contents,
    /// and potentially take items from it.
    /// </summary>
    public class CContainer : CInteractableObject, Iinteract
    {
        [Header("Container Settings")]
        public List<CItem> containedItems = new List<CItem>(); // List of items inside the container.
        public bool isOpen = false; // Whether the container is currently open.
        public bool canBeClosed = true; // Whether the container can be closed after being opened.

        [Header("UI Settings")]
        public bool showContentInUI = true; //whether show the container content in UI.
        
        [Header("Debug Settings")]
        public bool showDebugLogs = false;

        // --- Methods ---

        /// <summary>
        /// Called when the player interacts with the container.
        /// </summary>
        public void Oninteract()
        {
            if (!isInteractable) return;

            base.Oninteract(); // Call the base interact method for general interaction.

            if (!isOpen)
            {
                OpenContainer();
            }
            else if (canBeClosed)
            {
                CloseContainer();
            }
            
        }

        public void OnStopInteract()
        {
            base.OnStopInteract(); // Call the base stop interact method.
        }

        /// <summary>
        /// Opens the container and reveals its contents.
        /// </summary>
        private void OpenContainer()
        {
            isOpen = true;
            if(showDebugLogs) Debug.Log(objectName + " opened.");

            if (showContentInUI)
            {
                 // Show the items in the UI 
                ShowContent();

            }
           
        }

        /// <summary>
        /// Closes the container, potentially hiding its contents.
        /// </summary>
        private void CloseContainer()
        {
            isOpen = false;
            if(showDebugLogs) Debug.Log(objectName + " closed.");

            if(showContentInUI)
            {
                // Hide the items in the UI
                HideContent();
            }
        }

        /// <summary>
        /// Adds an item to the container.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void AddItem(CItem item)
        {
            containedItems.Add(item);
            if(showDebugLogs) Debug.Log(item.name + " added to " + objectName);
            // Optionally, update the UI to show the new item.
             if(showContentInUI && isOpen)
            {
                ShowContent();
            }
        }

        /// <summary>
        /// Removes an item from the container.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void RemoveItem(CItem item)
        {
            if (containedItems.Contains(item))
            {
                containedItems.Remove(item);
                if(showDebugLogs) Debug.Log(item.name + " removed from " + objectName);
                // Optionally, update the UI to reflect the change.
                if(showContentInUI && isOpen)
                {
                    ShowContent();
                }
            }
            else
            {
                 if(showDebugLogs) Debug.LogWarning(item.name + " not found in " + objectName);
            }
        }

        /// <summary>
        /// Transfer an Item from the Container to the player's Inventory
        /// </summary>
        /// <param name="item">The item to transfer.</param>
        /// <param name="player">The player to transfer the item to.</param>
        // public void TakeItem(CItem item, CPlayer player)
        // {
        //     //Check if the player is not null.
        //     if(player == null)
        //     {
        //         Debug.LogError("Player is null.");
        //         return;
        //     }
        //     //Check if the item is in the container
        //     if (containedItems.Contains(item))
        //     {
        //         player.PickUp(item);
        //         RemoveItem(item);
        //     }
        //      else
        //     {
        //          if(showDebugLogs) Debug.LogWarning(item.name + " not found in " + objectName);
        //     }
        // }

         /// <summary>
        /// Show the contents of the container in the UI
        /// </summary>
         private void ShowContent()
        {
             if(showDebugLogs) Debug.Log("Show Contents of " + objectName);
           //Implement the logic to show the containter in the UI
           //For example: create a new panel with the items.
           //This code need a reference to the CUIManager.
           //And a new class to represent the container content.
           //Like CContainerUI

        }
        /// <summary>
        /// Hide the content of the container in the UI.
        /// </summary>
         private void HideContent()
        {
            if(showDebugLogs) Debug.Log("Hide Contents of " + objectName);
           //Implement the logic to hide the containter in the UI.
        }


      
    }
}
