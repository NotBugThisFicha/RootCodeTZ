using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Path path = (Path)target;
        if(path.transform.childCount == 0)
        {
            if (GUILayout.Button("Generate Points"))
                path.GenerateSegments();
        }
        else
        {
            if (GUILayout.Button("Reset Points"))
                path.ResetPath();

            if (GUILayout.Button("Delete Points"))
                path.DeletePath();
        }
        if (GUI.changed) SetObjDirty(path.gameObject);
    }

    public static void SetObjDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
}
