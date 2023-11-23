using UnityEngine;

public class GateTrigger : PickUpManager
{
    [SerializeField] private ParticleSystem gateTriggerVFX;
    [SerializeField] private AudioClip gateTriggerClip;
    [SerializeField] private Vector3 gateTriggerRotationAxes;
    
    private MeshRenderer gateTriggerRenderer;
    private Collider gateTriggerCollider;
    private void Awake()
    {
        GetGameObjectComponent(this.gameObject, out gateTriggerRenderer, out gateTriggerCollider);
    }

    private void FixedUpdate()
    {
        transform.Rotate(gateTriggerRotationAxes * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerParticleSystem(gateTriggerVFX);
        TriggerAudioSource(gateTriggerClip);
        DisableGameObjectComponent(gateTriggerRenderer, gateTriggerCollider);
        EventCenter.TriggerEvent(new GateOpenOrCloseEvent(true));
    }
}
