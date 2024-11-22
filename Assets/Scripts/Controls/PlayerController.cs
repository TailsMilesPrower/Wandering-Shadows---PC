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

    public DeathAnims[] deathAnim;
    private int animIndex;

    public MeshRenderer rendVamp;
    public MeshRenderer rendHitBox;
    public MeshRenderer rendTargetDest;

    private GameObject deathAnimation;
  
    private int killSwitch = 1;

    

    // Start is called before the first frame update

    void Start()
    {
        mHealthBar = gameOverlay.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;

 
        rendVamp.enabled = true;
        rendHitBox.enabled = true;
        animIndex = random.Range(0,DeathAnims.Length-1);
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

        rendVamp.enabled = false;
        rendHitBox.enabled = false;
        rendTargetDest.enabled = false;


        deathAnimation = Instantiate(DeathAnims[animIndex], transform.position, Quaternion.identity);
        Debug.Log("Playing...");
        yield return new WaitForSeconds(3f);
        
        Destroy(deathAnimation);
        Debug.Log("Chonk");
        yield return new WaitForSeconds(2f);
        Debug.Log("And done");
        endOfLevelManager.GameOver();
    }

}
