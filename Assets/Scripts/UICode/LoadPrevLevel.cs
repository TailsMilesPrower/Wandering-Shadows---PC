using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPrevLevel : MonoBehaviour
{
    private int sceneIndex;
    private int sceneToOpen;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (!PlayerPrefs.HasKey("previousScene" + sceneIndex))
        {
            PlayerPrefs.SetInt("previousScene" + sceneIndex, sceneIndex);
        }
        sceneToOpen = PlayerPrefs.GetInt("previousScene" +  sceneIndex);
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
