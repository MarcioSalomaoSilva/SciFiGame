using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerManager))]
public class PlayerMotor : MonoBehaviour // does what the player manager tells it to
{
    public delegate void ActionDelegate(bool wasPressed);
    public static event ActionDelegate OnAction;
    [HideInInspector]
    public CameraState cameraState;
    [Header("Gizmo Stuff")]
    public PlayerManager playerManager;//throws a null assign in inspector
    public DebugManager debugManager;//throws a null assign in inspector
    public BoxCollider boxCollider; //throws a null ref if not assigned in inspector because of gizmos
    //
    Rigidbody rigidbody3D;
    //
    float velocityXSmoothing;
    float velocityZSmoothing;
    //float accelerationTimeGrounded = 0.2f;
    Vector3 savedVelocity;
    Vector3 currentVelocity;
    Vector3 targetPositionVelocity;
    Vector3 newPosition;
    Transform currentTransformDirection;
    Transform newTransformDirection;
    //
    Quaternion direction;
    // Use this for initialization
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        rigidbody3D = GetComponent<Rigidbody>();
        rigidbody3D.useGravity = true;
        rigidbody3D.freezeRotation = true;
        //
    }
    public void Move(PlayerInfo playerInfo)//uses input to move and rotate the player with smoothing 
    {
        playerInfo.movementAxis = Camera.main.transform.TransformDirection(new Vector3(playerInfo.movementAxis.x, 0, playerInfo.movementAxis.z));
        playerInfo.movementAxis.y = 0;
        playerInfo.movementAxis.Normalize();
        //
        rigidbody3D.rotation = Rotation(playerInfo.movementAxis);
        //
        float moveSpeed = Mathf.Lerp(0, playerInfo.moveSpeed, playerManager.currentInfo.movementAxis.magnitude);
        newPosition = this.transform.position + playerInfo.movementAxis * moveSpeed * Time.deltaTime;
        //
        float targetVelocityX = playerInfo.movementAxis.x * playerInfo.moveSpeed;
        float targetVelocityZ = playerInfo.movementAxis.z * playerInfo.moveSpeed;
        playerInfo.movementAxis.x = Mathf.SmoothDamp(newPosition.x, targetVelocityX, ref velocityXSmoothing, playerManager.accelarationTime * Time.deltaTime);
        playerInfo.movementAxis.z = Mathf.SmoothDamp(newPosition.z, targetVelocityZ, ref velocityZSmoothing, playerManager.accelarationTime * Time.deltaTime);
        //playerInfo.movementAxis.x = Mathf.SmoothDamp(newPosition.x, targetVelocityX, ref velocityXSmoothing, playerManager.currentInfo.movementAxis.magnitude * Time.deltaTime);
        //playerInfo.movementAxis.z = Mathf.SmoothDamp(newPosition.z, targetVelocityZ, ref velocityZSmoothing, playerManager.currentInfo.movementAxis.magnitude * Time.deltaTime);
        //
        rigidbody3D.MovePosition(newPosition);
    }
    public void Action(bool actionWasPressed)
    {
        if (OnAction != null)
        {
            OnAction(actionWasPressed);
        }
    }
    //
    public Quaternion Rotation(Vector3 movementAxis)// checks if player moves and gets a direction
    {
        if (playerManager.currentInfo.movementAxis.magnitude > playerManager.controllerDeadZone)
        {
            rigidbody3D.rotation = Quaternion.Slerp(
                rigidbody3D.rotation, 
                Quaternion.LookRotation(movementAxis), 
                playerManager.rotationSpeed * Time.deltaTime);
            direction = rigidbody3D.rotation;
        }
        else
        {
            rigidbody3D.rotation = direction;
        }
        return direction;
    }
    //
    public bool IsGrounded(ref bool isGrounded, float skinWidth)// draws a couple of rays to check if the player is touching the ground 
    { 
        return isGrounded = (Physics.Raycast(new Vector3(boxCollider.bounds.min.x + skinWidth, this.transform.position.y, this.transform.position.z), Vector3.down, boxCollider.bounds.extents.y + 0.05f) ||
            Physics.Raycast(new Vector3(boxCollider.bounds.max.x - skinWidth, this.transform.position.y, this.transform.position.z), Vector3.down, boxCollider.bounds.extents.y + 0.05f)) ? true : false;
    }
    //
    void OnDrawGizmos()//draws rays using gizmos so the above raycasts can be visualized and understood
    {
        if (debugManager.playerDebug)
        {
            if (debugManager.playerDirection)
            {
                Gizmos.color = Color.black;//world space
                Gizmos.DrawRay(this.transform.position, playerManager.currentInfo.movementAxis * 1.5f);
            }
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(this.transform.position, this.transform.forward * 1.5f);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(this.transform.position, this.transform.up);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(this.transform.position, this.transform.right);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(this.transform.position, .1f);
        }
    }
}
public enum MoveState
{
    Ready,
    Moving,
    Cooldown
}
