using System;
using System.Collections.Generic;
using UnityEngine;


 namespace WhiteRabbit.Hierarchy
{   
    /// <summary>
    /// CAnimData is a ScriptableObject designed to store animation data for a specific animated object in the game.
    /// It provides a structured way to manage sequences of sprites that form an animation, along with descriptive metadata.
    /// This class is intended to be used in conjunction with an animation system that can play back these sprite sequences.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Animation Data Storage:** Stores a list of sprite sequences (`AnimMachine`), where each sequence represents a different animation state (e.g., idle, walk, attack).
    /// 2. **Descriptive Metadata:** Includes fields for a name, description, and ID to help identify and organize animation data.
    /// 3. **ScriptableObject:** Leverages Unity's ScriptableObject system for easy creation, storage, and management of animation data within the Unity Editor.
    /// 4. **Multi-State Animations:** Supports multiple animation states by storing a list of lists of sprites. Each inner list represents a single animation sequence.
    /// 5. **Organization:** Helps organize the animations into differents states and types.
    /// 
    /// **How it Works:**
    /// - **Name:** A string to identify the animation set (e.g., "PlayerAnimations", "Enemy1Animations").
    /// - **Description:** A brief description of the animation set and its purpose.
    /// - **Id:** A unique integer identifier for this specific set of animations.
    /// - **AnimMachine:** A list of lists of sprites. Each inner list `List<Sprite>` is an animation sequence.
    ///     - Each `List<Sprite>` represents a specific animation (e.g., walking left, attacking, idle).
    ///     - The order of sprites in the inner list defines the animation frames.
    ///     - The outer list `List<List<Sprite>>` contains all the differents animations for this object.
    /// 
    /// **How to Use:**
    /// 1. **Creation:** Create instances of this ScriptableObject in the Unity Editor (e.g., by right-clicking in the Project window and selecting "Create/PointToClick/Animation").
    /// 2. **Population:** Fill in the `Name`, `description`, and `Id` fields in the Inspector.
    /// 3. **Animation Sequences:** In the `AnimMachine` field, add lists of sprites for each animation. Drag and drop the desired sprite frames into each inner list.
    /// 4. **Access:** Other scripts can load these `CAnimData` ScriptableObjects and access the `AnimMachine` list to play the animations.
    /// 
    /// **Example Use Case:**
    /// - **Character Animation:** You might create a `CAnimData` for a player character, with animation sequences for idle, walking, running, jumping, and attacking.
    /// - **Object Animation:** You could also use this for animating objects, such as a door opening or a light flickering.
    /// - **UI Animation:** It can be used to animate the UI elements.
    /// 
    /// **Future Enhancements:**
    /// - **Animation Speed:** Add properties to control the playback speed of each animation sequence.
    /// - **Looping:** Add a flag to indicate whether an animation should loop.
    /// - **Triggers:** Add trigger events that can be fired at specific frames in an animation.
    /// - **Animation Names:** Instead of an index, add a name to the animation to find it by name.
    /// - **Animation Events:** Add a list of animation events.
    /// - **Animation Type:** Add a property to store the type of the animation.
    /// 
    /// **Current Limitations:**
    /// - **Manual Setup:** Animations are set up manually in the Unity Editor.
    /// - **No Animation Logic:** This class only stores data; it does not contain logic for playing animations.
    /// - **Sprite-Based:** The animations are based on sprite sequences.
    /// - **No animation parameters:** the animations are fixed.
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "NewAnimatioNData", menuName = "PointToClick/Animation")]
   
    public class CAnimData : ScriptableObject
    {
        /// <summary>
        /// The name of this animation set.
        /// </summary>
        public string Name;
        /// <summary>
        /// A brief description of the animation set.
        /// </summary>
        public string description;
        /// <summary>
        /// A unique ID for this animation set.
        /// </summary>
        public int Id;
        /// <summary>
        /// A list of animation sequences, where each sequence is a list of sprites.
        /// Each inner list represents a single animation state (e.g., idle, walk, attack).
        /// </summary>
        public List<List<Sprite>> AnimMachine;
    }
}
