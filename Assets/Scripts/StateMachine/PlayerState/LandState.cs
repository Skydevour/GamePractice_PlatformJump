using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "LandState")]
public class LandState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocity(Vector3.zero);
    }

    public override void LogicalUpdate()
    {
        if (playerInput.Jump)
        {
            playerStateMachine.ChangeState(typeof(JumpState));
        }
        
        if (playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(RunState));
        }

        if (isAnimationFinished)
        {
            playerStateMachine.ChangeState(typeof(IdelState));
        }
    }
}

