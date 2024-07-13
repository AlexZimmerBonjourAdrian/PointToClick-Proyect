using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTextInput : MonoBehaviour
{
    public InputField inputField;
    CGameController controller;

   void Awake()
    {
        //Carga la clase controlador de game a el Text
        controller = GetComponent<CGameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }
    void AcceptStringInput(string useInput)
    {
        useInput = useInput.ToLower();
        controller.LogStringWithReturn(useInput);

        char[] delimiterCharacters = { ' ' };
        string[] separatedInputWorlds = useInput.Split(delimiterCharacters);

        

        for(int i = 0; i < controller.inputActions.Length; i++)
        {
            CInputAction inputAction = controller.inputActions[i];
            if(inputAction.keyWord == separatedInputWorlds[0])
            {
                inputAction.RespondToInput(controller, separatedInputWorlds);
            }
        }
        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
        

}
