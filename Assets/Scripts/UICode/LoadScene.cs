using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneToLoadPath;

    public void GoToScene()
    {
        SceneManager.LoadScene(ConvertScenePathToName(sceneToLoadPath));
    }

    private string ConvertScenePathToName(string sceneToLoadPath)
    {
        int start = sceneToLoadPath.LastIndexOf("/") +1;
        int end = sceneToLoadPath.LastIndexOf(".");

        if (start > 0 && end > start)
        {
            string sceneToLoad = sceneToLoadPath.Substring(start, end - start);
            return sceneToLoad;
        }
        return null;
    }

    public void Quit()
    {
        Application.Quit();
    }

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
}
