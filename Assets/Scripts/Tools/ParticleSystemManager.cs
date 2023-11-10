using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    private ParticleSystem.MainModule mainModule;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;
        // 监听粒子系统停止事件
        mainModule.stopAction = ParticleSystemStopAction.Callback; 
    }
    
    private void OnParticleSystemStopped()
    {
        // 回收，防止频繁生成销毁
        PoolManager.Instance.ReleaseAObjFromPool(particleSystem.gameObject);
    }
}
