using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[SerializeField]
public class CCharacter : MonoBehaviour, Iinteract
{
    private Animator anim;
    private bool isActiveAnim = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void Oninteract()
    {
        Debug.Log("Hola");
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        isActiveAnim = !isActiveAnim;
        anim.SetBool("IsActive", isActiveAnim);
    }


}
