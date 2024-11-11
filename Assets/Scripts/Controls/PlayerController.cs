using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip deathSoundClip;
    private HealthBar mHealthBar;
    public HUD Hud;
    public int Health = 100;
    public bool isHiding;

    // Start is called before the first frame update

    void Start()
    {
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;

        
    }

    public bool IsDead
    {
        get
        {
            return Health == 0;
        }
    }

    public void TakeDamage(int amount)
    {
        bool isHiding;
        Health -= amount;
        if (Health < 0)
            Health = 0;
        
        mHealthBar.SetHealth(Health);

        if (IsDead)
        {

            isHiding = false;
            StartCoroutine(PlaydeathSound());
            
        }
        //Play Burning soundeffect
       
        

    }

    IEnumerator PlaydeathSound()
    {
        SoundEffectManager.instance.PlaySoundFXClip(deathSoundClip, transform, 1f);

        yield return new WaitUntil(()  => deathSoundClip == false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void start()
    {

    }
}
