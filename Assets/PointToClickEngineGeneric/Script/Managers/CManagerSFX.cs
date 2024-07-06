using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CManagerSFX : MonoBehaviour
{
    public static CManagerSFX Inst
    {
        get
        {
            if (_inst == null)
            {
                Debug.Log("Entra?");
                GameObject obj = new GameObject("ManagerSFX");
                return obj.AddComponent<CManagerSFX>();
            }
            Debug.Log("Entra en el return");
            return _inst;

        }
    }
    private static CManagerSFX _inst;


    [SerializeField] public List<AudioClip> ListSFX;

    [SerializeField] public AudioMixer audioMixer;
}
