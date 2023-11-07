using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "JumpState")]
public class JumpState : PlayerState
{
    [SerializeField] private float jumpForce;
    
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocityY(jumpForce);
    }

    public override void LogicalUpdate()
    {
        if (playerController.IsFalling)
        {
            playerStateMachine.ChangeState(typeof(FallState));
        }
    }
}
