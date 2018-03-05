using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class DebugManager : MonoBehaviour
{
    [Header("Player Stuff")]
    public bool playerDebug;
    public bool playerDirection;
    public bool playerRays;
    //[Header("Camera Stuff")]
    //public bool cameraTriggerGizmos;
    [HideInInspector]
    public List<CameraTrigger> cameraTriggerScripts;
    //
    private void OnValidate()
    {
        //if (cameraTriggerScripts.Count < GameObject.FindObjectsOfType<CameraTrigger>().Length)
        //{
        //    cameraTriggerScripts.AddRange(GameObject.FindObjectsOfType<CameraTrigger>());
        //}
        //else if (cameraTriggerScripts.Count >= GameObject.FindObjectsOfType<CameraTrigger>().Length)
        //{
        //    cameraTriggerScripts.RemoveRange(2, cameraTriggerScripts.Count);
        //}
    }
    void OnDrawGizmos()
    {
        
    }
}

