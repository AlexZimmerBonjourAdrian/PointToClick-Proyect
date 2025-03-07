using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

 
/// <summary>
/// This class is a singleton that manages the sound effects (SFX) in the game.
/// It provides functionality to play, stop, and manage various sound effects.
/// It utilizes an AudioMixer for advanced audio management and control.
/// 
/// **Key Responsibilities:**
/// 1. **Singleton Pattern:** Ensures only one instance of CManagerSFX exists throughout the game.
/// 2. **SFX Library:** Manages a list of available sound effects (AudioClips).
/// 3. **AudioMixer Integration:** Uses an AudioMixer for audio mixing, volume control, and potential effects.
/// 4. **Dynamic Sound Object Creation:** Creates temporary GameObjects with AudioSource components to play sounds.
/// 5. **SFX Playback:** Provides methods to play specific sound effects by type or ID.
/// 6. **SFX Management:** Offers methods to stop all playing sound effects.
/// 7. **Sound Mapping (future):** The `soundMap` dictionary is intended for future use in mapping AudioClips to custom names or identifiers, although it's not currently used.
/// 8. **CSFX class:** This class is used to manage a single sfx.
/// 9. **ESFXType class:** This class enum the diferent SFX type.
///
/// **How to Use:**
/// 1. **Adding Sound Effects:** Add AudioClip assets to the `ListSFX` in the Inspector.
/// 2. **Setting up Audio Mixer:** Configure the `audioMixer` in the Inspector to manage SFX volume and effects.
/// 3. **Playing a Sound Effect by Type:** Use `CManagerSFX.Inst.PlaySFX(ESFXType.SFXType type)` to play a sound effect associated with an enum type.
///    - The enum type should have the same name as the audio clip.
/// 4. **Playing a Sound Effect by ID:** Use `CManagerSFX.Inst.PlaySound(int id)` to play a sound effect based on its index in the `ListSFX`.
/// 5. **Stopping all Sound Effects:** Use `CManagerSFX.Inst.StopSFX()` to halt all currently playing SFX.
///
/// **Future Enhancements:**
/// - Implement the `soundMap` dictionary for mapping AudioClips to custom names for more flexible sound management.
/// - Add methods for pausing, resuming, or fading SFX.
/// - Add method to delete a sfx.
/// - Implement a system to avoid duplicate sfx.
/// - Add more sfx type
/// - Add methods to control the sfx volume.
/// </summary>

 namespace WhiteRabbit.Core
  {

public class CManagerSFX : MonoBehaviour
{   
    /// <summary>
    /// Singleton instance of CManagerSFX. Provides global access to the SFX manager.
    /// </summary>
    public static CManagerSFX Inst
    {
        get
        {
            // Check if the instance already exists
            if (_inst == null)
            {
                // Try to find an existing CManagerSFX in the scene
                _inst = FindFirstObjectByType<CManagerSFX>();
                if (_inst == null)
                {
                    // If no instance is found, create a new GameObject and add CManagerSFX to it
                    GameObject obj = new GameObject("ManagerSFX");
                    _inst = obj.AddComponent<CManagerSFX>();
                }
            }
            return _inst;
        }
    }

    private static CManagerSFX _inst;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Ensures that only one instance of CManagerSFX exists (Singleton pattern).
    /// </summary>
    public void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
       // DontDestroyOnLoad(this.gameObject); //removed,  It is not necessary to avoid destroy this object when a new scene load.
        _inst = this;
    }


    /// <summary>
    /// List of available sound effects. Add your AudioClip assets to this list in the Inspector.
    /// </summary>
    [SerializeField] public List<AudioClip> ListSFX;

    /// <summary>
    /// AudioMixer for managing sound effects volume and effects.
    /// </summary>
    [SerializeField] public AudioMixer audioMixer;

    /// <summary>
    /// List of currently playing sound objects.
    /// </summary>
    private List<GameObject> ListSounds= new List<GameObject>();


    /// <summary>
    /// Dictionary to map AudioClips to custom names or identifiers. (Currently not used, for future use).
    /// </summary>
    [SerializeField]public Dictionary<AudioClip, string> soundMap = new Dictionary<AudioClip, string>();
    
    /// <summary>
    /// This update is used to remove the sfx that are finished.
    /// </summary>
    public void Update()
    {
       // ListSounds.RemoveAll(sound => sound == null);
    }
    
     /// <summary>
    /// This function will be add a new sfx.
    /// This is not used at this moment.
    /// </summary>
    public void AddSound()
    {
    GameObject soundObject = new GameObject("Sound");
    soundObject.AddComponent<AudioSource>();
    ListSounds.Add(soundObject);
    }
  
    /// <summary>
    /// Plays a sound effect based on the SFX type (defined by the ESFXType enum).
    /// </summary>
    /// <param name="type">The type of SFX to play.</param>
      public void PlaySFX(ESFXType.SFXType type)
    {
        // Buscar el AudioClip correspondiente al tipo de SFX
        AudioClip clip = ListSFX.Find(c => c.name == type.ToString());
        if (clip != null)
        {
            // Create a temporal sound object.
            GameObject soundObject = new GameObject("Sound");
            //Add a new CSFX component to control it.
            soundObject.AddComponent<CSFX>();
            //Add an audiosource to play the clip.
            soundObject.AddComponent<AudioSource>().clip = clip;
            //play the sfx
            soundObject.GetComponent<AudioSource>().Play();
            //add the sfx to the list to control it.
            ListSounds.Add(soundObject);
        }
    }

    /// <summary>
    /// Plays a sound effect based on its ID (index in the ListSFX).
    /// </summary>
    /// <param name="id">The ID of the sound effect to play.</param>
public void PlaySound(int id)
{
    // Buscar el AudioClip correspondiente al id
    AudioClip clip = ListSFX[id];
    //Check if the manager have already an audiosource.
    AudioSource soundObject = GetComponent<AudioSource>();
    if(soundObject == null)
    {
        soundObject= gameObject.AddComponent<AudioSource>();
    }
    soundObject.clip = clip;
    soundObject.Play();

}

    /// <summary>
    /// Stops all currently playing sound effects.
    /// </summary>
public void StopSFX()
{
    //Iterate over all the sfx.
    foreach (GameObject sound in ListSounds)
    {
        //stop them
        sound.GetComponent<AudioSource>().Stop();
        
    }
}


}
}
