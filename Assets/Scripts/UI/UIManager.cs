using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas victoryScreen;
    [SerializeField] private Canvas defeatScreen;

    [SerializeField] private AudioClip[] defeatClip;
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<IsGameVictoryEvent>(OnIsGameVictoryEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<IsGameVictoryEvent>(OnIsGameVictoryEvent);
    }
    
    private void OnIsGameVictoryEvent(IsGameVictoryEvent evt)
    {
        if (evt.IsVictory)
        {
            victoryScreen.GetComponent<Canvas>().enabled = true;
            victoryScreen.GetComponent<Animator>().enabled = true;
        }
        else
        {
            defeatScreen.GetComponent<Canvas>().enabled = true;
            defeatScreen.GetComponent<Animator>().enabled = true;

            AudioClip audioClip = defeatClip[Random.Range(0, defeatClip.Length)];
            SoundEffectPlayer.AudioSource.PlayOneShot(audioClip);
            
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
