using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas victoryScreen;
    [SerializeField] private Canvas defeatScreen;
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<GameVictoryEvent>(OnGameVictoryEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<GameVictoryEvent>(OnGameVictoryEvent);
    }
    
    private void OnGameVictoryEvent(GameVictoryEvent evt)
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
        }
        
    }
}
