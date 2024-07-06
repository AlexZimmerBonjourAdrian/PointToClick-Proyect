using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CManagerMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public static CManagerMusic Inst
    {
        get
        {
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

    [SerializeField] public List<AudioClip> musicLists;

    [SerializeField] public AudioMixer audioMixer;

    public void PlayMusic()
    {

    }

    public void StopMusic()
    {

    }

    public void PauseMusic()
    {

    }

    public void PlayIn()
    {

    }

    public void PlayOut()
    {

    }

}

