using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "JumpState")]
public class JumpState : PlayerState
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpSpeed;
    
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocityY(jumpForce);
    }

    public override void LogicalUpdate()
    {
        // 小跳，即松开按键直接切换状态
        if (playerInput.StopJump || playerController.IsFalling)
        {
            playerStateMachine.ChangeState(typeof(FallState));
        }
    }
    
    public override void PhysicalUpdate()
    {
        playerController.SetPlayerVelocityX(jumpSpeed, playerInput.AxesX);
    }
}
