using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyGame : MonoBehaviour
{
    [SerializeField] private AudioClip startGame;
    private void NoticeStartGateOpen()
    {
        EventCenter.TriggerEvent(new StartGateOpenEvent(true));
    }

    private void DisplayStartGameAudio()
    {
        SoundEffectPlayer.AudioSource.PlayOneShot(startGame);
    }
}
