using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  A class for hooking player input up to their robo.
 */

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput input;
    [SerializeField] private RoboMovement movement;
    [SerializeField] private Robot combatable;
    [SerializeField] private Stats stats;

    private bool activeMovementInput = false;
    private bool activeLookInput = false;
    private InputAction move = null;
    private InputAction look = null;

    private void Awake()
    {
        HookupControls();
        CameraTargetGroup.Instance.TargetGroup.AddMember(transform, 1f, 1.5f);
    }

    private void Update()
    {
        if (move != null && activeMovementInput)
        {
            movement.Move(move.ReadValue<Vector2>());
        }
        if (look != null && activeLookInput)
        {
            Vector2 lookValue = look.ReadValue<Vector2>();
            if (look.activeControl.device is Mouse)
            {
                lookValue = Camera.main.ScreenToWorldPoint(lookValue) - transform.position;
            }
            movement.Look(lookValue);
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
