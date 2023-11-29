using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyGame : MonoBehaviour
{
    [SerializeField] private AudioClip startGame;
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindFirstObjectByType<PlayerInput>();
    }

    private void NoticeStartGateOpen()
    {
        EventCenter.TriggerEvent(new StartGateOpenEvent(true));
    }

    private void DisplayStartGameAudio()
    {
        SoundEffectPlayer.AudioSource.PlayOneShot(startGame);
        playerInput.EnableGameplayInputs();
    }
}
