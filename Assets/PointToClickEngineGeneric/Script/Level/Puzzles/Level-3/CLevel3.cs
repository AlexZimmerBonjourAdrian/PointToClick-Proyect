using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CLevel3 : CLevelGeneric
{

    public static CDoor Door;

    private void Awake()
    {
        Door = FindAnyObjectByType<CDoor>();
    }

    [YarnCommand("EndTerror")]
    public static void EventEndTerror()
    {
       Door.SetRoom(4);
       Door.SetThisLevelIsComplete(true);

    }

    [YarnCommand("NormalEnd")]
    public static void EventEndNormal()
    {
       Door.SetRoom(5);
       Door.SetThisLevelIsComplete(true);

    }


}
