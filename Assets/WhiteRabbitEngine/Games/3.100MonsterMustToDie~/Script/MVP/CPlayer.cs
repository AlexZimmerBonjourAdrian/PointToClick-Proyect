using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

namespace WhiteRabbit.MonstersMustToDie
{
public class CPlayer : MonoBehaviour
{
    public float life;
    public bool isDead;

    private TextMeshProUGUI Temp;

    
    public void DiscountLife(float lifeSubstract)
    {
        life -= lifeSubstract;
    }
    
}
}
