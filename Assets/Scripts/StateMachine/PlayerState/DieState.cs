using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Die", fileName = "DieState")]
public class DieState : PlayerState
{
    [SerializeField] private ParticleSystem playerDefeatVFX;
    [SerializeField] private AudioClip[] playerDefeatClips;
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicalUpdate()
    {
        if (isAnimationFinished)
        {
            playerStateMachine.ChangeState(typeof(FloatState));
        }
    }
}