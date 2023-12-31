using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "FallState")]
public class FallState : PlayerState
{
    [SerializeField] private AnimationCurve playerSpeedCurve;
    [SerializeField] private float fallSpeed;

    public override void LogicalUpdate()
    {
        if (playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(LandState));
        }

        // 多段跳跃
        if (playerInput.Jump)
        {
            if (playerController.CanJump)
            {
                playerStateMachine.ChangeState(typeof(AirJumpState));
                return;
            }

            playerInput.SetHasJumpBuffer();
        }
    }

    public override void PhysicalUpdate()
    {
        playerController.SetPlayerVelocityX(fallSpeed, playerInput.AxesX);

        // 根据动画播放时间，设置下落速度
        playerController.SetPlayerVelocityY(playerSpeedCurve.Evaluate(stateDuration));
    }
}
