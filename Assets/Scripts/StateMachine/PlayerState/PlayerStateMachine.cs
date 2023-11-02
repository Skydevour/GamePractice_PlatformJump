using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
     [SerializeField] private Animator playerAnimator;
     [SerializeField] private PlayerInput playerInput;
     [SerializeField] private PlayerController playerController;
     
     public PlayerState[] playerStates;
     private void Awake()
     {
          playerAnimator = GetComponentInChildren<Animator>();
          playerInput = GetComponent<PlayerInput>();
          playerController = GetComponent<PlayerController>();
          stateTable = new Dictionary<System.Type, IState>(playerStates.Length);
          foreach (var playerState in playerStates)
          {
               playerState.InitComponent(playerAnimator, this, playerInput, playerController);
               stateTable.Add(playerState.GetType(), playerState);
          }
     }

     private void Start()
     {
          playerInput.EnableGameplayInputs();
          SwitchOnState(stateTable[typeof(IdelState)]);
     }
}
