using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraManager : MonoBehaviour
{
    // Start is called before the first frame update

     //Singleton
     public static CCameraManager Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("CCameraManager");
                return obj.AddComponent<CCameraManager>();
            }
            return _inst;

        }
    }
    private static CCameraManager _inst;

    public Camera CameraSegurityRoom;
    public Camera camera_1A;
    public Camera camera_1B;
    public Camera camera_1C;
    public Camera camera_2A;
    public Camera camera_2B;
    public Camera camera_3;
    public Camera camera_3A;
    public Camera camera_3B;
    public Camera camera_4A;
    public Camera camera_4B;
    public Camera camera_5B;
    public Camera camera_6;
    public Camera camera_7;

public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }
 
}
