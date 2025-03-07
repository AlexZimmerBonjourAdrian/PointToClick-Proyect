using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// This class is a singleton that manages the music in the game.
/// It allows other classes to play, stop, pause, fade in and fade out the music.
/// It also allows to play music in background.
/// </summary>

 namespace WhiteRabbit.Core
  {
public class CManagerMusic : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Singleton instance of the CManagerMusic.
    /// Provides a global access point to the music management functionality.
    /// </summary>
    public static CManagerMusic Inst
    {
        get
        {
            // If the instance doesn't exist, create a new GameObject and add the CManagerMusic component.
            if (_inst == null)
            {
                Debug.Log("Entra?");
                GameObject obj = new GameObject("Music");
                return obj.AddComponent<CManagerMusic>();
            }
            Debug.Log("Entra en el return");
            return _inst;

        }
    }
    private static CManagerMusic _inst;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// It ensures that only one instance of CManagerMusic exists (Singleton pattern).
    /// </summary>
  public void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one.
        if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(this.gameObject); // Removed. It is not necessary to avoid destroy this object when a new scene load.
        _inst = this;
    }
    /// <summary>
    /// List of available music clips.
    /// </summary>
    [SerializeField] public List<AudioClip> musicLists;

    /// <summary>
    /// AudioMixer to manage music volume and effects.
    /// </summary>
    [SerializeField] public AudioMixer audioMixer;

    /// <summary>
    /// Indicates whether to automatically start playing background music on Start.
    /// </summary>
      [SerializeField] public bool IsAutoMusic= true;
    
      /// <summary>
      /// Starts playing background music if IsAutoMusic is true.
      /// </summary>
   public void Start()
   {
        if(IsAutoMusic == true)
        {
            PlayMusicBackground(0); // Plays the first music in the list.
        }

   }

   /// <summary>
    /// Plays the first music clip in the music list.
    /// </summary>
    public void PlayMusic()
    {
        if (musicLists.Count == 0) return; // No music to play.

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = musicLists[0];
        audioSource.Play();
    }

    /// <summary>
    /// Stops the currently playing music.
    /// </summary>
  public void StopMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource!= null)
        {
            audioSource.Stop();
        }
    }

    /// <summary>
    /// Pauses the currently playing music.
    /// </summary>
  public void PauseMusic()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource!= null)
        {
            audioSource.Pause();
        }
    }

    /// <summary>
    /// Plays a specific music clip from the list by its ID.
    /// </summary>
    /// <param name="id">The index of the music clip in the musicLists.</param>
    public void PlayMusicBackground(int id)
    {
        // Buscar el AudioClip correspondiente al id
        if (id < 0 || id >= musicLists.Count)
        {
            Debug.LogError("Invalid music ID: " + id);
            return;
        }
        AudioClip clip = musicLists[id];
        AudioSource soundObject = GetComponent<AudioSource>();
        if(soundObject == null)
        {
           soundObject= gameObject.AddComponent<AudioSource>();
        }
        soundObject.clip = clip;
        soundObject.Play();

    }

   /// <summary>
    /// Fades in the music over a specified duration.
    /// </summary>
    /// <param name="duration">The duration of the fade-in in seconds (default: 1 second).</param>
   public void FadeIn(float duration = 1f)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource!= null)
        {
            audioSource.volume = 0f;
            StartCoroutine(FadeInCoroutine(duration));
        }
    }

    /// <summary>
    /// Coroutine for fading in the music.
    /// </summary>
    /// <param name="duration">The duration of the fade-in in seconds.</param>
    /// <returns></returns>
    private IEnumerator FadeInCoroutine(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float volume = Mathf.Lerp(0f, 1f, timer / duration);
            GetComponent<AudioSource>().volume = volume;
            yield return null;
        }
    }
    /// <summary>
    /// Fades out the music over a specified duration.
    /// </summary>
    /// <param name="duration">The duration of the fade-out in seconds (default: 1 second).</param>
    public void FadeOut(float duration = 1f)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource!= null)
        {
            audioSource.volume = 1f;
            StartCoroutine(FadeOutCoroutine(duration));
        }
    }

    /// <summary>
    /// Coroutine for fading out the music.
    /// </summary>
    /// <param name="duration">The duration of the fade-out in seconds.</param>
    /// <returns></returns>
    private IEnumerator FadeOutCoroutine(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float volume = Mathf.Lerp(1f, 0f, timer / duration);
            GetComponent<AudioSource>().volume = volume;
            yield return null;
        }
        GetComponent<AudioSource>().Stop();
    }

}
}
