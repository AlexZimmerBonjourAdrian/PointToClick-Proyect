using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewObject",menuName ="Loop:DetectiveAdventure/Item")]
public class CItemData : ScriptableObject
{
    // Start is called before the first frame update

    private new string name;

    [TextArea(2, 2)]
    public string description;
    public int Id;
    public Texture2D imageItem;
    public bool Optional;
    public bool isActive;


}
