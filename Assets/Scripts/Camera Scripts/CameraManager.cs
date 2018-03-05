using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CameraMotor))]
public class CameraManager : MonoBehaviour
{
    public delegate void CameraMotorDelegate();
    public static event CameraMotorDelegate SetStationary;
    public static event CameraMotorDelegate SetFollow;
    //
    CameraMotor cameraMotor;
    [HideInInspector]
    public GameObject mainCamera;
    [Header("Camera Settings")]
    public float cameraSpeed = 3;
    public float cameraSmoothTime = 0.3f;
    public float cameraDistance = 7;
    public float cameraHeight = 0;
    //variables that this manager recieves from other gameobject/messages/triggers
    [HideInInspector]
    public GameObject cameraTarget;
    [HideInInspector]
    public bool lookAtPlayer;
    [HideInInspector]
    public float cameraChangeSpeed = .5f;
    //
    public List<Transform> cameraLocations;
    // Use this for initialization
    void Awake ()
    {
        mainCamera = GameObject.Find("Main Camera");
        cameraMotor = GetComponent<CameraMotor>();
        cameraTarget = GameObject.Find("Player");
        DefaultLookAt();
    }
    private void OnEnable()
    {
        CameraTrigger.OnEnter += AddToCameraLocationList;
        CameraTrigger.OnExit += RemoveFromCameraLocationList;
    }
    private void OnDisable()
    {
        CameraTrigger.OnEnter -= AddToCameraLocationList;
        CameraTrigger.OnExit -= RemoveFromCameraLocationList;
    }
    // Update is called once per frame
    void LateUpdate ()
    {
        cameraMotor.DetectCameraPosition();
    }
    public bool DefaultLookAt()
    {
        return lookAtPlayer = true;
    }
    //
    public void AddToCameraLocationList(Transform newLocation, bool lookAt, float changeSpeed)//make delegate
    {
        cameraLocations.Add(newLocation);
        lookAtPlayer = lookAt;
        cameraChangeSpeed = changeSpeed;
        if (SetStationary != null)
        {
            SetStationary();
        }
    }
    public void RemoveFromCameraLocationList(Transform newLocation, bool lookAt, float changeSpeed)// make delegate
    {
        cameraLocations.RemoveAt(0);
        lookAtPlayer = lookAt;
        cameraChangeSpeed = changeSpeed;
        if (cameraLocations.Count == 0)
        {
            if (SetFollow != null)
            {
                SetFollow();
                DefaultLookAt();
            }

        }
        else
        {
            if (SetStationary != null)
            {
                SetStationary();
            }
        }
    }
    //
}

