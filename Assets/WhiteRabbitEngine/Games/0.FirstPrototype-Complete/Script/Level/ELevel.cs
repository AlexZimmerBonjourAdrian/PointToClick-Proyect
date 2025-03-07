using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WhiteRabbit.FirstPrototype
{
public static class ELevel
{
    // Start is called before the first frame update
    public enum LevelNumber
    {
        None,
        Level1,
        Level2,
        Level3,
    }

    public enum LevelType
    {
        None,
        Simple,
        Exploration,
        Teller,
    }
}
}

