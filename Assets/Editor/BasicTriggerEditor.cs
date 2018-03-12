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
            case TriggerTypeState.Dialogue:
                thisTarget.AddRemoveComponent("DialogueTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.Door:
                thisTarget.AddRemoveComponent("DoorTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.DoubleDoor:
                thisTarget.AddRemoveComponent("DoubleDoorTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.SlidingDoor:
                thisTarget.AddRemoveComponent("SlidingDoorTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.DoubleSlidingDoor:
                thisTarget.AddRemoveComponent("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.Camera:
                thisTarget.AddRemoveComponent("CameraTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("ItemTrigger");
                break;
            case TriggerTypeState.Item:
                thisTarget.AddRemoveComponent("ItemTrigger");
                thisTarget.RemoveRest("DialogueTrigger");
                thisTarget.RemoveRest("DoorTrigger");
                thisTarget.RemoveRest("DoubleDoorTrigger");
                thisTarget.RemoveRest("SlidingDoorTrigger");
                thisTarget.RemoveRest("DoubleSlidingDoorTrigger");
                thisTarget.RemoveRest("CameraTrigger");
                break;
        }
        DrawDefaultInspector();
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Add the box collider from the object to the above field", MessageType.Info);
    }
}
