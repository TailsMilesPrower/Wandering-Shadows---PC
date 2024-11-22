using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyScriptCopy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public NavMeshAgent player;
    public List<Transform> waypointPos = new List<Transform>();
    public int index = 0;
    public bool forward = true;
    public float time;
    public bool isPlayerInRange;
    public Transform targetObject;
    [SerializeField] EnemyRaycast enemyRaycast;

    public void Starts()
    {
        enemy.SetDestination(waypointPos[index].position);
    }

    public void Updates()
    {
        if (DestinationReach())
        {
            SetNextWaypoints();
            Debug.Log("ello");

        }
        else if (isPlayerInRange == true)
        {
            Debug.Log("I am chasing");
            ChasePlayers();
        }
    }
    private void ChasePlayers()
    {
        // SceneManager.LoadScene("EndMenu");
        // transform.position = Vector3.MoveTowards(transform.position, targetObject.position, 10 * Time.deltaTime);
        //enemy.SetDestination(player.position);
        if (tag == "Player")
        {
            SceneManager.LoadScene("EndMenu");
        }
    }

    private bool DestinationReach()
    {
        float distance = Vector3.Distance(transform.position, waypointPos[index].position);
        return distance < 1.7f;
    }

    private void SetNextWaypoints()
    {
        if (forward)
        {
            index++;
            if (index == waypointPos.Count - 1)
            {
                forward = false;
            }
            // Move Character
            enemy.SetDestination(waypointPos[index].position);
        }
        else
        {
            index--;
            if (index == 0)
            {
                forward = true;
            }
            // Move Character
            enemy.SetDestination(waypointPos[index].position);
        }

    }
}
