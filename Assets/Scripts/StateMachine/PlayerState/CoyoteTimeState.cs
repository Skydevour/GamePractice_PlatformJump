using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "CoyoteTimeState")]
public class CoyoteTimeState : PlayerState
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float coyoteTime;

    public override void Enter()
    {
        base.Enter();
        playerController.SetUseGravity(false);
    }
    
    public override void LogicalUpdate()
    {
        if (!playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(IdelState));
        }

        if (playerInput.Jump)
        {
            playerStateMachine.ChangeState(typeof(JumpState));
        }
        
        if (!playerController.IsGrounded && stateDuration >= coyoteTime)
        {
            playerStateMachine.ChangeState(typeof(FallState));
        }
    }

    public override void PhysicalUpdate()
    {
        // 缓慢加速
        playerCurrentSpeed = Mathf.MoveTowards(playerCurrentSpeed, maxSpeed, accelerationSpeed * Time.deltaTime);
        // run状态，axesX不可能为0
        playerController.SetPlayerVelocityX(playerCurrentSpeed, playerInput.AxesX);
    }
    
    public override void Exit()
    {
        base.Exit();
        playerController.SetUseGravity(true);
    }
}
