using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections;
//
public class SceneItemEditor : Editor
{
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
    [MenuItem("Game/Triggers/Create/Trigger")]
    static void CreateBasicTrigger()
    {
        GameObject prefab = (GameObject)PrefabUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath<Object>("Assets/Assets/Prefabs/Basic Trigger/Basic Trigger.prefab"));
        prefab.name = "Trigger";
    }
    [MenuItem("Game/Triggers/Create/Camera Trigger")]
    public static void CreateCameraTrigger()
    {
        GameObject prefab = (GameObject)PrefabUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath<Object>("Assets/Assets/Prefabs/Camera Trigger/Çamera Trigger.prefab"));
        prefab.name = "Trigger";
    }
}
