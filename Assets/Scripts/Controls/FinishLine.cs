using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public EndOfLevelManager endOfLevelManager;
    [SerializeField] private AudioClip finishClip;
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            SoundEffectManager.instance.PlaySoundFXClip(finishClip, transform, 1f);
            Debug.Log("Finish!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            endOfLevelManager.Finish();
        }
    }

    /*public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
