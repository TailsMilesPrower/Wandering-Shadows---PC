using UnityEngine;
using UnityEngine.UIElements;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    //private GameObject cameraContainer;
    //private GameObject Camera_FollowsPlayer_Prefab;
    
    public Camera cam;
    private Quaternion rotation;

    public Vector3 cameraOffset = new Vector3(0f, 40f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (Camera.main != null)
        {
            cam = Camera.main;
            //Camera_FollowsPlayer_Prefab = cam.gameObject;
        }

        UpdateCameraPosition();
        
        //GameObject gameObject = Instantiate(Camera_FollowsPlayer_Prefab);
        //Camera_FollowsPlayer_Prefab.transform.position = transform.position;
        //transform.SetParent(Camera_FollowsPlayer_Prefab.transform);

        //cameraContainer = new GameObject("Camera Container");
        //cameraContainer.transform.position = transform.position;
        //transform.SetParent(cameraContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private void UpdateCameraPosition()
    {
        if (cam != null)
        {
            cam.transform.position = transform.position + cameraOffset;
        }
    }
    

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            //Camera_FollowsPlayer_Prefab.transform.position = ;
            //cam.transform.rotation = Quaternion.Euler(60f, 180f, 0f);
            //cameraContainer.transform.rotation = Quaternion.Euler(60f, 180f, 0f);
            //rotation = new Quaternion(0, 0, 1, 0);

            rotation = new Quaternion(0f, 90f, 0f, 0f);

            return true;
        }

        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            Quaternion gyroRotation = gyro.attitude;
            Quaternion adjustedRotation = gyroRotation * rotation;

            float yawFromGyro = adjustedRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(0, yawFromGyro, 0);

            //Quaternion gyroRotation = gyro.attitude * rotation;

            //transform.localRotation = Quaternion.Euler (gyroRotation.eulerAngles.x, gyroRotation.eulerAngles.y, gyroRotation.eulerAngles.z);
            //transform.localRotation = Quaternion.Euler(0, gyroRotation.eulerAngles.y, 0);

            //Quaternion gyroAttitude = gyro.attitude * rotation;
            //Vector3 euler = gyroAttitude.eulerAngles;
            //Vector3 euler = gyroRotation.eulerAngles;
            //float zRotation = euler.z;
            //float xRotation = euler.x;

            //transform.localRotation = Quaternion.Euler(0, yRotation, 0);
            //transform.localRotation = gyro.attitude * rotation;
        }
    }

    /*private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    */

}
