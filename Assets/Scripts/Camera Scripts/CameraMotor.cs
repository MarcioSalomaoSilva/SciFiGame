using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    CameraManager cameraManager;
    public CameraState cameraState;
    [HideInInspector]
    public Transform thisTransform;
    bool stationaryTransform;
    Vector3 cameraPosistion;
    bool positionSet = true;
    //
    float yVelocity; 
    float xVelocity;
    float zVelocity;
    [HideInInspector]
    public float cameraChangeSpeed;
    //
    private void Start()
    {
        cameraManager = GetComponent<CameraManager>();
        cameraChangeSpeed = cameraManager.cameraChangeSpeed;
    }
    private void OnEnable()
    {
        CameraManager.SetStationary += SetStationaryState;
        CameraManager.SetFollow += SetFollowState;
    }
    private void OnDisable()
    {
        CameraManager.SetStationary -= SetStationaryState;
        CameraManager.SetFollow -= SetFollowState;
    }
    //
    public void DetectCameraPosition()// change the name of fixed update to camera detect so you can control updates just like in player manager
    {
        //cameraState = cameraLocations.Count == 0 ? cameraState = CameraState.Follow : cameraState = CameraState.Stationary;
        cameraPosistion = new Vector3(cameraManager.cameraTarget.transform.position.x, 
            cameraManager.cameraTarget.transform.position.y + cameraManager.cameraHeight, 
            cameraManager.cameraTarget.transform.position.z - cameraManager.cameraDistance);
        switch (cameraState)
        {
            case CameraState.Follow:
                if (positionSet) {
                    this.transform.position = cameraPosistion;
                    Move(cameraPosistion, cameraManager.cameraSpeed, cameraManager.cameraSmoothTime);
                }
                LookAt(cameraManager.lookAtPlayer);
                break;
            case CameraState.Stationary:
                LookAt(cameraManager.lookAtPlayer);
                positionSet = false;
                break;
            default:
                cameraState = CameraState.Follow;
                break;
        }
    }
    //
    public void SetStationaryState()
    {
        cameraState = CameraState.Stationary;
        StartCoroutine(WaitAndStationary());
    }
    public void SetFollowState()
    {
        cameraState = CameraState.Follow;
        StartCoroutine(WaitAndFollow());
    }
    IEnumerator WaitAndFollow()
    {
        yield return new WaitForSeconds(cameraManager.cameraChangeSpeed);
        positionSet = true;
    }
    IEnumerator WaitAndStationary()
    {
        yield return new WaitForSeconds(cameraManager.cameraChangeSpeed);
        if (cameraManager.cameraLocations[0] != null)
        {
            this.transform.position = cameraManager.cameraLocations[0].position;
        }
    }
    //
    public void Move (Vector3 cameraPos, float speed, float cameraSmoothTime)
    {
        float newPositionY = Mathf.SmoothDamp(transform.position.y, cameraPos.y, ref yVelocity, cameraSmoothTime);
        float newPositionX = Mathf.SmoothDamp(transform.position.x, cameraPos.x, ref xVelocity, cameraSmoothTime / 1.7f);
        float newPositionZ = Mathf.SmoothDamp(transform.position.z, cameraPos.z, ref zVelocity, cameraSmoothTime / 1.7f);
        this.transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
    }
    public void LookAt(bool lookAtPlayer)
    { 
        if (lookAtPlayer)
        {
            this.transform.LookAt(cameraManager.cameraTarget.transform.position);
        }
        else if (lookAtPlayer == false && cameraManager.cameraLocations.Count > 0)
        {
            this.transform.rotation = cameraManager.cameraLocations[0].rotation;//
        }
        else if (lookAtPlayer == false && cameraManager.cameraLocations.Count == 0)
        {
            this.transform.rotation = Quaternion.LookRotation(Vector3.forward);//
        }
    }
}
public enum CameraState
{
    Follow,
    Stationary
}
