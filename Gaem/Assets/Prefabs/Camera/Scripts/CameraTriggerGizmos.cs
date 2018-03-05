using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerGizmos : MonoBehaviour {
    [HideInInspector]
    public bool debug;
    // Use this for initialization
    private void OnDrawGizmos()
    {
        if (debug)
        {
            //draws camera location
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Vector3.zero, Vector3.forward / 2);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3.right / 2);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(Vector3.zero, Vector3.up / 2);
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(0.1f, 0.1f, 0.1f));
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(Camera.main.aspect, 1.0f, 1.0f));
            Gizmos.DrawFrustum(Vector3.zero, Camera.main.fieldOfView, Camera.main.farClipPlane / 700, Camera.main.nearClipPlane, 1.0f);
        }
    }
}
