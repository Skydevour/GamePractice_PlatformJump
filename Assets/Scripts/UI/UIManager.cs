using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas victoryScreen;
    [SerializeField] private Canvas readyScreen;
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<ShowVictoryEvent>(OnShowVictoryEvent);

    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<ShowVictoryEvent>(OnShowVictoryEvent);

    }
    
    private void OnShowVictoryEvent(ShowVictoryEvent evt)
    {
        victoryScreen.GetComponent<Canvas>().enabled = evt.IsVictory;
        victoryScreen.GetComponent<Animator>().enabled = evt.IsVictory;
    }
}
