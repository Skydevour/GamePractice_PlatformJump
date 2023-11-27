using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    protected void TriggerParticleSystem(ParticleSystem particleSystem)
    {
        GameObject gateTriggerParticle = PoolManager.Instance.GetAObjFromPool(particleSystem.gameObject);
        gateTriggerParticle.AddComponent<ParticleSystemManager>();
        gateTriggerParticle.transform.position = transform.position;
        gateTriggerParticle.transform.rotation = Quaternion.identity;
    }

    protected void TriggerAudioSource(AudioClip audioSource)
    {
        SoundEffectPlayer.AudioSource.PlayOneShot(audioSource);
    }
    
    protected void TriggerAudioSource(AudioClip[] audioSources)
    {
        AudioClip audioClip = audioSources[Random.Range(0, audioSources.Length)];
        SoundEffectPlayer.AudioSource.PlayOneShot(audioClip);
    }

    protected void DisableGameObjectComponent(MeshRenderer renderer, Collider collider)
    {
        renderer.enabled = false;
        collider.enabled = false;
    }

    protected void GetGameObjectComponent(GameObject gameObject, out MeshRenderer renderer, out Collider collider)
    {
        renderer = gameObject.GetComponentInChildren<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
    }

    protected IEnumerator EnableGameObjectComponent(WaitForSeconds resetTime, MeshRenderer renderer, Collider collider)
    {
        yield return resetTime;
        collider.enabled = true;
        renderer.enabled = true;
    }
}
