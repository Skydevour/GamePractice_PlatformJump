using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "RunState")]
public class RunState : PlayerState
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationSpeed;

    public override void Enter()
    {
        base.Enter();
        playerCurrentSpeed = playerController.PlayerMoveSpeed;
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
        
        if (!playerController.IsGrounded)
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
}
