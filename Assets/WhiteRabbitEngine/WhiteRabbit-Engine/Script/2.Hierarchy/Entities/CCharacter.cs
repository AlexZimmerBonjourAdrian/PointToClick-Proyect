using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using WhiteRabbit.Core;

namespace WhiteRabbit.Hierarchy
{
public class CCharacter : MonoBehaviour, Iinteract
{
    private Animator anim;

   
    public  int id;
    
    

    [SerializeField]
    private string CharacterName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        
    }

    public void OnStopInteract()
    {
        throw new System.NotImplementedException();
    }
    // Update is called once per frame
    public void Oninteract()
    {   
        CManagerSFX.Inst.PlaySound(0);
       // Debug.Log("Hola");
      //  ChangeAnimation();
      
      if(!CManagerDialogue.Inst.GetIsDialogueRunning())
      {

          CManagerDialogue.Inst.SetListYarn(id);
          CManagerDialogue.Inst.StartDialogueRunner(0);
      }
    }

    public int GetIDCharacter()
    {
        return id;
    }

    // private void ChangeAnimation()
    // {
    //     isActiveAnim = !isActiveAnim;
    //     anim.SetBool("IsActive", isActiveAnim);
    // }


}
}