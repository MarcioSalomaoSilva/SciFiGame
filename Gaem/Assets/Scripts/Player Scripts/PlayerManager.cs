using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PlayerManager : MonoBehaviour // gets from player input and send to player manager, needs a rigidbody and a collider
{
    public static PlayerManager instance;
    PlayerMotor playerMotor;
    PlayerInput playerInput;
    public PlayerInfo currentInfo;
    //
    [Header("Debug (allows RT changes)")]
    public bool debug;
    [Header("Controller Settings")]
    public float controllerDeadZone = 0.2f;
    [Header("Movement Settings")]
    public float accelarationTime = 1f;
    public float moveSpeed = 6;
    public float rotationSpeed = 10;
    //physics
    [HideInInspector]
    public float skinWidth = .015f;
    // Use this for initialization
    void Awake ()
    {
        instance = this;
        playerMotor = GetComponent<PlayerMotor>();
        playerInput = GetComponent<PlayerInput>();
        currentInfo.moveSpeed = moveSpeed;
    }
	// Update is called once per frame
	void Update ()
    {
        playerInput.GetInput(ref currentInfo, ref controllerDeadZone);
        if (debug)
        {
            currentInfo.moveSpeed = moveSpeed;
            currentInfo.rotationSpeed = rotationSpeed;
            //
            currentInfo.controllerDeadZone = controllerDeadZone;
        }
        playerMotor.Action(currentInfo.actionWasPressed);
    }
    //
    void FixedUpdate()
    {
        playerMotor.IsGrounded(ref currentInfo.grounded, skinWidth);//check if grounded
        playerMotor.Move(currentInfo); //move with inputs
    }
}
//
public struct PlayerInfo
{
    public Vector3 movementAxis;// WASD/Left analog(PS/XBOX)
    public Vector3 cameraAxis;// WASD/Right analog(PS/XBOX)
    public bool actionWasPressed;// E/X(PS)/A(XBOX) when the button is pressed
    public bool actionIsPressed;// E/X(PS)/A(XBOX) while the button is pressed
    public bool cancel;//
    public bool cancelIsPressed;//
    public bool esc;//
    public bool walled;
    public bool grounded;
    public float moveSpeed;
    public float rotationSpeed;
    //
    public float controllerDeadZone;
}