using System;
using UnityEngine;
using DG.Tweening;

public class GateOpenOrClose : MonoBehaviour
{
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<GateOpenOrCloseEvent>(OnGateOpenOrCloseEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<GateOpenOrCloseEvent>(OnGateOpenOrCloseEvent);
    }

    private void OnGateOpenOrCloseEvent(GateOpenOrCloseEvent evt)
    {
        gameObject.SetActive(!evt.IsOpenGate);
    }
    
}
