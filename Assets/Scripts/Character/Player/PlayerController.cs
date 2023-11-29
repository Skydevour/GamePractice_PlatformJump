using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private PlayerGroundDetector playerGroundDetector;
    
    public AudioSource PlayerAudioSource;

    public bool IsGrounded => playerGroundDetector.IsGround;
    public bool IsFalling => playerRigidbody.velocity.y < 0f && !IsGrounded;
    public float PlayerMoveSpeed => MathF.Abs(playerRigidbody.velocity.x);
    public bool CanJump { get; set; }
    public bool IsVictory { get; private set; }

    private void OnEnable()
    {
        EventCenter.StartListenToEvent<PlayerVictoryEvent>(OnPlayerVictoryEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<PlayerVictoryEvent>(OnPlayerVictoryEvent);
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = transform;
        playerGroundDetector = GetComponentInChildren<PlayerGroundDetector>();
        PlayerAudioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnPlayerVictoryEvent(PlayerVictoryEvent evt)
    {
        IsVictory = true;
    }

    public void GameOverSettings()
    {
        playerRigidbody.useGravity = false;
        playerRigidbody.velocity = Vector3.zero;
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
    
    public void SetPlayerVelocityY(float velocityY)
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, velocityY);
    }

    public void SetUseGravity(bool isUseGravity)
    {
        playerRigidbody.useGravity = isUseGravity;
    }
}
