using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Last edited by Kyle 11/5/23
 * Prerequisites
 *  - Attached to the prefab named "Player"
 */

public class playerLifeManager : MonoBehaviour
{
    public float health;
    public float repentance;
    public float repentanceDecay; //reccomended to be ~10/15
    private float decayTimer;
    private float regeneration;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        decayTimer += Time.deltaTime;
        if(decayTimer >= repentanceDecay)
        {
            repentance -= 5;
            if(repentance < 0)
            {
                repentance = 0;
            }
            decayTimer = 4;
        }
        //repentanceRegen();
    }

    //handles the regeneration of health based on repentace value using switch case
    public void repentanceRegen() 
    {
        switch (repentance)
        {
            case var expression when (repentance >= 0 && repentance < 10):
                Debug.Log("wow");
                break;
        }
    }

    //Health pickups can modify this function, unaffected by repentance
    public void addHealth(float hpAdded)
    {
        health += hpAdded;
        if (health > 100)
        {
            health = 100;
        }
    }

    //enemies call this function with their damage var to hurt the player
    public void takeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health < 0)
        {
            health = 0;
            handleDeath();
        }
    }

    //script to handle game over/player reset, maybe respawn enemies
    public void handleDeath() 
    { 

    }

    public void addRepentance(float repentanceAdded)
    {
        Debug.Log("Adding " + repentanceAdded);
        repentance += repentanceAdded;
        if(repentance > 100)
        {
            repentance = 100;
        }
        decayTimer = 0; //resets counter for decay
    }
}
