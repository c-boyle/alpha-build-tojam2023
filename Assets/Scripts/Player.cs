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
    [SerializeField] private Robo robo;

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
            robo.Movement.Move(move.ReadValue<Vector2>());
        }
        if (look != null && activeLookInput)
        {
            Vector2 lookValue = look.ReadValue<Vector2>();
            if (look.activeControl.device is Mouse)
            {
                // TODO: Cache main camera
                lookValue = Camera.main.ScreenToWorldPoint(lookValue) - transform.position;
            }
            robo.Movement.Look(lookValue);
        }
    }

    
    private void HookupControls()
    {
        var actionMap = input.actions.FindActionMap("GameControls");

        move = actionMap.FindAction("Move");
        move.performed += ctx => { activeMovementInput = true; };
        move.canceled += ctx => { activeMovementInput = false; robo.Movement.Move(Vector2.zero); };

        look = actionMap.FindAction("Look");
        look.performed += ctx => { activeLookInput = true; };
        look.canceled += ctx => { activeLookInput = false; };

        actionMap.FindAction("UseRoboModSouth").performed += ctx => { robo.UseRoboModSouth(false); };
        actionMap.FindAction("UseRoboModNorth").performed += ctx => { robo.UseRoboModNorth(false); };
        actionMap.FindAction("UseRoboModEast").performed += ctx => { robo.UseRoboModEast(false); };
        actionMap.FindAction("UseRoboModWest").performed += ctx => { robo.UseRoboModWest(false); };
        actionMap.FindAction("UseRoboModSouth").canceled += ctx => { robo.UseRoboModSouth(true); };
        actionMap.FindAction("UseRoboModNorth").canceled += ctx => { robo.UseRoboModNorth(true); };
        actionMap.FindAction("UseRoboModEast").canceled += ctx => { robo.UseRoboModEast(true); };
        actionMap.FindAction("UseRoboModWest").canceled += ctx => { robo.UseRoboModWest(true); };
        actionMap.FindAction("UseSoftware").performed += ctx => { /* TODO */ };
    }
}
