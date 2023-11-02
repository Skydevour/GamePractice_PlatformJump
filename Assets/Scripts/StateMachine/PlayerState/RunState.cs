using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "RunState")]
public class RunState : PlayerState
{
    [SerializeField] private float runSpeed = 5.0f;
    public override void Enter()
    {
        playerAnimator.Play("Run");
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
        playerController.SetPlayerVelocityX(runSpeed, playerInput.AxesX);
    }
}
