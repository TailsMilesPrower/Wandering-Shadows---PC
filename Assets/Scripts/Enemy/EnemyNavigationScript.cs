using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyNavigationScript : MonoBehaviour
{
    public List<Transform> waypointPosition = new List<Transform>();
    public GameObject target;
    private int index;
    void Start()
    {
        //agent.SetDestination(waypointPosition[index].position);
    }

    void Update()
    {
        
    }
}
