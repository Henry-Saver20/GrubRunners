using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_gamecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public int level = 0;
    public float maxHealth = 100;
    public float health = 100;
    public float armor = 0.0f;
    public float xp = 0;
    private Rigidbody2D _rb;
    public bool isAlive;
    public float xpNeeded;

    void Start()
    {
        _rb = player.GetComponent<Rigidbody2D>();
        isAlive = true;
        xpNeeded = 100 + (level * 100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HealPlayer(float healingAmount)
    {
        var newHealth = healingAmount + health;
        if(newHealth > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health = newHealth;
        }
    }

    public void DamagePlayer(float damageAmount)
    {
        health = health - (damageAmount * (1 - armor));
        if (health <= 0)
        {
            isAlive = false;
            player.GetComponent<playerMovement>().isAlive = false;
        }
    }

    public void AddExp(float xpAmount)
    {
        xp = xp + xpAmount;
        if(xp > xpNeeded)
        {
            xp = xp - xpNeeded;
            level += 1;
            xpNeeded = 100 + (level * 100);
        }
    }
}
