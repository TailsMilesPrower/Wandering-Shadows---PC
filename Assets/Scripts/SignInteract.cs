using UnityEngine;

public class SignInteract : MonoBehaviour
{

    public GameObject signObject;
    public GameObject interact;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            interact.SetActive(true);
        }
    }
}
