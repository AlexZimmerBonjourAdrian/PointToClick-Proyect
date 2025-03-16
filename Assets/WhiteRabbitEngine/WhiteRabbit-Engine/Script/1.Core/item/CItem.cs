using UnityEngine;

namespace WhiteRabbit.Core
{
    public class CItem : MonoBehaviour
    {
        [Header("Item Data")]
        public string itemName = "New Item"; // Name of the item.
        [TextArea(3, 10)]
        public string itemDescription = "This is a new item."; // Description of the item.
        public Sprite itemIcon; // Icon of the item.
        public bool isUsable = true; // Can the item be used?
        public bool isKeyItem = false; // Is the item a key item?
        public bool isVisible = true; // Is the item visible in the world?

        // You can add more properties based on your game logic:
        // - isConsumable: can be consumed?
        // - isEquippable: can be equipped?
        // - itemType: what type of item is it? (weapon, tool, etc.)
        // - useEffect: what happens when you use it?

        // Methods related to the item can be added here.
        // For example:
        // public void Use() {
        //   // Logic for using the item.
        // }
        // public void Examine(){
        //      //Logic for examine the item
        // }

        // Example of a method to use the item.
        public virtual void Use(CPlayer player, CInteractableObject target = null)
        {
            if (!isUsable)
            {
                Debug.LogWarning(itemName + " cannot be used.");
                return;
            }
            if(target != null){
                Debug.Log("Usando " + itemName + " en " + target.objectName);
                 player.RemoveItem(this);
            }
            else{
                Debug.Log("Using " + itemName);
                 player.RemoveItem(this);
            }
           
            // Add any specific use logic here.
            // For example, if it's a key, check if it's the right key for the target.
            // If it's a potion, apply the potion's effect.
        }

        public virtual void Examine(CPlayer player)
        {
            Debug.Log(itemName + ":" + itemDescription);
        }
        private void OnValidate()
        {
            // This method is called when the script is loaded or a value is changed in the Inspector.
            if(itemIcon == null)
             Debug.LogWarning("item: " + itemName + " don't have an icon.");
           
        }

    }
}
