using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 namespace Core
{
 
 [RequireComponent(typeof(Image))]

/// <summary>
/// The CUiAnimation class provides a way to create frame-by-frame UI animations using a sequence of sprites.
/// It's designed to be attached to a UI Image component and allows you to define animation frames that will be played sequentially.
/// 
/// **Key Responsibilities:**
/// 1. **Frame-by-Frame Animation:** Enables the creation of simple sprite animations for UI elements.
/// 2. **Sprite Management:** Manages a list of sprite sequences, allowing for multiple animations within a single component.
/// 3. **Animation Timing:** Controls the playback speed of the animation through the `duration` variable.
/// 4. **UI Image Integration:** Directly modifies the `Image` component it's attached to in order to display the animation frames.
///
/// **How it Works:**
/// - This script is intended to be attached to a GameObject with an `Image` component in a Unity UI Canvas.
/// - The `_lista` field holds a list of list. Each sub list represent a different animation.
/// - The `duration` field determines how long each animation should last.
/// - The `image` field refers to the `Image` component on the same GameObject.
/// - On start the class get the image component.
/// 
/// **How to Use:**
/// 1. **Create UI Element:** Create a UI Image object in your Unity scene.
/// 2. **Attach Script:** Add this `CUiAnimation` script as a component to the UI Image object.
/// 3. **Define Animations:** In the Inspector, create lists inside the `_lista` list. Each list will represent a differnet animation.
/// 4. **Add Frames:** Drag and drop the sprite frames in the desired order into the corresponding sub list.
/// 5. **Set Animation Duration:** Set the `duration` variable to control the overall length of each animation cycle (in seconds).
/// 6. **Start the animation** add a new function to start the animation, and call it from another class.
/// 
/// **Example Use Cases:**
/// - **Animated Buttons:** Add a simple "press" animation to a button.
/// - **Loading Indicators:** Display a rotating or pulsing animation while waiting for an operation to complete.
/// - **Animated Icons:** Add visual feedback to UI elements through animation.
/// 
/// **Future Improvements:**
/// - **Animation Looping:** Add options to control whether an animation loops or plays once.
/// - **Animation Triggering:** Add methods to start/stop specific animations.
/// - **More Animation Control:** Add methods to play the animation forward or backward.
/// - **Easing:** Add support for different animation easing functions.
/// - **Events:** Add events that get triggered at the start or end of an animation.
/// 
/// **Current Limitations:**
/// - **Basic Frame-by-Frame:** It only supports frame-by-frame animation.
/// - **No Pause/Resume:** There's no built-in functionality to pause or resume animations.
/// - **No Animation Blending:** There's no support for blending or transitioning between animations.
/// - **Manual Animation Triggering:** You'll need to implement your own logic to trigger the animations.
/// - **No reverse**: it only play the animation forward.
/// </summary>
public class CUiAnimation : MonoBehaviour
{
    /// <summary>
    /// The duration of each animation cycle in seconds.
    /// This value controls how quickly the animation frames are displayed.
    /// </summary>
    public float duration;

    /// <summary>
    /// A list of list of sprites representing the animations.
    /// Each sub list is a sequence of animation frames for a specific animation.
    /// </summary>
    [SerializeField] public List<List<Sprite>> _lista;
    
      
    /// <summary>
    /// The Image component that will display the animation frames.
    /// </summary>
    [SerializeField] private Image image;


    /// <summary>
    /// This function is called when the script instance is loaded.
    ///  Here you can add the logic to initialize variables or get the image component.
    /// </summary>
    private void Awake()
    {
       
    }
    /// <summary>
    /// This function is called when the script start.
    /// here, get the image component.
    /// </summary>
    void Start()
    {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// this function is an example about how to start the animation.
    /// </summary>
    /// <param name="idAnimation">id of the list of animation</param>
    public void StartAnimation(int idAnimation)
    {
        if(idAnimation< 0 || idAnimation>= _lista.Count)
        {
            Debug.LogError("the id of the animation is invalid");
        }
        else
        {
            StartCoroutine(AnimationCoroutine(idAnimation));
        }
    }

    /// <summary>
    /// this is the coroutine that manage the animation.
    /// </summary>
    /// <param name="idAnimation">id of the list of animation</param>
    /// <returns></returns>
    private IEnumerator AnimationCoroutine(int idAnimation)
    {
         //get the list of the animation
        List<Sprite> animation = _lista[idAnimation];
        //calculate the time between each frame
        float timeBetwenFrame = duration/animation.Count;

        while(true)
        {
           foreach(Sprite frame in animation)
            {
                //change the frame
                image.sprite = frame;
                //wait the necessary time
                yield return new WaitForSeconds(timeBetwenFrame);
            }
        }
       
    }
    
}
}
