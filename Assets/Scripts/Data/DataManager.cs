using System;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private String clearanceTime;
    
    private void OnEnable()
    {
        EventCenter.StartListenToEvent<SaveClearanceTimeEvent>(OnSaveClearanceTimeEvent);
        EventCenter.StartListenToEvent<GetCleananceTimeEvent>(OnGetCleananceTimeEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<SaveClearanceTimeEvent>(OnSaveClearanceTimeEvent);
        EventCenter.StopListenToEvent<GetCleananceTimeEvent>(OnGetCleananceTimeEvent);

    }

    private void OnGetCleananceTimeEvent(GetCleananceTimeEvent evt)
    {
        EventCenter.TriggerEvent(new GetCleananceTimeCompleteEvent(clearanceTime));
    }

    private void OnSaveClearanceTimeEvent(SaveClearanceTimeEvent evt)
    {
        clearanceTime = evt.ClearanceTime;
    }
}
