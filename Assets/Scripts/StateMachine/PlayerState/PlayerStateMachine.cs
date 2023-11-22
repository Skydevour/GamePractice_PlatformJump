using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
     [SerializeField] private Animator playerAnimator;
     [SerializeField] private PlayerInput playerInput;
     [SerializeField] private PlayerController playerController;
     
     private Dictionary<string, AudioClip> playerAudioClip = new Dictionary<string, AudioClip>();
     
     public PlayerState[] playerStates;
     private void Awake()
     {
          playerAnimator = GetComponentInChildren<Animator>();
          playerInput = GetComponent<PlayerInput>();
          playerController = GetComponent<PlayerController>();
          stateTable = new Dictionary<System.Type, IState>(playerStates.Length);
          foreach (var playerState in playerStates)
          {
               if (File.Exists("Assets/Resources/PlayerMusic/" + playerState.name + ".wav"))
               {
                    playerAudioClip.Add(playerState.name, Resources.Load<AudioClip>("PlayerMusic/" + playerState.name));
               }
               playerState.InitComponent(playerAnimator, this, playerInput, playerController, playerAudioClip);
               stateTable.Add(playerState.GetType(), playerState);
          }
     }

     private void Start()
     {
          playerInput.EnableGameplayInputs();
          SwitchOnState(stateTable[typeof(IdelState)]);
     }
}
