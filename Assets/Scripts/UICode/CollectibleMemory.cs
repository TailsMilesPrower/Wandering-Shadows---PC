using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CollectibleMemory : MonoBehaviour
{
    [SerializeField]
    string sceneToLoadPath;
    
    [SerializeField]
    private CollectibleCount total, count;
    void Update()
    {
        SceneManager.GetActiveScene();
        total = count;
    }
#if UNITY_EDITOR
    public SceneAsset SceneToLoad
    {
        get
        {
            return AssetDatabase.LoadAssetAtPath<SceneAsset>(sceneToLoadPath);
        }
        set
        {
            sceneToLoadPath = AssetDatabase.GetAssetPath(value);
        }
    }

#endif


}
