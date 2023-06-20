using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 *  A class for sending player input to their robo.
 */

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput input;
    [SerializeField] private RoboMovement movement;
    [SerializeField] private Combatable combatable;

    private InputValue move = null;
    private InputAction look = null;

    private void Update()
    {
        if (move != null && move.isPressed)
        {
            movement.Move(move.Get<Vector2>());
        }
        if (look != null && look.IsPressed())
        {
            Vector2 value = look.ReadValue<Vector2>();
            if (look.activeControl.device is Mouse)
            {
                value = Camera.current.ScreenToWorldPoint(value) - transform.position;
            }
            movement.Look(value);
        }
    }

    private void OnLook(InputValue value)
    {
        if (look == null)
        {
            look = input.actions.FindActionMap("GameControls").FindAction("Look");
        }
    }

    private void OnMove(InputValue value)
    {
        if (move == null)
        {
            move = value;
        }
    }

    private void OnUseRoboModNorth(InputValue value)
    {
        combatable.UseRoboModNorth();
    }

    private void OnUseRoboModSouth(InputValue value)
    {
        
    }

    private void OnUseRoboModEast(InputValue value)
    {
        combatable.UseRoboModEast();
    }

    private void OnUseRoboModWest(InputValue value)
    {
        combatable.UseRoboModWest();
    }

    private void OnUseSoftware(InputValue value)
    {
        
    }
}
