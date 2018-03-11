using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(BasicTrigger)), CanEditMultipleObjects]
public class BasicTriggerEditor : Editor
{
    bool gizmos;
    private BasicTrigger thisTarget;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        thisTarget = (BasicTrigger)target;
        //base.OnInspectorGUI();
        thisTarget.triggerState = (TriggerTypeState)EditorGUILayout.EnumPopup("Trigger Type", thisTarget.triggerState);
        switch (thisTarget.triggerState)
        {
            case TriggerTypeState.Basic:
                DrawBasicTrigger();
                break;
            case TriggerTypeState.Dialogue:
                DrawDialogueTrigger();
                break;
            case TriggerTypeState.Door:
                DrawDoorTrigger();
                break;
            case TriggerTypeState.DoubleDoor:
                DrawDoubleDoorTrigger();
                break;
            case TriggerTypeState.SlidingDoor:
                DrawSlidingDoorTrigger();
                break;
            case TriggerTypeState.DoubleSlidingDoor:
                DrawDoubleSlidingDoor();
                break;
        }
        DrawDefaultInspector();
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Add the box collider from the object to the above field", MessageType.Info);
    }
    //
    void DrawBasicTrigger()
    {

    }
    //
    void DrawDialogueTrigger()
    {

    }
    //
    void DrawDoorTrigger()
    {

    }
    //
    void DrawDoubleDoorTrigger()
    {

    }
    //
    void DrawSlidingDoorTrigger()
    {

    }
    //
    void DrawDoubleSlidingDoor()
    {

    }
    //
}
