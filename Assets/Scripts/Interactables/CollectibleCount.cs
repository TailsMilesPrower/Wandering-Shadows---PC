using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    
    public GameObject endStar1;
    public GameObject endStar2;
    public GameObject endStar3;
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    private void Start()
    {
        UpdateCount();
    }

    private void OnEnable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }

    private void OnDisable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        //text.text = "Fruits collected " + $"{count} / {Collectible.total}";
        if(count == 1)
        {
            star1.SetActive(true);
            endStar1.SetActive(true);
        }
        if (count == 2)
            { 
            star2.SetActive(true);
            endStar2.SetActive(true);
            }
        if (count == 3)
            { 
            star3.SetActive(true);
            endStar3.SetActive(true);
            }
    }

    /*[SerializeField] Collectible OnCollected;
    
    // Start is called before the first frame update
    void Start()
    {
        var g = FindObjectsOfType<Collectible>();
        foreach (Collectible item in g)
        {
            item.OnCollected += Collect;
        }
    }

    private void Collect(Collectible c)
    {
        Debug.Log("Red fruit eated!");
        c.OnCollected -= Collect;
        Destroy(c.gameObject);
    }*/
}
