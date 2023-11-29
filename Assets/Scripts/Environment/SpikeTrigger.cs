using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            EventCenter.TriggerEvent(new PlayerDieEvent());
        }
    }
}
