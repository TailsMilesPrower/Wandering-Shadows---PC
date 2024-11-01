using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private AudioClip damageSoundClip;

    private HealthBar mHealthBar;
    public HUD Hud;
    public int Health = 100;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;

        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;

        mHealthBar.SetHealth(Health);

        //Play Burning soundeffect

        audioSource.clip = damageSoundClip;
        audioSource.Play();

    }

    public void start()
    {

    }
}
