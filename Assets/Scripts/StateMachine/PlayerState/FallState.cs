using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "FallState")]
public class FallState : PlayerState
{
    public override void Enter()
    {
        playerAnimator.Play("Fall");
    }

    public override void LogicalUpdate()
    {
        
    }
}
