using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRaycast : MonoBehaviour
{
    public float range = 5f;
    public LayerMask targetMask;
    private EnemyScript enemyScript;
    public GameObject player;

    private void Awake()
    {
        enemyScript = transform.parent.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.forward;
        Ray theRay = new Ray(transform.position, direction);
        Debug.DrawLine(transform.position, transform.position + direction * range);

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                enemyScript.isPlayerInRange = true;
                print("I see the Player, EVERYONE ATTACK!!!");
            }
            else if (hit.collider.tag == "Building")
            {
                print("Nothing going on, continue walking");
            }
        }
    }
}