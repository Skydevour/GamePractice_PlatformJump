using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator playerAnimator;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerInput playerInput;
    protected PlayerController playerController;
    protected float playerCurrentSpeed;

    public void InitComponent(Animator playerAnimator, PlayerStateMachine playerStateMachine, PlayerInput playerInput, PlayerController playerController)
    {
        this.playerAnimator = playerAnimator;
        this.playerStateMachine = playerStateMachine;
        this.playerInput = playerInput;
        this.playerController = playerController;
    }
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicalUpdate()
    {
    }

    public virtual void PhysicalUpdate()
    {
    }
}
