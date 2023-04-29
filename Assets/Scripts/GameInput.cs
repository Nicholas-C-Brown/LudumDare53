using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private PlayerInputActions playerInputActions;
    private MenuInputActions menuInputActions;

    public event EventHandler OnPauseToggle;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        menuInputActions = new MenuInputActions();
        menuInputActions.Menu.Enable();
        menuInputActions.Menu.Pause.performed += Pause_performed;
    }

    //Player
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


    //Menu
    private void Pause_performed(InputAction.CallbackContext obj)
    {
        OnPauseToggle?.Invoke(this, EventArgs.Empty);
    }







}
