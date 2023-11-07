using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "FallState")]
public class FallState : PlayerState
{
    [SerializeField] private AnimationCurve playerSpeedCurve;
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicalUpdate()
    {
        if (playerController.IsGrounded)
        {
            playerStateMachine.ChangeState(typeof(LandState));
        }
    }

    public override void PhysicalUpdate()
    {
        // 根据动画播放时间，设置下落速度
        playerController.SetPlayerVelocityY(playerSpeedCurve.Evaluate(stateDuration));
    }
}
