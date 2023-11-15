using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StarGem : MonoBehaviour
{
    [SerializeField] private ParticleSystem starGemVFX;
    [SerializeField] private AudioClip starGemClip;
    [SerializeField] private Vector3 starRotationAxes;
    
    private WaitForSeconds resetTime;
    private Collider starCollider;
    private MeshRenderer starMeshRenderer; 
    private AudioSource audioSource;
    private void Awake()
    {
        starCollider = GetComponent<Collider>();
        starMeshRenderer = GetComponentInChildren<MeshRenderer>();
        resetTime = new WaitForSeconds(3.0f);
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(starRotationAxes * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.CanJump = true;
            starCollider.enabled = false;
            starMeshRenderer.enabled = false;
            audioSource.PlayOneShot(starGemClip); 
            GameObject starGemParticle = PoolManager.Instance.GetAObjFromPool(starGemVFX.gameObject);
            starGemParticle.AddComponent<ParticleSystemManager>();
            starGemParticle.transform.position = transform.position;
            starGemParticle.transform.rotation = Quaternion.identity;
            StartCoroutine(ResetStar());
        }
    }

    private void ResetStarGem()
    {
        starCollider.enabled = true;
        starMeshRenderer.enabled = true;
    }

    IEnumerator ResetStar()
    {
        yield return resetTime;
        ResetStarGem();
    }
}
