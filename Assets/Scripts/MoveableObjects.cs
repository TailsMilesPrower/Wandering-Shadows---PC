using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveableObjects : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    private float pushForce = 4;
    

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {  
            return;
        }
        
        if (hit.moveDirection.y < - 0.3f)
        { 
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        Vector3 collisionPoint = hit.point;
        
        body.AddForceAtPosition(pushDirection * pushForce, collisionPoint, ForceMode.Impulse);
    }

}
