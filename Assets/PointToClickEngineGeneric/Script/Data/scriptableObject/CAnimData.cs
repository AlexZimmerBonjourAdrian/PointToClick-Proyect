using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimatioNData", menuName = "PointToClick/Animation")]
[Serializable]
public class CAnimData : MonoBehaviour
{
    private string Name;
    public string description;
    public new int Id;
    public List<List<Sprite>> AnimMachine;
}
