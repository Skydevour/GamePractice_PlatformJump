using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    public float PlayerMoveSpeed => MathF.Abs(playerRigidbody.velocity.x);

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

    public void SetPlayerVelocity(Vector3 velocity)
    {
        playerRigidbody.velocity = velocity;
    }
    
    public void SetPlayerVelocityX(float velocityX, float moveDirection)
    {
        if (moveDirection != 0.0)
        {
            playerTransform.localScale = new Vector3(moveDirection, playerTransform.localScale.y, playerTransform.localScale.z);
        }
        playerRigidbody.velocity = new Vector3(velocityX * moveDirection, playerRigidbody.velocity.y);
    }
    
    public void SetPlayerVelocityY(float velocityY, float moveDirection)
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, velocityY * moveDirection);
    }
    
}
