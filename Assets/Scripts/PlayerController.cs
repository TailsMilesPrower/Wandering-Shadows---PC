using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HealthBar mHealthBar;
    public HUD Hud;
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        mHealthBar = Hud.transform.Find("HealthBar").GetComponent<HealthBar>();
        mHealthBar.Min = 0;
        mHealthBar.Max = Health;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;

        mHealthBar.SetHealth(Health);
    }

    public void start()
    {

    }
}
