using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject endOfLevelMenu;

    public bool IsDead;
    //Bool to check if the game is paused
    public static bool Paused = false;

    //A refrence to the pause menu canvas
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the timescale to 1
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //If you press the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If the game is paused
            if (Paused)
            {
                //The game resumes
                Play();
            }
            //If the game is not paused
            else
            {
                //The game is paused
                Stop();
            }
        }
    }

    //Function for pausing the game
    void Stop()
    {
        //Activates the pause menu
        PauseMenuCanvas.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }
    //Function for resuming the game
    public void Play()
    {
        //Deactivates the pause menu
        PauseMenuCanvas.SetActive(false);
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
    }

    //Function for going to the main menu
    public void MainMenuButton()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene("MainMenu");
    }
}
