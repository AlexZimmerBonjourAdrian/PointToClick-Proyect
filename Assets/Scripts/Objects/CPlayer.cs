using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour
{

    public int level;
    public int health;
    public float[] position;
    
    public void SavePlayer()
    {
        CSaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        CPlayerData data = CSaveSystem.LoadPlayer();

        level = data.health;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
    
}
