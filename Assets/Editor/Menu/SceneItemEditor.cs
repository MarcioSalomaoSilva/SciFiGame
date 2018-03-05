using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections;
//
public class SceneItemEditor : Editor {
    [MenuItem("Open Scene/Test Level")]
    public static void OpenTestLevel()
    {
        OpenScene("test_level");
    }
    [MenuItem("Open Scene/Level 1")]
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
}
