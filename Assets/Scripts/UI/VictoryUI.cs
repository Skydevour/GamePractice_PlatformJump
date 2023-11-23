using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
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
        this.GetComponent<Canvas>().enabled = evt.IsVictory;
        this.GetComponent<Animator>().enabled = evt.IsVictory;
    }
}
