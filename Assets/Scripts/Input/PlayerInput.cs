using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Vector2 axes => playerInputAction.GamePlay.Axes.ReadValue<Vector2>();

    // 按下我们playaction中定义的按键，即可触发
    public bool Jump => playerInputAction.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
    public float AxesX => axes.x;
    public bool Move => AxesX != 0;
    
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
    }

    public void EnableGameplayInputs()
    {
        playerInputAction.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
