using UnityEngine;
using WhiteRabbit.Core; 

 namespace WhiteRabbit.Hierarchy
{
    /// <summary>
    /// The CEnemy class serves as a base class for creating enemy characters within the game.
    /// It provides common functionality and properties that are shared across all enemy types.
    /// This class uses an abstract design pattern, meaning it cannot be directly instantiated but
    /// must be inherited by concrete enemy classes.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Enemy Base Class:**  Provides a foundation for creating different types of enemies.
    /// 2. **Animation Management:** Manages the enemy's animations using an `Animator` component.
    /// 3. **Unique Identification:**  Assigns a unique ID (`id`) to each enemy for referencing purposes.
    /// 4. **Name Storage:** Holds the enemy's name (`CharacterName`) for potential UI display.
    /// 5. **Life Management:**  Tracks the enemy's health (`life`) and whether it's dead (`isDead`).
    /// 6. **Sprite Management:** Allows for changing the enemy's sprite from a set of predefined sprites.
    /// 7. **Interaction Handling:** Include the `Oninteract` method to be use when the character is interacting.
    /// 8. **Abstract Methods:** Declares abstract methods (`DiscountLife`, `SetRandomSprite`, `SetSpriteByIndex`) that must be implemented by derived classes.
    /// 
    /// **How It Works:**
    /// - This script is intended to be a base class and will not be used as is. It should be inherited by specific enemy types.
    /// - The `Animator` component should be present on the same GameObject or a child of it to control animations.
    /// - The `id` is a unique identifier for the enemy.
    /// - `CharacterName` holds the enemy's name.
    /// - `life` represents the enemy's current health.
    /// - `isDead` indicates whether the enemy is dead.
    /// - `enemySprites` is an array of sprites that can be used to change the enemy's appearance.
    /// - `image` is the UI Image component used to display the enemy's sprite.
    /// - `Start` gets the `Animator` component and sets a random sprite from `enemySprites`.
    /// - The `Oninteract`  is a place holder, this method should be override in each subclass.
    /// -`DiscountLife` is an abstract method to reduce the enemy's life.
    /// -`SetRandomSprite` is an abstract method to set a random sprite from the enemySprites list.
    /// -`SetSpriteByIndex` is an abstract method to set a specific sprite by index.
    /// 
    /// **How to Use:**
    /// 1. **Create an Enemy Type:** Create a new C# script that inherits from `CEnemy` (e.g., `CEnemyGoblin`, `CEnemySkeleton`).
    /// 2. **Override Abstract Methods:** Implement the `DiscountLife`, `SetRandomSprite`, and `SetSpriteByIndex` methods in your new enemy class.
    /// 3. **Add Components:**
    ///     - Add an `Animator` component to the enemy GameObject.
    ///     - Add the new enemy script (e.g., `CEnemyGoblin`) as a component to the same GameObject.
    ///     - Add an Image Component if it not have it.
    /// 4. **Set Parameters:**
    ///     - In the Inspector, set the `id` to a unique integer for this enemy.
    ///     - Set the `CharacterName` for the enemy.
    ///     - Set the `life` value for the enemy.
    ///     - In the enemy sprite add all the sprite that it will use.
    ///     - Add in the image field the image component.
    /// 5. **Configure Animations:** Create animation states and transitions in the `Animator` component.
    /// 
    /// **Example Use Cases:**
    /// - **Different Enemy Types:** Create various types of enemies (e.g., goblins, skeletons, dragons) with unique behavior and attributes.
    /// - **Combat System:** Use the `DiscountLife` method to implement a combat system where enemies can take damage.
    /// - **Visual Variety:** Use the `enemySprites` and `SetRandomSprite` to provide visual variety among enemies of the same type.
    /// 
    /// **Future Improvements:**
    /// - **More Animations:** Add more animation triggers, like taking damage, attacking, or dying.
    /// - **More Data:** Add more stats or attributes, like attack power, defense, movement speed, etc.
    /// - **AI Behavior:** Add an AI system to control the enemies' behavior.
    /// - **Death Handling:** Add logic for what happens when the enemy dies (e.g., dropping items, playing a death animation).
    /// - **Enemy States:** Add states like "attacking," "patrolling," etc., which could affect animations and behavior.
    /// - **Conditional sprite change**: add the posibility to change the sprite based in a condition.
    /// - **Conditional animation**: add the posibility to add conditional animation.
    /// - **Abstract onInteract**: convert the onInteract method in an abstract method.
    /// 
    /// **Current Limitations:**
    /// - **Abstract Design:** It is an abstract class and cannot be used directly.
    /// - **Basic Functionality:** Only provides basic enemy functionality.
    /// - **No AI:** There is no built-in AI behavior.
    /// - **No death logic**: There is no logic that manage when the enemy die.
    /// - **Basic interaction**: the method `onInteract` does nothing.
    /// </summary>
public abstract class CEnemy : MonoBehaviour
{
    /// <summary>
    /// The Animator component used to control the enemy's animations.
    /// </summary>
    private Animator anim;
    
    /// <summary>
    /// The unique identifier for this enemy.
    /// </summary>
    public  int id;
    
    

    /// <summary>
    /// The name of the character.
    /// This can be used for display purposes (e.g., in dialogue boxes).
    /// </summary>
    [SerializeField]
    private string CharacterName;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes the Animator component and sets a random sprite.
    /// </summary>
    void Start()
    {
        // Get the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
          SetRandomSprite(); // Set a random sprite on start 
        
    }

    /// <summary>
    /// Called when the character is interacted with.
    /// This is a placeholder method and should be implemented in derived classes.
    /// </summary>
    public void Oninteract()
    {   
        // This method is a placeholder, each enemy class should override this to add his interaction.
    }


    /// <summary>
    /// The current life of the enemy.
    /// </summary>
    public float life;
    
    /// <summary>
    /// Flag to indicate if the enemy is dead.
    /// </summary>
    public bool isDead;

  

    /// <summary>
    /// Array of sprites that can be used for the enemy's visual representation.
    /// </summary>
    [SerializeField] private Sprite[] enemySprites;  // Array to hold enemy sprites
    
    /// <summary>
    /// The UI Image component that will display the enemy's sprite.
    /// </summary>
    [SerializeField] private UnityEngine.UI.Image image; // The SpriteRenderer component


    /// <summary>
    /// Abstract method to reduce the enemy's life.
    /// </summary>
    /// <param name="lifeSubstract">The amount of life to substract.</param>
    public abstract void DiscountLife(float lifeSubstract);
 

    /// <summary>
    /// Abstract method to set a random sprite for the enemy from the enemySprites array.
    /// </summary>
    public abstract void SetRandomSprite();
  

    /// <summary>
    /// Abstract method to set a specific sprite for the enemy by index.
    /// </summary>
    /// <param name="index">The index of the sprite in the enemySprites array.</param>
    public abstract void SetSpriteByIndex(int index);


}
}
