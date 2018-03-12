using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class DebugManager : MonoBehaviour
{
    public static DebugManager instance;
    //
    [Header("Player Stuff")]
    public bool playerDebug;
    public bool playerDirection;
    public bool playerRays;
    public bool gizmos;
    //
    private void OnValidate()
    {
        instance = this;
    }
    void OnDrawGizmos()
    {
        
    }
}

