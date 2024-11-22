using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject target;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Collider>().tag == "Player")
        {
            SceneManager.LoadScene("FailuareMenu");
        }
    }
}
