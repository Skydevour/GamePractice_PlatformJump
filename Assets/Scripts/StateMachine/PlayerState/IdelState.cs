using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "IdleState")]
public class IdelState : PlayerState
{
    [SerializeField] private float decelerationSpeed;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicalUpdate()
    {
        if (playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(RunState));
        }
        
        if (playerInput.Jump)
        {
            playerStateMachine.ChangeState(typeof(JumpState));
        }
        
        if (!playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(FallState));
        }
    }
    
    public override void PhysicalUpdate()
    {
        // 缓慢减速
        playerCurrentSpeed = Mathf.MoveTowards(playerCurrentSpeed, 0, decelerationSpeed * Time.deltaTime);
        // 这里不能直接用playerInput.AxesX, 因为可能为0，导致速度直接降低为0，不符合缓慢减速的效果
        playerController.SetPlayerVelocityX(playerCurrentSpeed, playerController.transform.localScale.x);
    }}
