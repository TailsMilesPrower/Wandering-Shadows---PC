using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
   private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Finish!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
