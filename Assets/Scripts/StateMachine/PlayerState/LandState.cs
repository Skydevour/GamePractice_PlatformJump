using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "LandState")]
public class LandState : PlayerState
{
    [SerializeField] private float stiffTime;
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocity(Vector3.zero);
    }

    public override void LogicalUpdate()
    {
        if (playerInput.HasJumpBuffer || playerInput.Jump)
        {
            playerStateMachine.ChangeState(typeof(JumpState));
        }
        
        // 落地硬直
        if (stateDuration <= stiffTime)
        {
            return;
        }
        
        if (playerInput.Move)
        {
            playerStateMachine.ChangeState(typeof(RunState));
        }

        // 落地状态播放完毕就切换到idlestate
        if (isAnimationFinished)
        {
            playerStateMachine.ChangeState(typeof(IdelState));
        }
    }
}

