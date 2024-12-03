#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[CustomEditor(typeof(LoadScene))]
public class SceneLoad : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

       LoadScene script = (LoadScene)target;
        script.SceneToLoad = (SceneAsset)EditorGUILayout.ObjectField("Scene To Load", script.SceneToLoad, typeof(SceneAsset), false);
    }
}
#endif