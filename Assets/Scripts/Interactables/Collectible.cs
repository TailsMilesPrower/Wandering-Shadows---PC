using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class Collectible : MonoBehaviour
{
    //private static Collectible collectibles;
    public static event Action OnCollected;

    private Collider myCollider;

    //public static int total;
    //public MeshRenderer rendCollectible;
    //public MeshRenderer rendHitBox;

    [SerializeField] private AudioClip collectSoundClip;
    public void Awake()
    {
        /*if (gameObject == null)
        {
            return;
        }*/
        //Instantiate(gameObject);
        //total = 3;
        //gameObject.SetActive(true);
    }


    // Update is called once per frame
    private void Start()
    {
        //get the Collider component to the gameObject
        myCollider = GetComponent<Collider>();

        //Check if the Collider component exists
        if (myCollider == null)
        {
            Debug.LogError("Collider not found on gameObject: " + gameObject.name);
        }
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(30f, Time.time * 100f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Play SoundFX
        SoundEffectManager.instance.PlaySoundFXClip(collectSoundClip, transform, 1f);

        if (other.CompareTag("Player"))
        {
            
            // Old method
            Debug.Log("trying collect");
            OnCollected?.Invoke();
            Destroy(gameObject);

            //MoveCollectibleToCounter(destination);

            //rendCollectible.enabled = false;
            //rendHitBox.enabled = false;
            //gameObject.SetActive(false);
        }
    }

    /*void MoveCollectibleToCounter(GameObject gameObject)
    {
        Vector3 position = gameObject.transform.position;
        transform.localPosition = position;
        OnCollected?.Invoke();
    }*/
}
