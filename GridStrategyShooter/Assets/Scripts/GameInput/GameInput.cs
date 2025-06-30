using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnMove;

    PlayerInputActions playerInputActions;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;

        playerInputActions = new PlayerInputActions();

        playerInputActions.Unit.Enable();

        playerInputActions.Unit.Move.performed += Move_performed;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        OnMove?.Invoke(this, EventArgs.Empty);
    }

   
}
