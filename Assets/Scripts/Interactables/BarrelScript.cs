using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public MeshRenderer playerHide;
    public MeshRenderer playerUnhide;
    [SerializeField]
    public PlayerController playerController;
    private void OnTriggerEnter(Collider collider)
    {
        playerHide.enabled = false;
        Debug.Log("You're in the barrel!");

    }
    private void OnTriggerExit(Collider collider)
    {
        playerUnhide.enabled = true;
        // isHiding = GetComponent<PlayerController>().enabled = false;
        Debug.Log("You're out of the barrel!");
    }
}
