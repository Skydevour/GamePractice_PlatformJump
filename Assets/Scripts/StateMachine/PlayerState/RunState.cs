using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "RunState")]
public class RunState : PlayerState
{
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float accelerationSpeed = 15.0f;

    public override void Enter()
    {
        playerAnimator.Play("Run");
        playerCurrentSpeed = playerController.PlayerMoveSpeed;
    }

    public override void LogicalUpdate()
    {
        if (!playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(IdelState));
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
