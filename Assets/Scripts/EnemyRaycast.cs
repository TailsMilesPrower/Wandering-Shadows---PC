using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public float range = 5f;
    public bool isPlayerInRange;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Player")
            {
                isPlayerInRange = true;
                print("I see the Player, EVERYONE ATTACK!!!");
            }
            else if (hit.collider.tag == "Building")
            {
                print("Nothing going on, continue walking");
            }
        }
    }
}