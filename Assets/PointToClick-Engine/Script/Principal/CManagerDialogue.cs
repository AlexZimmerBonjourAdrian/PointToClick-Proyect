using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Yarn;
using Yarn.Compiler;
using Yarn.Unity;
using Yarn.Unity.Example;
using UnityEngine.TextCore.Text;


public class CManagerDialogue : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
   
    [SerializeField]
    private  InMemoryVariableStorage varibleStorage;
    public static CManagerDialogue Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("ManagerDialogue");
                return obj.AddComponent<CManagerDialogue>();
            }
            return _inst;

        }
    }
    private static CManagerDialogue _inst;

     public void Awake()
    {
    if(_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;

        dialogueRunner = GameObject.FindAnyObjectByType<DialogueRunner>();
        varibleStorage = GameObject.FindAnyObjectByType<InMemoryVariableStorage>();
    }
   
    


    [SerializeField]
    private List<YarnProject> ListYarnProyect;

    // [SerializeField]
    // public Dictionary<YarnProject, string> DialogsDir = new Dictionary<YarnProject, string>();
    
    [SerializeField]
    private YarnProject ActualYarn;

    public void SetYarnProject(YarnProject Dialogs)
    {
        dialogueRunner.SetProject(Dialogs);
    }
    
    public YarnProject GetYarnProject()
    {
        return dialogueRunner.GetYarnProject();
    }
    public void SetListYarn(int IndexYarn)
    {
        ActualYarn = ListYarnProyect[IndexYarn];
        dialogueRunner.SetProject(ActualYarn);
    }
   public void StartDialogueRunner()
   {
       dialogueRunner.StartDialogue(ActualYarn.NodeNames[0]);
   }

   public bool GetIsDialogueRunning()
   {
       return dialogueRunner.IsDialogueRunning;
   }

    private void GetVariableStorage()
    {
        
    }
}
