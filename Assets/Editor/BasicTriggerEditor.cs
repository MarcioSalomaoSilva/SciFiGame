using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(BasicTrigger))]
public class BasicTriggerEditor : Editor
{
    bool gizmos;
    private BasicTrigger thisTarget;
    public override void OnInspectorGUI()
    {
        thisTarget = (BasicTrigger)target;
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        EditorGUILayout.Space();
        DrawToggleGizmos();
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Add the box collider from the object to the above field", MessageType.Info);
    }
    void DrawToggleGizmos()
    {
        if (GUILayout.Button("Toggle gizmos on/off"))
        {
            gizmos = !gizmos;
            thisTarget.toggleGizmos = gizmos;
        }
    }
}
