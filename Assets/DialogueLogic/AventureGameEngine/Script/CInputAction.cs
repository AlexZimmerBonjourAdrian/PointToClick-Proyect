using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CInputAction : ScriptableObject
{
    public string keyWord;

    public abstract void RespondToInput(CGameController controller, string[] separatedInputWords);

}
