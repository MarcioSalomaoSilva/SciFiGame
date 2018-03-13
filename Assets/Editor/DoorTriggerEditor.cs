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
        thisTarget.door = (GameObject)EditorGUILayout.ObjectField("Door Game Object", thisTarget.door, typeof(Object), true);
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
        //thisTarget.randomAngle = EditorGUILayout.BeginToggleGroup("Random Angle", thisTarget.randomAngle);
        //thisTarget.angle = EditorGUILayout.Slider("Angle", thisTarget.angle, 0, 90);
        //EditorGUILayout.EndToggleGroup();
    }
}
