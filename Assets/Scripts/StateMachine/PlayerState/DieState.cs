using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Die", fileName = "DieState")]
public class DieState : PlayerState
{
    [SerializeField] private ParticleSystem defeatVFX;
    
    public override void Enter()
    {
        base.Enter();
        GameObject defeatParticle = PoolManager.Instance.GetAObjFromPool(defeatVFX.gameObject);
        defeatParticle.AddComponent<ParticleSystemManager>();
        defeatParticle.transform.position = playerController.transform.position;
        defeatParticle.transform.rotation = Quaternion.identity;
    }

    public override void LogicalUpdate()
    {
        if (isAnimationFinished)
        {
            playerStateMachine.ChangeState(typeof(FloatState));
        }
    }
}