using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    [SerializeField] private AudioClip collectSoundClip;
    private void Awake()
    {
        total = 3;
    }

    // Update is called once per frame
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
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }

}
