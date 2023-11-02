using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "JumpState")]
public class JumpState : PlayerState
{
    public override void Enter()
    {
        playerAnimator.Play("Jump");
    }

    public override void LogicalUpdate()
    {
        
    }
}
