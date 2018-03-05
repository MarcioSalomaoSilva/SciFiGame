using UnityEditor;
using UnityEngine;
using System.Collections;
//
public class TriggerItemEditor : Editor
{
    [MenuItem("Triggers/Create/Basic Trigger")]
    static void CreateBasicTrigger()
    {
        InstantiateTrigger myTrigger = (InstantiateTrigger)new InstantiateTrigger();
        myTrigger.CreateObject("Prefabs/Basic Trigger/Basic Trigger");
    }
    [MenuItem("Triggers/Create/Camera Trigger")]
    public static void OpenLevel1()
    {
        InstantiateTrigger myTrigger = (InstantiateTrigger)new InstantiateTrigger();
        myTrigger.CreateObject("Prefabs/Camera/Camera Trigger");
    }
}
