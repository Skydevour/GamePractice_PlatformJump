using System;
using UnityEngine;
using DG.Tweening;

public class GateOpenOrClose : MonoBehaviour
{
    [SerializeField] private GameObject trapGate;
    [SerializeField] private GameObject passageGate;
    [SerializeField] private GameObject startGate;
    
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<GateOpenOrCloseEvent>(OnGateOpenOrCloseEvent);
        EventCenter.StartListenToEvent<StartGameEvent>(OnStartGameEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<GateOpenOrCloseEvent>(OnGateOpenOrCloseEvent);
        EventCenter.StopListenToEvent<StartGameEvent>(OnStartGameEvent);
    }

    private void OnGateOpenOrCloseEvent(GateOpenOrCloseEvent evt)
    {
        trapGate.SetActive(!evt.IsOpenGate);
        passageGate.SetActive(!evt.IsOpenGate);
    }

    private void OnStartGameEvent(StartGameEvent evt)
    {
        startGate.SetActive(!evt.IsGameStart);
    }
    
}
