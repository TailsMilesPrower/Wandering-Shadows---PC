using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
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
        text.text = "Fruits collected " + $"{count} / {Collectible.total}";
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
