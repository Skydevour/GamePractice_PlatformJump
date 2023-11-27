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
     
     private Dictionary<string, AudioClip[]> playerAudioClip = new Dictionary<string, AudioClip[]>();
     
     public PlayerState[] playerStates;
     
     private void OnEnable()
     {
          EventCenter.StartListenToEvent<PlayerDefeatEvent>(OnPlayerDefeatEvent);
     }

     private void OnDisable()
     {
          EventCenter.StopListenToEvent<PlayerDefeatEvent>(OnPlayerDefeatEvent);
     }
     
     private void Awake()
     {
          playerAnimator = GetComponentInChildren<Animator>();
          playerInput = GetComponent<PlayerInput>();
          playerController = GetComponent<PlayerController>();
          stateTable = new Dictionary<System.Type, IState>(playerStates.Length);
          foreach (var playerState in playerStates)
          {
               if (Directory.Exists("Assets/Resources/PlayerMusic/" + playerState.name))
               {
                    string[] files = Directory.GetFiles("Assets/Resources/PlayerMusic/" + playerState.name, "*.wav");
                    AudioClip[] audioClips = new AudioClip[files.Length];
                    int index = 0;
                    foreach (var audioClip in files)
                    {
                         string filePath = "PlayerMusic/" + playerState.name + "/" + Path.GetFileName(audioClip).Split('.')[0];
                         audioClips[index] = Resources.Load<AudioClip>(filePath);
                         index++;
                    }
                    playerAudioClip.Add(playerState.name, audioClips);
               }
               playerState.InitComponent(playerAnimator, this, playerInput, playerController, playerAudioClip);
               stateTable.Add(playerState.GetType(), playerState);
          }
     }

     private void Start()
     {
          playerInput.DisableGameplayInputs();
          SwitchOnState(stateTable[typeof(IdelState)]);
     }
     
     private void OnPlayerDefeatEvent(PlayerDefeatEvent evt)
     {
          SwitchOnState(stateTable[typeof(DieState)]);
     }
}
