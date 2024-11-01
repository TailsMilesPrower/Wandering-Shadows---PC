using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraFollowPlayer : MonoBehaviour
{
    /*private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float SmoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, SmoothTime);
    }*/
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 1f, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -1f, 0);
        }
    }
}
