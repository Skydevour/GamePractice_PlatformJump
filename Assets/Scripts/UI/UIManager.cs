using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas victoryScreen;
    [SerializeField] private Canvas defeatScreen;
    [SerializeField] private Canvas clearanceTimer;
    [SerializeField] private AudioClip[] defeatClip;
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<IsGameVictoryEvent>(OnIsGameVictoryEvent);
        EventCenter.StartListenToEvent<StartGameEvent>(OnStartGameEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<IsGameVictoryEvent>(OnIsGameVictoryEvent);
        EventCenter.StopListenToEvent<StartGameEvent>(OnStartGameEvent);
    }
    
    private void OnIsGameVictoryEvent(IsGameVictoryEvent evt)
    {
        if (evt.IsVictory)
        {
            EventCenter.TriggerEvent(new GetCleananceTimeEvent());
            victoryScreen.GetComponent<Canvas>().enabled = true;
            victoryScreen.GetComponent<Animator>().enabled = true;
        }
        else
        {
            defeatScreen.GetComponent<Canvas>().enabled = true;
            defeatScreen.GetComponent<Animator>().enabled = true;

            AudioClip audioClip = defeatClip[Random.Range(0, defeatClip.Length)];
            SoundEffectPlayer.AudioSource.PlayOneShot(audioClip);
        }
        clearanceTimer.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void OnStartGameEvent(StartGameEvent evt)
    {
        clearanceTimer.GetComponent<Canvas>().enabled = evt.IsGameStart;
    }
}
