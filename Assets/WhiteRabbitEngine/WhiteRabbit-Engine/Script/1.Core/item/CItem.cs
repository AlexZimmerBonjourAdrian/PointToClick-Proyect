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

       

     

    }
}
