using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Bson;
using UnityEngine;

public class CLevel1 : CLevelGeneric
{
    //TODO: Integrar el puzzle con los elementos del nivel
    //TODO-Alpha: Separar los puzzles en clases para cada puzzle e heredar.
    [SerializeField]
    private List<int> SequencePuzzle;
    [SerializeField]
    private List<int> CorrectSequence;
    [SerializeField]
    private EPuzzleType.Puzzle TypePuzzle;
   
    private bool isSuccesfull;
    private bool isComplete;
    public static CLevel1 Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("Level1");
                return obj.AddComponent<CLevel1>();
            }

            return _inst;
        }
    }

    private static CLevel1 _inst;


    public void Awake()
    {
        TypePuzzle = EPuzzleType.Puzzle.Sequence;
         List<int> SequencePuzzle = new List<int>();
        _inst = this;
    }

    //public 

    public void CheckSuccesfull(int code)
    {
       
        if (TypePuzzle == EPuzzleType.Puzzle.Sequence)
        {
            if (isSuccesfull != true)
            {
                SequencePuzzle.Add(code);
            }
          

            if (SequencePuzzle.Count >= CorrectSequence.Count)
            {
                foreach (var i in SequencePuzzle)
                {
                    if (SequencePuzzle[i] != CorrectSequence[i])
                    {
                       
                        isSuccesfull = false;
                        ResetSequence(); break;
                    }
                    isSuccesfull = true;
                    SuccesfullSequence();
                    break;

                }
                
            }
        }
    }

  private void ResetSequence()
  {
        if(SequencePuzzle.Count > 0)
        { 
            var ObjectsPuzzles = FindObjectsOfType<CInteractiveObject>();
            var LightPuzzle = FindObjectOfType<CLightSwitch>();
            foreach (var OBJ in ObjectsPuzzles)
            {
                
                OBJ.Deselected();
                LightPuzzle.ResetLight();
                SequencePuzzle.Clear();
            }
        }
    }

   private void SuccesfullSequence()
   {
        if (isSuccesfull == true)
        {
            var ObjectsPuzzles = FindObjectsOfType<CInteractiveObject>();
            foreach (var OBJ in ObjectsPuzzles)
            {
                OBJ.Complete();
                CompleteRoom();
            }
        }
   }

    protected override void CompleteRoom()
    {
        var ObjectsPuzzles = FindObjectOfType<CLightSwitch>();
        if (isSuccesfull == true)
        {
            ObjectsPuzzles.CompleteLight();
            isComplete = true;
            Debug.Log("El nivel esta completado");
            CLevelController.Inst.checkCompleteLevel();
        }
    }

    public override bool GetIsComplete()
    {
        return this.isComplete;
    }

    public static explicit operator CLevel1(bool v)
    {
        throw new NotImplementedException();
    }

    //TODO: Pasos Extras en los puzzle.
    //public void ExtraSteps()
}

