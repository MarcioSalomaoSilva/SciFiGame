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
            case TriggerTypeState.None:
                thisTarget.RemoveComponent("CameraTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "DoubleSlidingDoorTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                break;
            case TriggerTypeState.Dialogue:
                thisTarget.AddComponent("DialogueTrigger");
                RemoveRest("CameraTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "DoubleSlidingDoorTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                break;
            case TriggerTypeState.Door:
                thisTarget.AddComponent("DoorTrigger");
                RemoveRest("DialogueTrigger", "CameraTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "DoubleSlidingDoorTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                SetAnimatorController("DoorController");
                break;
            case TriggerTypeState.DoubleDoor:
                thisTarget.AddComponent("DoubleDoorTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleSlidingDoorTrigger", 
                    "SlidingDoorTrigger", "CameraTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                break;
            case TriggerTypeState.SlidingDoor:
                thisTarget.AddComponent("SlidingDoorTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "DoubleSlidingDoorTrigger", "CameraTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                break;
            case TriggerTypeState.DoubleSlidingDoor:
                thisTarget.AddComponent("DoubleSlidingDoorTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "CameraTrigger", "ItemTrigger");
                thisTarget.RemoveObject();
                break;
            case TriggerTypeState.Camera:
                thisTarget.AddComponent("CameraTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "DoubleSlidingDoorTrigger", "ItemTrigger");
                break;
            case TriggerTypeState.Item:
                thisTarget.AddComponent("ItemTrigger");
                RemoveRest("DialogueTrigger", "DoorTrigger", "DoubleDoorTrigger", 
                    "SlidingDoorTrigger", "DoubleSlidingDoorTrigger", "CameraTrigger");
                thisTarget.RemoveObject();
                break;
        }
        DrawDefaultInspector();
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Add the box collider from the object to the above field", MessageType.Info);
    }
    public void RemoveRest(string name1, string name2, string name3, string name4, string name5, string name6)
    {
        thisTarget.RemoveComponent(name1);
        thisTarget.RemoveComponent(name2);
        thisTarget.RemoveComponent(name3);
        thisTarget.RemoveComponent(name4);
        thisTarget.RemoveComponent(name5);
        thisTarget.RemoveComponent(name6);
    }
    public void SetAnimatorController(string name)
    {
        thisTarget.GetComponent<Animator>().runtimeAnimatorController =
                    AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(
                        "Assets/Assets/Animators/" + name +".controller");
    }
}
