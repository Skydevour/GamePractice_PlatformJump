using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Victory", fileName = "VictoryState")]
public class VictoryState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
        
        playerInput.DisableGameplayInputs();
        playerController.GameOverSettings();
    }
}