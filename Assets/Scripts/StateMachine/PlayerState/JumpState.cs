using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "JumpState")]
public class JumpState : PlayerState
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private ParticleSystem jumpVFX;
    
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocityY(jumpForce);
        playerController.CanJump = false;
        GameObject jumpParticle = PoolManager.Instance.GetAObjFromPool(jumpVFX.gameObject);
        jumpParticle.AddComponent<ParticleSystemManager>();
        jumpParticle.transform.position = playerController.transform.position;
        jumpParticle.transform.rotation = Quaternion.identity;
    }

    public override void LogicalUpdate()
    {
        // 小跳，即松开按键直接切换状态
        if (playerInput.StopJump || playerController.IsFalling)
        {
            playerStateMachine.ChangeState(typeof(FallState));
        }
    }
    
    public override void PhysicalUpdate()
    {
        playerController.SetPlayerVelocityX(jumpSpeed, playerInput.AxesX);
    }
}
