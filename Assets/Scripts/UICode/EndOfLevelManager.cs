using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfLevelManager : MonoBehaviour
{
    //Reference to the EndOfLevelPrefab
    public GameObject endOfLevelMenu;

    //Bool to check if the game is paused
    public static bool Paused = false;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the timescale to 1
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    /*void Update()
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
                Finish();
            }
        }
    }*/

    //Function for pausing the game
    public void Finish()
    {
        //Activates the pause menu
        endOfLevelMenu.SetActive(true);
        //Freezes time
        Time.timeScale = 0f;
        //Pauses the game
        Paused = true;
    }
    //Function for resuming the game
    public void Play()
    {
        //Deactivates the pause menu
        endOfLevelMenu.SetActive(false);
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
    }

    //Function for going to the main menu
    public void ResetLevel()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void NextLevel()
    {
        //Resumes the time
        Time.timeScale = 1f;
        //Unpauses the game
        Paused = false;
        //Loads the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

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
