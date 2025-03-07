using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhiteRabbit.Core
{
    /// <summary>
    /// The CSFX class is a component designed to manage and play a single sound effect (SFX) within the game.
    /// It acts as a wrapper for an AudioClip and an AudioSource, providing methods to control the playback of the sound.
    /// 
    /// **Key Responsibilities:**
    /// 1. **Sound Effect Representation:** Represents a single sound effect in the game world.
    /// 2. **Audio Source Management:** Manages an AudioSource component, which is responsible for playing the sound.
    /// 3. **Sound Playback:** Provides methods to play the associated sound effect.
    /// 4. **Sound Control:** Offers methods to stop and loop the sound effect.
    /// 5. **Sound Destruction:** Allows for the destruction of the sound object when it's no longer needed.
    /// 6. **SFX Type Identification:** Stores the SFX type using the ESFXType enum for categorization.
    /// 7. **Audio Clip Storage:** Stores a reference to the specific AudioClip to be played.
    /// 
    /// **How It Works:**
    /// - This script is intended to be attached to a GameObject in a Unity scene.
    /// - The GameObject should represent a single instance of a sound effect.
    /// - Upon creation, it checks if an AudioSource exists on the GameObject. If not, it creates one.
    /// - It allows setting a specific sound (AudioClip) to be played.
    /// - Provides methods to play, stop, loop, and destroy the sound effect.
    /// - Allows setting the ESFXType of the sound effect.
    /// 
    /// **How to Use:**
    /// 1. **Add to GameObject:** In your Unity scene, add this `CSFX` script as a component to a GameObject.
    /// 2. **Assign AudioClip:** In the Inspector panel, drag and drop an AudioClip asset into the `sound` field.
    /// 3. **Set SFX Type:** Select the type of SFX using the `SFXType` dropdown in the inspector.
    /// 4. **Play the Sound:** Use the `PlaySFX()` method to start playing the sound effect.
    /// 5. **Stop the Sound:** Use the `StopSFX()` method to stop the currently playing sound effect.
    /// 6. **Looping:** Use the `SetLoopSound(bool loop)` method to set if the sound should be looped or not.
    /// 7. **Destroy:** Use the `DestroySFX()` method to destroy the GameObject and free up resources when the sound is no longer needed.
    /// 8. **Get data:**  Use the `GetSFXType()` and  `GetAudioClip()` methods to get the sfx type or the audio clip.
    /// 
    /// **Example Use Cases:**
    /// - **UI Sound Effects:** Play a sound when a button is clicked.
    /// - **Environmental Sounds:** Play a sound when an object collides with another.
    /// - **Character Actions:** Play a sound when a character performs an action.
    /// - **Ambience Sound:** Play a sound in loop for enviromental effects.
    /// 
    /// **Future Considerations:**
    /// - **Volume Control:** Add methods to control the volume of the sound.
    /// - **Pitch Control:** Add methods to control the pitch of the sound.
    /// - **Spatial Sound:** Add methods to configure the sound as 3D and control its spatial properties.
    /// - **Fade In/Out:** Add methods to smoothly fade the sound in and out.
    /// - **Pause/Resume:** Add methods to pause and resume the sound playback.
    /// 
    /// **Current Limitations:**
    /// - **Single Sound:** It is designed to manage a single sound effect per component.
    /// - **Basic Functionality:** Only provide basic function, like play, stop, loop and destroy.
    /// </summary>
    public class CSFX : MonoBehaviour
    {
        /// <summary>
        /// The AudioClip that will be played by this CSFX.
        /// You must assign an audio clip to this variable in the inspector.
        /// </summary>
        [SerializeField] private AudioClip sound;

        /// <summary>
        /// The AudioSource component responsible for playing the sound.
        /// This component will be added automatically if it is not present.
        /// </summary>
        [SerializeField] private AudioSource audioSource;

        /// <summary>
        /// The type of sound effect this CSFX represents, defined by the ESFXType enum.
        /// This is useful for categorization and sound management.
        /// </summary>
        [SerializeField] private ESFXType.SFXType SFXType;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// It gets the AudioSource component or adds one if it doesn't exist.
        /// </summary>
        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        /// <summary>
        /// Plays the sound effect associated with this CSFX.
        /// </summary>
        public void PlaySFX()
        {
            audioSource.clip = sound;
            audioSource.Play();
        }

        /// <summary>
        /// Stops the currently playing sound effect.
        /// </summary>
        public void StopSFX()
        {
            audioSource.Stop();
        }

        /// <summary>
        /// Destroys the GameObject to which this CSFX is attached.
        /// This should be called when the sound effect is no longer needed.
        /// </summary>
        public void DestroySFX()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Sets whether the sound effect should loop or not.
        /// </summary>
        /// <param name="loop">True if the sound should loop, false otherwise.</param>
        public void SetLoopSound(bool loop)
        {
            audioSource.loop = loop;
        }


        /// <summary>
        /// Gets the type of SFX that this object represent.
        /// </summary>
        /// <returns>The sfx type.</returns>
        public ESFXType.SFXType GetSFXType()
        {
            return SFXType;
        }

        /// <summary>
        /// Gets the audio clip associated with this SFX object.
        /// </summary>
        /// <returns>The audio clip.</returns>
        public AudioClip GetAudioClip()
        {
            return this.sound;
        }
    }
}
