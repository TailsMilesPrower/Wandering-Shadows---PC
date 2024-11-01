using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    //[SerializeField]
    //public GameObject interactableDest;
    private Rigidbody rb;
    public Vector3 dirForce;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnMouseDown()
    {
        rb.useGravity = true;

        //Vector3 directionToTarget = (interactableDest.transform.position - transform.position).normalized;
        float forceMagnitude = 40f;

        rb.AddForce (dirForce * forceMagnitude, ForceMode.Impulse);

        //Vector3 forwardForce = transform.position * 2f;
        //rb.AddForce (forwardForce, ForceMode.Impulse);
    }
}
