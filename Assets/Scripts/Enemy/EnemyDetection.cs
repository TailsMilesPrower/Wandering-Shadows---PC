using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject target;
    public EndOfLevelManager endOfLevelManager;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Collider>().tag == "Player")
        {
            GameObject.FindAnyObjectByType<PlayerController>().Health = 0;

        }
    }
}
