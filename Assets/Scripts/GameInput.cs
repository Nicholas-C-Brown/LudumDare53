using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    public bool IsGasPressed()
    {
        return playerInputActions.Player.Gas.IsPressed();
    }

    public bool IsTurnLeftPressed()
    {
        return playerInputActions.Player.TurnLeft.IsPressed();
    }

    public bool IsTurnRightPressed()
    {
        return playerInputActions.Player.TurnRight.IsPressed();
    }







}
