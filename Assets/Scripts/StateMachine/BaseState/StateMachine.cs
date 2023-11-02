using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    protected Dictionary<System.Type, IState> stateTable;
    private void Update()
    {
        currentState.LogicalUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicalUpdate();
    }

    protected void SwitchOnState(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        SwitchOnState(newState);
    }
    
    public void ChangeState(System.Type newStateType)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        SwitchOnState(stateTable[newStateType]);
    }
}
