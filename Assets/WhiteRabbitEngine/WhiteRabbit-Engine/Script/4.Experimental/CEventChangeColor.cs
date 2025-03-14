using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.Experimental
{
    /// <summary>
    /// CEventChangeColor is a MonoBehaviour class that listens for a specific game event (OnChangeColor)
    /// and changes the color of the SpriteRenderer component of the GameObject it's attached to,
    /// when the event is triggered with a matching ID.
    ///
    /// **Key Responsibilities:**
    /// 1. **Event Listener:** Subscribes to the `OnChangeColor` event in the `CGameEvent` system.
    /// 2. **ID-Based Activation:**  Triggers a color change only when the received event's ID matches its own `id`.
    /// 3. **Random Color Generation:** Generates a random color when the event is triggered.
    /// 4. **Sprite Color Modification:** Modifies the color of the SpriteRenderer component on the same GameObject.
    /// 5. **Point and click trigger:** This class use CPointToClick to make a point. This is not necesary in the functionality of this class, but can be used.
    ///
    /// **How It Works:**
    /// - This script needs to be attached to a GameObject that has a `SpriteRenderer` component.
    /// - Each instance of this script has a unique `id`.
    /// - When the `OnChangeColor` event is raised in the `CGameEvent` system, all subscribed scripts receive the event.
    /// - This script checks if the `id` passed in the event matches its own `id`.
    /// - If the IDs match, it generates a random color and applies it to the `SpriteRenderer`.
    /// - This allows creating multiple objects with `CEventChangeColor`, each reacting to a different ID.
    /// - The `CreatePoint()` method, of the `CPointToClick` is called in Awake. this method is not used in this version but can be used in the future.
    ///
    /// **How to Use:**
    /// 1. **Create a Sprite:** Create a GameObject in your scene with a `SpriteRenderer` component.
    /// 2. **Add the Script:** Attach the `CEventChangeColor` script to the GameObject.
    /// 3. **Set the ID:** In the Inspector panel, set the `id` to a unique integer value for this object.
    /// 4. **Trigger the Event:**  Some other script must call `CGameEvent.current.ChangeColor(id);` with the corresponding ID to make the color change.
    /// 5. **Repeat:** You can repeat steps 1-3 to create multiple objects that change color based on different IDs.
    ///
    /// **Example Use Case:**
    /// - **Visual Feedback:** You can use this for visual feedback in a game, like changing the color of a button when an event happens.
    /// - **Puzzle Mechanics:** You might use this for a puzzle where multiple objects need to change color in specific ways based on events.
    /// - **Custom events:** Change the color of some objects when a specific event is triggered.
    ///
    /// **Future Improvements:**
    /// - **More Complex Changes:** Instead of just changing the color, you could change other properties of the `SpriteRenderer` or the GameObject.
    /// - **Multiple Events:** Make the script react to more than one type of event.
    /// - **Custom Color:** Add a property to set a specific color instead of generating a random one.
    /// - **Animation:** Add an animation for the color change.
    ///
    /// **Current Limitations:**
    /// - **Only SpriteRenderer:** Currently only works with GameObjects that have a `SpriteRenderer`.
    /// - **Only Color Change:** The only action taken is to change the color.
    /// - **Only One Event:** Only listens to the `OnChangeColor` event.
    /// - **Random color:** The color is always random.
    /// - **No error control:** No error control is implemented.
    /// - **Not point and click integration:** The point and click integration is not used in the current version.
    /// </summary>
    public class CEventChangeColor : MonoBehaviour
    {
        /// <summary>
        /// The unique ID of this object.
        /// This ID is used to determine if this object should react to the `OnChangeColor` event.
        /// </summary>
        public int id;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Subscribes to the OnChangeColor event and get the SpriteRenderer component.
        /// In this version is called the CreatePoint of CPointToClick, but this is not necesary for the class.
        /// </summary>
        public void Awake()
        {
            //This call is not necesary for the class, but can be usefull in a future.
            CPointToClick.Inst.CreatePoint();
            //SpriteRenderer sprite = GetComponent<SpriteRenderer>(); // Not used at this point but is good to know that is posible to get the sprite.
            //Subscribes to the CGameEvent.current.OnChangeColor event
            CGameEvent.current.OnChangeColor += OnChangeColorNow;
        }


        /// <summary>
        /// This method is called when the OnChangeColor event is triggered.
        /// If the received ID matches this object's ID, it changes the color of the SpriteRenderer to a random color.
        /// </summary>
        /// <param name="id">The ID passed with the event.</param>
        private void OnChangeColorNow(int id)
        {
            // Check if the received ID matches this object's ID.
            if (id == this.id)
            {
                // Generate a random color.
                Color col = new Color(Random.value, Random.value, Random.value);
                // Get the SpriteRenderer component.
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                // Change the color of the SpriteRenderer.
                sprite.color = col;
            }
        }
    }
}
