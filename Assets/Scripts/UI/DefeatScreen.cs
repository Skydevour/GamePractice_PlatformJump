using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button quitBtn;

    private void OnEnable()
    {
        retryBtn.onClick.AddListener(ReloadScene);
        quitBtn.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        retryBtn.onClick.RemoveListener(ReloadScene);
        quitBtn.onClick.RemoveListener(QuitGame);
    }

    private void ReloadScene()
    {
        SceneLoader.Instance.ReloadCurrentScene();
    }

    private void QuitGame()
    {
        SceneLoader.Instance.QuitCurrentScene();
    }
}
