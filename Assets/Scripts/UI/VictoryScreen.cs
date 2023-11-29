using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private Button nextBtn;

    private void OnEnable()
    {
        nextBtn.onClick.AddListener(ChangeNextScene);
    }

    private void OnDisable()
    {
        nextBtn.onClick.RemoveListener(ChangeNextScene);
    }

    private void ChangeNextScene()
    {
        SceneLoader.Instance.ReloadCurrentScene();
    }
}
