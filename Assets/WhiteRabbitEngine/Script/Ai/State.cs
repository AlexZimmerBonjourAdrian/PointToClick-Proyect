using UnityEngine;

public class State : MonoBehaviour
{
 
    public virtual void Enter()
    {
        Debug.Log("Enter");
    }

    public virtual void Execute()
    {
        Debug.Log("Execute");
    }

    public virtual void Exit()
    {
        Debug.Log("Exit");
    }
}


// --- State Interface (or Abstract Class) ---
public abstract class CharacterState : MonoBehaviour
{
    protected CharacterStateManager context; // Reference to the state manager

    public void SetContext(CharacterStateManager context)
    {
        this.context = context;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}

// --- Concrete State: Idle ---
public class IdleState : CharacterState
{
    public override void EnterState()
    {
        Debug.Log("Character entered Idle State");
        // Play idle animation, stop movement, etc.
    }

    public override void UpdateState()
    {
        // Check for state transitions (e.g., if player moves, transition to moving state)
        if (Input.GetKeyDown(KeyCode.Space)) //example for change to other state.
        {
            context.SwitchState(context.Moving);
        }
    }

    public override void ExitState()
    {
        Debug.Log("Character exited Idle State");
        // Stop idle animation, clean up, etc.
    }
}

// --- Concrete State: Moving ---
public class MovingState : CharacterState
{
    public override void EnterState()
    {
        Debug.Log("Character entered Moving State");
        // Play moving animation, start movement, etc.
    }

    public override void UpdateState()
    {
        // Handle movement logic
        Debug.Log("Character is moving");

        if (Input.GetKeyDown(KeyCode.M)) //example for change to other state.
        {
            context.SwitchState(context.Idle);
        }

    }

    public override void ExitState()
    {
        Debug.Log("Character exited Moving State");
        // Stop moving animation, clean up, etc.
    }
}

// --- State Manager ---
public class CharacterStateManager : MonoBehaviour
{
    public CharacterState currentState;
    public IdleState Idle = new IdleState();
    public MovingState Moving = new MovingState();

    private void Start()
    {
        //Set the context in the different states.
        Idle.SetContext(this);
        Moving.SetContext(this);

        // Start in the Idle state
        SwitchState(Idle);
    }

    private void Update()
    {
        // Execute the current state's logic
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void SwitchState(CharacterState newState)
    {
        // Exit the current state
        if (currentState != null)
        {
            currentState.ExitState();
        }

        // Change to the new state
        currentState = newState;

        // Enter the new state
        currentState.EnterState();
    }
}
