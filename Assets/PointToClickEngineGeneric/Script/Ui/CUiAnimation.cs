using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 
 [RequireComponent(typeof(Image))]

public class CUiAnimation : MonoBehaviour
{
    public float duration;

    //  [SerializeField] private Sprite[] sprites;
    [SerializeField] public List<List<Sprite>> _lista;
    
      
    [SerializeField] private Image image;
   // [SerializeField] public Sprite[][] SpritesArray ;
    private int index = 0;
    private float timer = 0;

    private void Awake()
    {
       
    }
    void Start()
    {
        image = GetComponent<Image>();
    }
    private void Update()
    {
        /*
        if ((timer += Time.deltaTime) >= (duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }*/
    }
}
