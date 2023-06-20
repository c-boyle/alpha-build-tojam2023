using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  A class for hooking player input up to their robo.
 */

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput input;
    [SerializeField] private RoboMovement movement;
    [SerializeField] private Combatable combatable;

    private bool activeMovementInput = false;
    private bool activeLookInput = false;
    private InputAction move = null;
    private InputAction look = null;

    private void Awake()
    {
        HookupControls();
    }

    private void Update()
    {
        if (move != null && activeMovementInput)
        {
            movement.Move(move.ReadValue<Vector2>());
        }
        if (look != null && activeLookInput)
        {
            movement.Look(look.ReadValue<Vector2>());
        }
    }

    
    private void HookupControls()
    {
        var actionMap = input.actions.FindActionMap("GameControls");

        move = actionMap.FindAction("Move");
        move.performed += ctx => { activeMovementInput = true; };
        move.canceled += ctx => { activeMovementInput = false; movement.Move(Vector2.zero); };

        look = actionMap.FindAction("Look");
        look.performed += ctx => { activeLookInput = true; };
        look.canceled += ctx => { activeLookInput = false; };

        actionMap.FindAction("UseRoboModSouth").performed += ctx => { /* TODO */ };
        actionMap.FindAction("UseRoboModNorth").performed += ctx => { combatable.UseRoboModNorth(); };
        actionMap.FindAction("UseRoboModEast").performed += ctx => { combatable.UseRoboModEast(); };
        actionMap.FindAction("UseRoboModWest").performed += ctx => { combatable.UseRoboModWest(); };
        actionMap.FindAction("UseSoftware").performed += ctx => { /* TODO */ };
    }
}
