using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q)) 
        {
            transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 1, 0);
        }
    }


    /*public GameObject objectToRotateCamera;
    Quaternion targetRotationCam;
    // Start is called before the first frame update
    void Start()
    {
        targetRotationCam = Quaternion.Euler(70, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            targetRotationCam = Quaternion.Euler(50, objectToRotateCamera.transform.eulerAngles.y - 0.1f, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            targetRotationCam = Quaternion.Euler(50, objectToRotateCamera.transform.eulerAngles.y + 0.1f, 0);
        }
        objectToRotateCamera.transform.rotation = targetRotationCam;
    }*/
}
