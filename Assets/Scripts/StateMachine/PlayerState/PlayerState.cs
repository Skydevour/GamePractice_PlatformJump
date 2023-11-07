using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] private string stateName;
    // 动画切换的交叉时间
    [SerializeField, Range(0, 1f)] private float transitionDurtion;
    private int stateHashId;
    private float stateStartTime;
    
    protected Animator playerAnimator;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerInput playerInput;
    protected PlayerController playerController;
    protected float playerCurrentSpeed;
    protected bool isAnimationFinished => stateDuration >= playerAnimator.GetCurrentAnimatorStateInfo(0).length;
    protected float stateDuration => Time.time - stateStartTime;
    

    private void OnEnable()
    {
        stateHashId = Animator.StringToHash(stateName);
    }

    public void InitComponent(Animator playerAnimator, PlayerStateMachine playerStateMachine, PlayerInput playerInput, PlayerController playerController)
    {
        this.playerAnimator = playerAnimator;
        this.playerStateMachine = playerStateMachine;
        this.playerInput = playerInput;
        this.playerController = playerController;
    }
    public virtual void Enter()
    {
        playerAnimator.CrossFade(stateHashId, transitionDurtion);
        stateStartTime = Time.time;
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
