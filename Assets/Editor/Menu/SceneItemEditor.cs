using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections;
//
public class SceneItemEditor : Editor
{
    //gizmos
    [MenuItem("Game/Debug/Gizmos")]
    public static void Gizmos()
    {
        DebugManager.instance.gizmos = !DebugManager.instance.gizmos;
        if (DebugManager.instance.gizmos)
        {
            Menu.SetChecked("Game/Debug/Gizmos", true);
        }
        else {
            Menu.SetChecked("Game/Debug/Gizmos", false);
        }
    }
    //for scenes
    [MenuItem("Game/Open Scene/Test Level")]
    public static void OpenTestLevel()
    {
        OpenScene("test_level");
    }
    [MenuItem("Game/Open Scene/Level 1")]
    public static void OpenLevel1()
    {
        OpenScene("level_1");
    }
    static void OpenScene(string name)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/" + name + ".unity", OpenSceneMode.Single);
        }
    }
    //For Triggers
    [MenuItem("Game/Create/Trigger")]
    static void CreateBasicTrigger()
    {
        GameObject prefab = (GameObject)PrefabUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath<Object>("Assets/Assets/Prefabs/Basic Trigger/Basic Trigger.prefab"));
        prefab.name = "Trigger";
    }
}
