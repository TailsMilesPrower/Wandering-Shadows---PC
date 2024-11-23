using UnityEngine;

public class PlayerShrinkDeath : MonoBehaviour
{
    [SerializeField]
    ParticleSystem shrinkingParticles;

    // Is the player dying? If so - rotate, shrink and play particle effect



    [SerializeField]
    Vector3 rotationAxis = Vector3.up;

    // Timer variables
    [SerializeField]
    float timeElapsed;
    [SerializeField]
    float timeLimit = 4.0f;
    [SerializeField]
    float rotationSpeed = 360.0f;

    Transform body;
    Vector3 startScale;
    Vector3 endScale = Vector3.one * 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = transform.localScale;
        shrinkingParticles = GetComponentInChildren<ParticleSystem>();
        var main = shrinkingParticles.main;
        main.duration = timeLimit;
        body = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       

       
                shrinkingParticles.Play();
          
            if (timeElapsed < timeLimit)
            {
                Vector3 currentScale = Vector3.Lerp(startScale, endScale, timeElapsed / timeLimit);
                transform.localScale = currentScale;
            } else
            {
                shrinkingParticles.Stop();

                gameObject.GetComponentInChildren<Renderer>().enabled = false;
            }

          
                body.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            
            timeElapsed += Time.deltaTime;
        }
    }

