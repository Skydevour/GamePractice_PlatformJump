using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump", fileName = "AirJumpState")]
public class AirJumpState : PlayerState
{
    [SerializeField] private float airJumpForce;
    [SerializeField] private float airJumpSpeed;
    [SerializeField] private ParticleSystem airJumpVFX;
    
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocityY(airJumpForce);
        playerController.CanJump = false;
        GameObject airJumpParticle = PoolManager.Instance.GetAObjFromPool(airJumpVFX.gameObject);
        airJumpParticle.AddComponent<ParticleSystemManager>();
        airJumpParticle.transform.position = playerController.transform.position;
        airJumpParticle.transform.rotation = Quaternion.identity;
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
        playerController.SetPlayerVelocityX(airJumpSpeed, playerInput.AxesX);
    }
}
