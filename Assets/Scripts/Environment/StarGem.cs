using System.Collections;
using UnityEngine;

public class StarGem : PickUpManager
{
    [SerializeField] private ParticleSystem starGemVFX;
    [SerializeField] private AudioClip starGemClip;
    [SerializeField] private Vector3 starRotationAxes;
    
    private WaitForSeconds resetTime;
    private Collider starCollider;
    private MeshRenderer starMeshRenderer; 
    private void Awake()
    {
        GetGameObjectComponent(this.gameObject, out starMeshRenderer, out starCollider);
        resetTime = new WaitForSeconds(3.0f);
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
            DisableGameObjectComponent(starMeshRenderer, starCollider);
            TriggerAudioSource(starGemClip);
            TriggerParticleSystem(starGemVFX);
            StartCoroutine(EnableGameObjectComponent(resetTime, starMeshRenderer, starCollider));
        }
    }

    
}
