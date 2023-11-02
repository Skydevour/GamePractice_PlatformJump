using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "IdleState")]
public class IdelState : PlayerState
{
    public override void Enter()
    {
        playerAnimator.Play("Idle");
    }

    public override void LogicalUpdate()
    {
        if (playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(RunState));
        }
    }
}
