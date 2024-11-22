using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip deathClip;
    private HealthBar mHealthBar;
    public HUD gameOverlay;
    public int Health = 100;
    public EndOfLevelManager endOfLevelManager;

    public GameObject deathAnim_1;
    public MeshRenderer rend;

  
    private int killSwitch = 1;

    

    // Start is called before the first frame update

    void Start()
    {
        mHealthBar = gameOverlay.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;

 
        rend.enabled = true;
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
        Health -= amount;
        if (Health < 0)
            Health = 0;
        
        mHealthBar.SetHealth(Health);

        if (IsDead)
        {
            if (killSwitch > 0)
            {
               
                //endOfLevelManager.GameOver();
                killSwitch -= 1;
                StartCoroutine(PlayDeathAnim());
            }
        }
        //Play Burning soundeffect
       
        

    }

    IEnumerator PlayDeathAnim()
    {
        SoundEffectManager.instance.PlaySoundFXClip(deathClip, transform, 1f);

        rend.enabled = false;

        Instantiate(deathAnim_1, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(5f);
        endOfLevelManager.GameOver();
    }

}
