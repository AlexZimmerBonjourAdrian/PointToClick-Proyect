using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameObject : MonoBehaviour
{
    //TODO: 
    // Start is called before the first frame update

    private bool mIsDead = false;
    void Start()
    {
        
    }
    public CGameObject()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    virtual public void destroy()
    {

    }
    public void setDead(bool aIsDead)
    {
        
    }
    public bool isDead()
    {
        return mIsDead;
    }
}
