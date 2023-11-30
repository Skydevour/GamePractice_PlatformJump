using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public void TriggerParticleSystem(ParticleSystem particleSystem)
    {
        GameObject particle = PoolManager.Instance.GetAObjFromPool(particleSystem.gameObject);
        particle.AddComponent<ParticleSystemManager>();
        particle.transform.position = transform.position;
        particle.transform.rotation = Quaternion.identity;
    }

    public void TriggerAudioSource(AudioClip audioSource)
    {
        SoundEffectPlayer.AudioSource.PlayOneShot(audioSource);
    }
    
    public void TriggerAudioSource(AudioClip[] audioSources)
    {
        AudioClip audioClip = audioSources[Random.Range(0, audioSources.Length)];
        SoundEffectPlayer.AudioSource.PlayOneShot(audioClip);
    }

    public void DisableGameObjectComponent(MeshRenderer renderer, Collider collider)
    {
        renderer.enabled = false;
        collider.enabled = false;
    }

    public void GetGameObjectComponent(GameObject gameObject, out MeshRenderer renderer, out Collider collider)
    {
        renderer = gameObject.GetComponentInChildren<MeshRenderer>();
        collider = gameObject.GetComponent<Collider>();
    }

    public IEnumerator EnableGameObjectComponent(WaitForSeconds resetTime, MeshRenderer renderer, Collider collider)
    {
        yield return resetTime;
        collider.enabled = true;
        renderer.enabled = true;
    }
}
