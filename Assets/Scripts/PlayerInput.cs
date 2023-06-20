using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls controls;
    private bool activeMovementInput = false;

    private void Awake()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
        }
        controls.GameControls.Move.performed += ctx => { activeMovementInput = true; };
        controls.GameControls.Move.canceled += ctx => { activeMovementInput = false; };
        controls.GameControls.Look.performed += ctx => { if (ctx.control.device is Keyboard) { } };
        controls.GameControls.UseRoboModSouth.performed += ctx => { };
        controls.GameControls.UseRoboModNorth.performed += ctx => { };
        controls.GameControls.UseRoboModEast.performed += ctx => { };
        controls.GameControls.UseRoboModWest.performed += ctx => { };
        controls.GameControls.UseSoftware.performed += ctx => { };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
