using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DoorTrigger))]
public class DoorTriggerEditor : Editor
{
    object source;
    private DoorTrigger thisTarget;
    public override void OnInspectorGUI()
    {
        thisTarget = (DoorTrigger)target;
        thisTarget.doorType = (DoorTypeState)EditorGUILayout.EnumPopup("Door Type", thisTarget.doorType);
        switch (thisTarget.doorType)
        {
            case DoorTypeState.None:
                thisTarget.gameObject.GetComponent<BasicTrigger>().RemoveObject();
                break;
            case DoorTypeState.TestDoor:
                if (thisTarget.door == null)
                {
                    thisTarget.door = (GameObject)PrefabUtility.InstantiatePrefab(
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Assets/Prefabs/TestDoor.prefab"));
                    thisTarget.door.transform.parent = thisTarget.gameObject.transform;
                    thisTarget.door.transform.localPosition = Vector3.zero;
                    thisTarget.door.transform.localScale = new Vector3(.5f, 3, 3);
                }
                break;
        }
        //thisTarget.door = (GameObject)EditorGUILayout.ObjectField("Door Game Object", thisTarget.door, typeof(Object), true);
        thisTarget.pull = EditorGUILayout.Toggle("Pull/Push", thisTarget.pull);
        thisTarget.randomAngleToggle = EditorGUILayout.Toggle("Random Angle", thisTarget.randomAngleToggle);
        if (thisTarget.randomAngleToggle)
        {
            thisTarget.randomAngleMin = EditorGUILayout.FloatField("between", thisTarget.randomAngleMin);
            thisTarget.randomAngleMax = EditorGUILayout.FloatField("and", thisTarget.randomAngleMax);
            thisTarget.rotationSpeed = EditorGUILayout.Slider("Speed", thisTarget.rotationSpeed, 0, 90);
        }
        else
        {
            thisTarget.angle = EditorGUILayout.Slider("Angle", thisTarget.angle, 0, 90);
            thisTarget.rotationSpeed = EditorGUILayout.Slider("Speed", thisTarget.rotationSpeed, 0, 90);
        }
    }
}
