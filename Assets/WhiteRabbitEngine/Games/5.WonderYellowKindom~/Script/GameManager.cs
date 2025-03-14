using System;
using System.Collections.Generic;
using UnityEngine;
using WhiteRabbit.Core;

namespace WhiteRabbit.WonderYellowKindom
{
//     public class GameManager : CGameManager
//     {
//         private void Start()
// 		{
			
// 		}

//     }

// 	public interface IState
// 	{
// 		void Enter();
// 		void Execute();
// 		void Exit();
// 	}

// 	private class StateMenu : IState
// 	{
// 		private StateMachine stateMachine;

// 		public void Enter()
// 		{
// 			Debug.Log("Enter Menu");
// 		}

// 		public void Execute()
// 		{
// 			Debug.Log("Execute Menu");
// 			if (Input.GetKeyDown(KeyCode.Space))
//         {
//         	stateMachine.ChangeState(stateMachine.StateGameplay);


//         }
// 		}

// 		public void Exit()
// 		{
// 			Debug.Log("Exit Menu");
// 		}
// 	}

// 	private class StateGameplay : IState
// 	{
// 		public void Enter()
// 		{
// 			Debug.Log("Enter Gameplay");
// 		}

// 		public void Execute()
// 		{
// 		if (Input.GetKeyDown(KeyCode.Space))
//         {
//         	stateMachine.ChangeState(stateMachine.StateEnd);


//         }
// 		}

// 		public void Exit()
// 		{
// 			Debug.Log("Exit Gameplay");
// 		}
// 	}

// 	private class StateEnd : IState
// 	{
// 		public void Enter()
// 		{
// 			Debug.Log("Enter End");
// 		}

// 		public void Execute()
// 		{
// 			Debug.Log("Execute End");
// 			if (Input.GetKeyDown(KeyCode.Space))
//         {
//         	stateMachine.ChangeState(stateMachine.StateMenu);

//         }
// 		}

// 		public void Exit()
// 		{
// 			Debug.Log("Exit End");
// 		}
// 	}


// 	public class StateMachine
// {
//     public IState currentState;
//     public StateMenu stateMenu;
//     public StateGameplay stateGameplay;
// 	public StateEnd stateEnd;
    
// 	public StateMachine()
//     {
//         stateMenu = new StateMenu(this);
//         stateGameplay = new StateGameplay(this);
// 		stateEnd = new StateEnd(this);
//     }
//     public void Initialize(IState startingState)
//     {
//         currentState = startingState;
//         currentState.Enter();
//     }

//     public void ChangeState(IState newState)
//     {
//         currentState.Exit();
//         currentState = newState;
//         currentState.Enter();
//     }

//     public void Update()
//     {
//         if (currentState != null)
//         {
//             currentState.Update();
//         }
//     }
// }

// public class StateMachineController : MonoBehaviour
// {
//     private StateMachine stateMachine;

//     private void Start()
//     {
//         stateMachine = new StateMachine();
//         stateMachine.Initialize(stateMachine.stateA); // Start in State A
//     }

//     private void Update()
//     {
//         stateMachine.Update();
//     }
// }
}
