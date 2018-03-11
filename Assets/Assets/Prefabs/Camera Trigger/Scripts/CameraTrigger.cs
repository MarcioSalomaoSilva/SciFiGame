﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[RequireComponent(typeof(BoxCollider))]
public class CameraTrigger : MonoBehaviour
{
    public delegate void CameraTriggerDelegate(Transform cameraLocation, bool lookAt, float changeSpeed);
    public static event CameraTriggerDelegate OnEnter;
    public static event CameraTriggerDelegate OnExit;
    //
    public GameObject cameraLocation;
    public GameObject mainCamera;
    public BoxCollider thisCollider;
    //
    public bool toggleGizmos;
    public bool lookAtPlayer;
    public float cameraChangeSpeed = .5f;
    // Use this for initialization
    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main.gameObject;
        }
    }
    void OnTriggerEnter(Collider other)//NOTE: send a delegate to camera manager to change the position of the camera 
        //and to player motor to change the transform direction if the axis returns to zero 
    {
        if (OnEnter != null && other.tag == "Player")
        {
            OnEnter(cameraLocation.transform, lookAtPlayer, cameraChangeSpeed);
        }
    }
    void OnTriggerExit(Collider other)//NOTE: send a delegate to camera manager and player motor 
    {
        if (OnExit != null && other.tag == "Player")
        {
            OnExit(cameraLocation.transform.parent, lookAtPlayer, cameraChangeSpeed);
        }
    }
    //
    private void OnDrawGizmos()
    {
        if (toggleGizmos)
        {
            //draws camera location
            
            //
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(this.transform.position, thisCollider.size);
            Gizmos.color = new Color(1, .92f, 0.016f, 0.1f);
            Gizmos.DrawCube(this.transform.position, thisCollider.size);
            //connects the object to camera
            Gizmos.color = Color.black;
            //camera gizmos
            Gizmos.matrix = cameraLocation.transform.localToWorldMatrix;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3.forward);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3.right);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3.up);
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.1f, 0.1f, 0.1f));
            Gizmos.matrix = Matrix4x4.TRS(cameraLocation.transform.position, cameraLocation.transform.rotation, new Vector3(Camera.main.aspect, 1.0f, 1.0f));
            Gizmos.DrawFrustum(Vector3.zero, Camera.main.fieldOfView, Camera.main.farClipPlane / 700, Camera.main.nearClipPlane, 1.0f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        //camera gizmos
        Gizmos.color = new Color(1, 1, 1, .2f);
        Gizmos.DrawCube(this.transform.position, Vector3.one / 3);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(this.transform.position, cameraLocation.transform.position);
        Gizmos.DrawWireCube(this.transform.position, Vector3.one / 3);
        Gizmos.matrix = cameraLocation.transform.localToWorldMatrix;
        if (cameraLocation != null)
        {
            Gizmos.color = new Color(1, 1, 1, .2f);
            Gizmos.DrawCube(Vector3.zero, Vector3.one / 2);
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one / 2);
        }
        else
        {
            Debug.LogAssertion("The Camera Location isn't set up for this trigger box");
        }
    }
}