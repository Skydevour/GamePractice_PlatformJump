using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private float lastExistTime;
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
        Destroy(this.gameObject, lastExistTime);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            EventCenter.TriggerEvent(new PlayerDieEvent());
        }
    }
}
