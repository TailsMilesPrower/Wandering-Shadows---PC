#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(CollectibleMemory))]
public class SceneDisplay : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CollectibleMemory script = (CollectibleMemory)target;
        script.SceneToLoad = (SceneAsset)EditorGUILayout.ObjectField("Scene To Load", script.SceneToLoad, typeof(SceneAsset), false);
    }
}
#endif