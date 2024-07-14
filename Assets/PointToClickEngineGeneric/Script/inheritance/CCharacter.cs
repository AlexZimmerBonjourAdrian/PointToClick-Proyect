using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
//[SerializeField]
public class CCharacter : MonoBehaviour, Iinteract
{
    private Animator anim;
    private bool isActiveAnim = false;

    [SerializeField]
    private int id;
    

    [SerializeField]
    private string CharacterName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    public void Oninteract()
    {
       // Debug.Log("Hola");
      //  ChangeAnimation();
      CManagerDialogue.Inst.SetListYarn(id);
      CManagerDialogue.Inst.StartDialogueRunner();

    }
    // private void ChangeAnimation()
    // {
    //     isActiveAnim = !isActiveAnim;
    //     anim.SetBool("IsActive", isActiveAnim);
    // }


}
