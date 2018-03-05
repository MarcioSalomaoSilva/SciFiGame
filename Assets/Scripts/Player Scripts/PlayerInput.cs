using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : MonoBehaviour //gets the inputs that player manager asks for
{
    PlayerManager playerManager;
    CurrentDirection currentDirection;
    //
    public void GetInput(ref PlayerInfo ci, ref float controllerDeadZone)
    {
        ci.movementAxis = GetAxis(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), controllerDeadZone);// WASD/Left analog(PS/XBOX)
        //
        ci.actionIsPressed = Input.GetButton("Action");// E/X(PS)/A(XBOX) while the button is pressed
        ci.actionWasPressed = Input.GetButtonDown("Action");// E/X(PS)/A(XBOX) when the button is pressed
    }
    public Vector3 GetAxis(Vector3 input, float controllerDeadZone)
    {
        input = input.magnitude > 1 ? input.normalized : input;
        //
        input = input.magnitude < controllerDeadZone ? input = Vector3.zero : input = input.normalized * ((input.magnitude - controllerDeadZone) / (1 - controllerDeadZone));
        return input;
    }
    //
    public CurrentDirection CheckDirection(Vector3 analogDirection)
    {
        if (analogDirection.z >= 0.9f)
        {
            currentDirection = CurrentDirection.Up;
        }
        else if (analogDirection.z <= -0.9f)
        {
            currentDirection = CurrentDirection.Down;
        }
        else if (analogDirection.x <= -0.9f)
        {
            currentDirection = CurrentDirection.Left;
        }
        else if (analogDirection.x >= 0.9f)
        {
            currentDirection = CurrentDirection.Right;
        }
        else
        {
            currentDirection = CurrentDirection.Neutral;
        }
        return currentDirection;
    }
}
public enum CurrentDirection
{
    Neutral, Left, Right, Up, Down
}
//

