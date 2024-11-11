using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour
{
    public float delayBeforeAppear = 15f; // Delay in seconds before the object appears
    public float appearDuration = 10f; // Time in seconds the object stays visible

    private void Start()
    {
        // Start the coroutine to handle appearance after a delay
        StartCoroutine(HandleAppearance());
    }

    private IEnumerator HandleAppearance()
    {
        // Wait for the delay before making the object appear
        yield return new WaitForSeconds(delayBeforeAppear);

        // Make the object appear
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        

        // Wait for the duration before hiding it again
        yield return new WaitForSeconds(appearDuration);

        // Make the object disappear
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
