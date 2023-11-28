using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Float", fileName = "FloatState")]
public class FloatState : PlayerState
{
    [SerializeField] private float floatSpeed;
    [SerializeField] private Vector3 floatPosOffset;
    [SerializeField] private Vector3 floatTargetPos;
    [SerializeField] private Vector3 floatVFXOffset;
    [SerializeField] private ParticleSystem floatVFX;
    public override void Enter()
    {
        base.Enter();
        floatTargetPos = playerController.transform.position + floatPosOffset;
        GameObject floatParticle = PoolManager.Instance.GetAObjFromPool(floatVFX.gameObject);
        floatParticle.AddComponent<ParticleSystemManager>();
        var playerTransform = playerController.transform;
        var playerPosition = playerTransform.position;
        floatParticle.transform.parent = playerTransform;
        floatParticle.transform.position = playerPosition + floatVFXOffset;
        floatParticle.transform.rotation = Quaternion.identity;
    }

    public override void LogicalUpdate()
    {
        if (Vector3.Distance(playerController.transform.position, floatTargetPos) > floatSpeed * Time.deltaTime)
        {
            playerController.transform.position = Vector3.MoveTowards(playerController.transform.position,
                floatTargetPos, floatSpeed * Time.deltaTime);
        }
        else
        {
            floatTargetPos += (Vector3)Random.insideUnitCircle;
        }
    }
}
