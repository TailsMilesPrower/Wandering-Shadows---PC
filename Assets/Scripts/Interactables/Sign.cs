using UnityEngine;

public class Sign : MonoBehaviour
{

    public GameObject SignPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(SignPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
