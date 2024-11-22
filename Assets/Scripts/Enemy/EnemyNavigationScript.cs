using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyNavigationScript : MonoBehaviour
{
    public List<Transform> waypointPosition = new List<Transform>();
    public NavMeshAgent agent;
    private int index;
    private bool isMoving = true;

    // Kris helped me with the script.
    void Start()
    {
        agent.SetDestination(waypointPosition[index].position);
    }

    void Update()
    {
        if (isMoving == true)
        {
            MoveToNextWaypoint();
        }
        else
        {
            MoveToPreviousWaypoint();
        }

    }

    public void MoveToNextWaypoint()
    {
        if (Vector3.Distance(waypointPosition[index].position, transform.position) < 1.5f)
        {
            if (index < waypointPosition.Count - 1)
            {
                index++;
            }
            if (index == waypointPosition.Count - 1)
            {
                isMoving = false;
            }
            agent.SetDestination(waypointPosition[index].position);
        }
    }

    public void MoveToPreviousWaypoint()
    {
        if (Vector3.Distance(waypointPosition[index].position, transform.position) < 1.5f)
        {
            if (index > 0)
            {
                index--;
            }
            if (index == 0)
            {
                isMoving = true;
            }
            agent.SetDestination(waypointPosition[index].position);
        }
    }
}
