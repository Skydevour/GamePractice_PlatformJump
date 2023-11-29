using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    private const float loadWaitTime = 0.1f;
    [SerializeField] private int currentSceneIndex;

    public override void Awake()
    {
        base.Awake();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadCurrentScene()
    {
        StartCoroutine(LoadSceneAsync(currentSceneIndex));
    }

    public void ChangeToNextScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCount)
        {
            // 不可以切换，暂时先重载场景
            ReloadCurrentScene();
            return;
        }
        StartCoroutine(LoadSceneAsync(nextSceneIndex));
    }

    public void QuitCurrentScene()
    {
        StartCoroutine(UnloadSceneAsync(currentSceneIndex));
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    public IEnumerator LoadSceneAsync(int sceneIndex)
    {
        Scene scene = SceneManager.GetSceneAt(sceneIndex);
 
        //可在此显示Loading界面
        //如果用LoadSceneMode.Single方式加载，需要单独做一个Loading场景，用于切场景过渡
        //这里使用LoadSceneMode.Additive方式，所有的UI界面都在主场景，场景过渡时使用Loading界面即可
 
        float startTime = Time.time;
 
        //选择场景加载方式
        //LoadSceneMode.Single会卸载掉之前的原有的场景，只保留新加载场景
        //LoadSceneMode.Additive，会在原有场景的基础上附加新场景
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
 
        //AsyncOperation.progress范围(0~1)
        //isDone为false时，最大加载到0.9就会暂停，直到isDone为true时才会继续加载剩余的0.9 - 1.0
        //只有allowSceneActivation = true，isDone才会在progress = 1.0后，值为true
        //作用是让场景不会在加载完成后自动跳转到下一个场景
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            //手动延长加载时间，防止加载界面展示时间过短
            if (Time.time - startTime >= loadWaitTime)
            {
                if (operation.progress >= 0.9f && !operation.allowSceneActivation)
                    operation.allowSceneActivation = true;
            }
            yield return null;
        }
 
        //如果不需要等待，可直接加载后跳转场景
        operation.allowSceneActivation = true;
        while (!operation.isDone)
        {
            yield return null;
        }
 
        //加载完成，可以设置回调
        Debug.LogFormat("LoadSceneAsync Success : {0}", SceneManager.GetActiveScene());
        StopCoroutine(LoadSceneAsync(sceneIndex));
    }
 
    public IEnumerator UnloadSceneAsync(int sceneIndex)
    {
        Scene scene = SceneManager.GetSceneAt(sceneIndex);
 
        if (!scene.isLoaded)
        {
            Debug.LogErrorFormat("Scene is not loaded : {0}", SceneManager.GetActiveScene());
            yield break;
        }
 
        float startTime = Time.time;

        AsyncOperation operation = SceneManager.UnloadSceneAsync(scene);
        yield return operation;
        StopCoroutine(UnloadSceneAsync(sceneIndex));
    }
}
