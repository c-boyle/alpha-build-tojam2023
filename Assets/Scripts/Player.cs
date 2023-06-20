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
    private PlayerInput _input;
    public PlayerInput Input { 
        get
        {
            return _input;
        } 
        set
        {
            if (_input != null)
            {
                ReleaseControls();
            }
            _input = value;
            HookupControls();
        }
    }
    [field: SerializeField] public Robo Robo { get; set; }

    private bool activeMovementInput = false;
    private bool activeLookInput = false;
    private InputAction move = null;
    private InputAction look = null;

    private void Awake()
    {
        CameraTargetGroup.Instance.TargetGroup.AddMember(transform, 1f, 1.5f);
    }

    private void Update()
    {
        if (move != null && activeMovementInput)
        {
            Robo.Movement.Move(move.ReadValue<Vector2>());
        }
        if (look != null && activeLookInput)
        {
            Vector2 lookValue = look.ReadValue<Vector2>();
            if (look.activeControl.device is Mouse)
            {
                // TODO: Cache main camera
                lookValue = Camera.main.ScreenToWorldPoint(lookValue) - transform.position;
            }
            Robo.Movement.Look(lookValue);
        }
    }

    private void OnEnable() {
        if (Input != null)
        {
            Input.actions.FindActionMap("GameControls").Enable();
        }
    }

    private void OnDisable()
    {
        if (Input != null)
        {
            Input.actions.FindActionMap("GameControls").Disable();
        }
    }

    private void HookupControls()
    {
        var actionMap = Input.actions.FindActionMap("GameControls");

        move = actionMap.FindAction("Move");
        move.performed += OnMovePerformed;
        move.canceled += OnMoveCanceled;

        look = actionMap.FindAction("Look");
        look.performed += OnLookPerformed;
        look.canceled += OnLookCanceled;

        actionMap.FindAction("UseRoboModSouth").performed += OnSouthPerformed;
        actionMap.FindAction("UseRoboModNorth").performed += OnNorthPerformed;
        actionMap.FindAction("UseRoboModEast").performed += OnEastPerformed;
        actionMap.FindAction("UseRoboModWest").performed += OnWestPerformed;
        actionMap.FindAction("UseRoboModSouth").canceled += OnSouthCanceled;
        actionMap.FindAction("UseRoboModNorth").canceled += OnNorthCanceled;
        actionMap.FindAction("UseRoboModEast").canceled += OnEastCanceled;
        actionMap.FindAction("UseRoboModWest").canceled += OnWestCanceled;
        //actionMap.FindAction("UseSoftware").performed += ctx => { /* TODO */ };
    }

    private void ReleaseControls()
    {
        var actionMap = Input.actions.FindActionMap("GameControls");

        move = actionMap.FindAction("Move");
        move.performed -= OnMovePerformed;
        move.canceled -= OnMoveCanceled;

        look = actionMap.FindAction("Look");
        look.performed -= OnLookPerformed;
        look.canceled -= OnLookCanceled;

        actionMap.FindAction("UseRoboModSouth").performed -= OnSouthPerformed;
        actionMap.FindAction("UseRoboModNorth").performed -= OnNorthPerformed;
        actionMap.FindAction("UseRoboModEast").performed -= OnEastPerformed;
        actionMap.FindAction("UseRoboModWest").performed -= OnWestPerformed;
        actionMap.FindAction("UseRoboModSouth").canceled -= OnSouthCanceled;
        actionMap.FindAction("UseRoboModNorth").canceled -= OnNorthCanceled;
        actionMap.FindAction("UseRoboModEast").canceled -= OnEastCanceled;
        actionMap.FindAction("UseRoboModWest").canceled -= OnWestCanceled;
        //actionMap.FindAction("UseSoftware").performed -= ctx => { /* TODO */ };
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        activeMovementInput = true;
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        activeMovementInput = false;
        Robo.Movement.Move(Vector2.zero);
    }

    private void OnLookPerformed(InputAction.CallbackContext ctx)
    {
        activeLookInput = true;
    }

    private void OnLookCanceled(InputAction.CallbackContext ctx)
    {
        activeLookInput = false;
    }

    private void OnSouthPerformed(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModSouth(false);
    }

    private void OnSouthCanceled(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModSouth(true);
    }

    private void OnNorthPerformed(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModNorth(false);
    }

    private void OnNorthCanceled(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModNorth(true);
    }

    private void OnWestPerformed(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModWest(false);
    }

    private void OnWestCanceled(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModWest(true);
    }

    private void OnEastPerformed(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModEast(false);
    }

    private void OnEastCanceled(InputAction.CallbackContext ctx)
    {
        Robo.UseRoboModEast(true);
    }
}
