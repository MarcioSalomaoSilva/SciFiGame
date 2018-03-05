using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public bool debug;
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
        if (debug)
        {
            GetComponentInChildren<CameraTriggerGizmos>().debug = true;
            //draws camera location
            Gizmos.color = Color.black;
            if (cameraLocation != null)
            {
                Gizmos.DrawWireSphere(cameraLocation.transform.position, 0.05f);
            }
            else
            {
                Debug.LogAssertion("The Camera Location isn't set up for this trigger box");
            }
            Gizmos.DrawWireSphere(this.transform.position, 0.05f);
            Gizmos.DrawLine(this.transform.position, cameraLocation.transform.position);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.transform.position, thisCollider.size);
        }
        else
        {
            GetComponentInChildren<CameraTriggerGizmos>().debug = false;
        }
    }
}