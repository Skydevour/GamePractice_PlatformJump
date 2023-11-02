using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void SetPlayerVelocity(Vector3 velocity)
    {
        playerRigidbody.velocity = velocity;
    }
    
    public void SetPlayerVelocityX(float velocityX, float direction)
    {
        playerRigidbody.velocity = new Vector3(velocityX * direction, playerRigidbody.velocity.y);
    }
    
    public void SetPlayerVelocityY(float velocityY, float direction)
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, velocityY * direction);
    }
    
}
