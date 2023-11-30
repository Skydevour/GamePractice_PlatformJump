using UnityEngine;

public class VictoryGem : PickUpManager
{
    [SerializeField] private ParticleSystem victoryGemVFX;
    [SerializeField] private AudioClip victoryGemClip;
    [SerializeField] private Vector3 victoryGemRotationAxes;

    private MeshRenderer victoryGemRenderer;
    private Collider victoryGemCollider;
    
    private void Awake()
    {
        GetGameObjectComponent(this.gameObject, out victoryGemRenderer, out victoryGemCollider);
    }

    private void FixedUpdate()
    {
        transform.Rotate(victoryGemRotationAxes * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerParticleSystem(victoryGemVFX);
        TriggerAudioSource(victoryGemClip);
        DisableGameObjectComponent(victoryGemRenderer, victoryGemCollider);
        EventCenter.TriggerEvent(new PlayerVictoryEvent());
        EventCenter.TriggerEvent(new IsGameVictoryEvent(true));
    }
}
