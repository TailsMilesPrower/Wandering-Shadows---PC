using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{

    public string sceneName;
    // Start is called before the first frame update
<<<<<<< Updated upstream
    public string sceneName;
    public void GoToScene()
    
=======
    public void GoToScene()
>>>>>>> Stashed changes
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
