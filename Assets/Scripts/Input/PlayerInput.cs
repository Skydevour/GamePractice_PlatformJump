using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Vector2 axes => playerInputAction.GamePlay.Axes.ReadValue<Vector2>();
    private WaitForSeconds jumpInputWaitForSeconds;
    [SerializeField] private float jumpInputBufferTime;
    
    // 按下我们playaction中定义的按键，即可触发
    public bool Jump => playerInputAction.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
    public float AxesX => axes.x;
    public bool Move => AxesX != 0;
    public bool HasJumpBuffer { get; set; }

    private void OnEnable()
    {
        EventCenter.StartListenToEvent<PlayerDefeatEvent>(OnPlayerDefeatEvent);
    }

    private void OnDisable()
    {
        EventCenter.StopListenToEvent<PlayerDefeatEvent>(OnPlayerDefeatEvent);
    }

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        jumpInputWaitForSeconds = new WaitForSeconds(jumpInputBufferTime);
        playerInputAction.GamePlay.Jump.canceled += delegate
        {
            HasJumpBuffer = false;
        };
    }
    
    private void OnPlayerDefeatEvent(PlayerDefeatEvent evt)
    {
        DisableGameplayInputs();
    }

    public void EnableGameplayInputs()
    {
        playerInputAction.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableGameplayInputs()
    {
        playerInputAction.GamePlay.Disable();
    }

    public void SetHasJumpBuffer()
    {
        StopCoroutine(SetJumpBufferCoroutine());
        StartCoroutine(SetJumpBufferCoroutine());
    }

    IEnumerator SetJumpBufferCoroutine()
    {
        HasJumpBuffer = true;
        yield return jumpInputWaitForSeconds;
        HasJumpBuffer = false;
    }
}
