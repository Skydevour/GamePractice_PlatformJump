using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Button nextBtn;
    [SerializeField] private Text clearanceTimer;

    private void OnEnable()
    {
        nextBtn.onClick.AddListener(ChangeNextScene);
        
        EventCenter.StartListenToEvent<GetCleananceTimeCompleteEvent>(OnGetCleananceTimeCompleteEvent);
    }

    private void OnDisable()
    {
        nextBtn.onClick.RemoveListener(ChangeNextScene);
        EventCenter.StopListenToEvent<GetCleananceTimeCompleteEvent>(OnGetCleananceTimeCompleteEvent);
    }

    private void OnGetCleananceTimeCompleteEvent(GetCleananceTimeCompleteEvent evt)
    {
        clearanceTimer.text = evt.ClearanceTime;
    }

    private void ChangeNextScene()
    {
        SceneLoader.Instance.ChangeToNextScene();
    }
}
