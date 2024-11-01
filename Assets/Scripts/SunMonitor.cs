using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMonitor : MonoBehaviour
{
    public LayerMask mask;
    public Light dirLight;
    private Vector3 oppositeDirection;
    private Renderer playerRenderer;


    private bool _isCausingDamage = false;
    public float DamageRepeatRate = 1f;
    public int DamageAmount = 1;
    public bool Repeating = true;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();    
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        oppositeDirection = -1f * dirLight.transform.forward;
        // Debug.Log(oppositeDirection.ToString());

        if (Physics.BoxCast(transform.position, transform.localScale * 0.25f, oppositeDirection, out RaycastHit hit, transform.rotation, 100f, mask)) {
            Debug.DrawRay(transform.position, oppositeDirection * hit.distance, Color.green);
            playerRenderer.material.color = Color.green;

            //No Dmg from sun
            {
                PlayerController player = gameObject.GetComponent<PlayerController>();
                if (player != null)
                {
                    _isCausingDamage = false;
                }
            }

        } else 
        {
            Debug.DrawRay(transform.position, oppositeDirection * 50f, Color.red);
            playerRenderer.material.color= Color.red;


            //Dmg from sun
            {
                _isCausingDamage = true;
                PlayerController player = gameObject.GetComponent<PlayerController>();

                if (player != null)
                {
                    if (Repeating)
                    {
                        StartCoroutine(TakeDamage(player, DamageRepeatRate));
                    }
                }
            }
        }
    }

    IEnumerator TakeDamage(PlayerController player, float repeatRate)
    {
        while (_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
