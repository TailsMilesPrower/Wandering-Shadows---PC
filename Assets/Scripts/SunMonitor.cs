using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SunMonitor : MonoBehaviour
{
    private float _nextTimeTimerTriggers = 0f;

    public LayerMask mask;
    public Light dirLight;
    private Vector3 oppositeDirection;
    private Renderer playerRenderer;
    public GameObject burningAnimation;
    public AudioSource burning;

    private bool isBurning;
    private bool _isCausingDamage = false;
    public float DamageRepeatRate = 0.3f;
    public int DamageAmount = 1;
    public bool Repeating = true;
    
    
    //SOUNDS
    [SerializeField] private float sunRraycastHightFactor = 1f;

    //[SerializeField] private AudioClip burningSoundClip;

    AudioSource burningSoundSource;
    //public bool sFX_Play;



    private void Awake()
    {
        _nextTimeTimerTriggers = Time.realtimeSinceStartup + DamageRepeatRate;
    }




    // Start is called before the first frame update
    void Start()
    {
        isBurning = burningAnimation;
        playerRenderer = GetComponent<Renderer>();
        burningSoundSource = GetComponent<AudioSource>();
        //sFX_Play = true;
        //burningSoundSource.Stop();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        oppositeDirection = -1f * dirLight.transform.forward;
        // Debug.Log(oppositeDirection.ToString());
        

        if (Physics.Raycast(transform.position+ Vector3.up * sunRraycastHightFactor, oppositeDirection, 100f, mask)) {
           // Debug.DrawRay(transform.position, oppositeDirection * hit.distance, Color.green);
            playerRenderer.material.color = Color.green;

            //sFX_Play = false;
            //burningSoundSource.Stop();
            burningSoundSource.Play();
            //No Dmg from sun
            {
                PlayerController player = gameObject.GetComponent<PlayerController>();
                if (player != null)
                {
                    gameObject.GetComponent<AudioSource>().Stop();
                    burningAnimation.SetActive(false);
                    _isCausingDamage = false;
                }
            }

        } else 
        {
            Debug.DrawRay(transform.position, oppositeDirection * 50f, Color.red);
            playerRenderer.material.color= Color.red;

            /*if (Color.red != playerRenderer.material.color)
            {
                burningSoundSource.Play();
            }*/

                //sFX_Play = true;


                //Dmg from sun
                {
                gameObject.GetComponent<AudioSource>().Play();
                isBurning = true;
                _isCausingDamage = true;
                
                PlayerController player = gameObject.GetComponent<PlayerController>();
                //SoundEffectManager.instance.PlaySoundFXClip(burningSoundClip, transform, 1f);


                if (player != null)
                {
                    

                    if (_isCausingDamage && _nextTimeTimerTriggers < Time.realtimeSinceStartup)
                    {

                        // Do the thing!
                        burningAnimation.SetActive(true);
                        TakeDamage(player, DamageRepeatRate);
                        gameObject.GetComponent<AudioSource>().Play();


                        _nextTimeTimerTriggers = Time.realtimeSinceStartup + DamageRepeatRate;

                        /*audioSource.clip = damageSoundClip;
                        audioSource.Play();*/
                    }
                }
            }
        }
    }

    private void TakeDamage(PlayerController player, float repeatRate)
    {
        
        repeatRate = DamageRepeatRate;
        player.TakeDamage(DamageAmount);

        //burning soundeffect
        //SoundEffectManager.instance.PlaySoundFXClip(burningSoundClip, transform, 1f);

        if (player.IsDead)
        {
            _isCausingDamage = false;
            Destroy(burningSoundSource);
            burningAnimation.SetActive(false);
            gameObject.GetComponent<AudioSource>().Stop();

        }
    }
}
