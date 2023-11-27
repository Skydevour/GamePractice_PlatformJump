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
    private Dictionary<string, AudioClip[]> playerAudioClip;
    
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

    public void InitComponent(Animator playerAnimator, PlayerStateMachine playerStateMachine, PlayerInput playerInput, PlayerController playerController, Dictionary<string, AudioClip[]> playerAudioClip)
    {
        this.playerAnimator = playerAnimator;
        this.playerStateMachine = playerStateMachine;
        this.playerInput = playerInput;
        this.playerController = playerController;
        this.playerAudioClip = playerAudioClip;
    }
    public virtual void Enter()
    {
        playerAnimator.CrossFade(stateHashId, transitionDurtion);
        stateStartTime = Time.time;
        playerCurrentSpeed = playerController.PlayerMoveSpeed;
        if (playerAudioClip.ContainsKey(stateName + "State"))
        {
            int index = UnityEngine.Random.Range(0, playerAudioClip[stateName + "State"].Length);
            playerController.PlayerAudioSource.PlayOneShot(playerAudioClip[stateName + "State"][index]);
        }
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
