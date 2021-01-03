using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
//using Subtegral.DialogueSystem

namespace Subtegral.DialogueSystem.Editor
{ 
public class CStoryGraph : EditorWindow
{
        private string _fileName = "New Narrative";

        private CDialogueContainer _dialogueContainer;

        private CStoryGraphView _graphview;
        //private CDialogueContainer _dialogueContainer;

        [MenuItem("Graph/Narrative Graph")]
        public static void CreateGraphviewWindow()
        {
            var window = GetWindow<CStoryGraph>();
            window.titleContent = new GUIContent("Narrative Graph");
        }
        /*
        private void ContractGraphView()
        {
            
        }
        */
        /*
        private void GenerateBlackBoard()
        {
            var blackboard = new Blackboard()
        }
        */

        private void GenerateBlackBoard()
        {
            Debug.Log("Entra");
            var blackboard = new Blackboard(_graphview);
            blackboard.Add(new BlackboardSection { title = "Exposed variable" });
            /*  blackboard.addItemRequested = _blackboard=>
              {
                  _graphview.
              }
              */

            blackboard.SetPosition(new Rect(10, 30, 200, 300));
            _graphview.Add(blackboard);
            _graphview.Blackboard = blackboard;
        }
        /*
        private void OnDisable()
        {
            rootVisualElement.Remove(_graphview);
        }
        */
    }
}
