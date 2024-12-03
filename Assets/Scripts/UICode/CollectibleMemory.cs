using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleMemory : MonoBehaviour
{
    public Scene Level1;
    public Scene Level2;
    public Scene Level3;
    public Scene Level4;
    public Scene Level5;
    public Scene Level6;

    [SerializeField]
    private CollectibleCount total, count;
    void Update()
    {
        SceneManager.GetActiveScene();
        total = count;
    }
}
