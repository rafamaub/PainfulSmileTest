using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipInput : MonoBehaviour
{
    [SerializeField] private ShipController controller;
    [SerializeField] private CannonController cannonController;


    public void MoveShipForward(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            controller.moving = true;
        }
        else if(ctx.canceled)
        {
            controller.moving = false;
        }
    }

    public void TurnShip(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            float direction = ctx.ReadValue<float>();

            if(direction > 0)
            {
                controller.turnLeft = true;
                
            }
            else if(direction < 0)
            {
                controller.turnRight = true;
            }
        }
        else if(ctx.canceled)
        {
            controller.turnRight = false;
            controller.turnLeft = false;
        }
    }

    public void ShootFrontCannon(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if (!cannonController.gameplayHud)
            {
                cannonController.gameplayHud = FindObjectOfType<GameplayHud>();
            }

            cannonController.ShootFrontCannon();
        }
    }

    public void ShootSideCannon(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if(!cannonController.gameplayHud)
            {
                cannonController.gameplayHud = FindObjectOfType<GameplayHud>();
            }

            cannonController.ShootSideCannon();
        }
    }

    public void DisableInput()
    {
        GetComponent<PlayerInput>().DeactivateInput();
    }

}
