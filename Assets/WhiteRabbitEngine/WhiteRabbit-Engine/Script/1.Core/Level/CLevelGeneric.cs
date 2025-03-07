using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// This class is a generic class for all levels in the game.
/// It contains the basic methods that all levels should have.
/// </summary>

 namespace WhiteRabbit.Core
  {

public  class CLevelGeneric : MonoBehaviour
{

    public virtual void SetRoomActive(int roomIndex, bool isActive)
    {
    }

    protected virtual void CompleteRoom()
    {
        //Debug CompleteRoom
    }

    protected virtual void InitRoom()
    {
       //Init Room
    }

    protected virtual void DeathPlayer()
    {
        //Death Player
    }

    protected virtual void AutoLoadPostDeath()
    {
        //Load post death
    }

    public virtual bool GetIsComplete()
    {
        return false;
    }

}
}


