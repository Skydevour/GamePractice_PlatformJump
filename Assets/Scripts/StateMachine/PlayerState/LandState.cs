using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "LandState")]
public class LandState : PlayerState
{
    [SerializeField] private float stiffTime;
    [SerializeField] private ParticleSystem landVFX;
    public override void Enter()
    {
        base.Enter();
        playerController.SetPlayerVelocity(Vector3.zero);
        GameObject landParticle = PoolManager.Instance.GetAObjFromPool(landVFX.gameObject);
        landParticle.AddComponent<ParticleSystemManager>();
        landParticle.transform.position = playerController.transform.position;
        landParticle.transform.rotation = Quaternion.identity;
    }

    public override void LogicalUpdate()
    {
        if (playerController.IsVictory)
        {
            playerStateMachine.ChangeState(typeof(VictoryState));
        }
        
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

