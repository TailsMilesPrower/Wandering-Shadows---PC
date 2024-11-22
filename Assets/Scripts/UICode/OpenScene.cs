using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{

    public int sceneNumber;

    public void OnButtonClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousScene" + sceneNumber, currentScene);
        SceneManager.LoadScene("PauseMenu");
    }
    
    public void PauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");

    }
}
