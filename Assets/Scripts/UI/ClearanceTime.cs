using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearanceTime : MonoBehaviour
{
    [SerializeField] private Text clearanceTime;
    [SerializeField] private float clearTime;
    [SerializeField] private bool isGameStart;

    private void OnEnable()
    {
        EventCenter.StartListenToEvent<StartGameEvent>(OnStartGameEvent);
        EventCenter.StartListenToEvent<PlayerDieEvent>(OnPlayerDieEvent);
        EventCenter.StartListenToEvent<PlayerVictoryEvent>(OnPlayerVictoryEvent);

    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<StartGameEvent>(OnStartGameEvent);
        EventCenter.StopListenToEvent<PlayerDieEvent>(OnPlayerDieEvent);
        EventCenter.StopListenToEvent<PlayerVictoryEvent>(OnPlayerVictoryEvent);

    }

    private void Update()
    {
        if (!isGameStart)
        {
            return;
        }

        clearTime += Time.deltaTime;
        clearanceTime.text = TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    private void OnStartGameEvent(StartGameEvent evt)
    {
        isGameStart = evt.IsGameStart;
    }

    private void OnPlayerDieEvent(PlayerDieEvent evt)
    {
        isGameStart = false;
    }

    private void OnPlayerVictoryEvent(PlayerVictoryEvent evt)
    {
        isGameStart = false;
        EventCenter.TriggerEvent(new SaveClearanceTimeEvent(clearanceTime.text));
    }
}
