using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManager 
{
    private List<GameObject> mArray;

    public CManager()
    {
        mArray = new List<GameObject>();
    }

    public void add(GameObject aGameObject)
    {
        mArray.Add(aGameObject);
    }
    // Start is called before the first frame update
  virtual  public void Update()
    {
        for(int i = mArray.Count - 1; i >=0; i --)
        {
            if (mArray[i] == null)
               removeObjectWithIndex(i);
           
        }
    }
    
    private void removeObjectWithIndex(int aIndex)
    {
        if(aIndex < mArray.Count)
        {   
            mArray[aIndex] = null;
            mArray.RemoveAt(aIndex);
        }
    }
     virtual public void destroy()
    {
        for(int i = mArray.Count -1; i>=0; i--)
        {
            removeObjectWithIndex(i);  
        }
        mArray = null;
    }
 
}
