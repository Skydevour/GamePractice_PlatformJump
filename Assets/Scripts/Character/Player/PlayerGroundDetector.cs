using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 0.05f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider[] detectionColliders = new Collider[2];
    
    public bool IsGround => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, detectionColliders, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
