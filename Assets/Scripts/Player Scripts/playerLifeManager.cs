using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLifeManager : MonoBehaviour
{
    public float health;
    public float repentance;
    private float regeneration;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //handles the regeneration of health based on repentace value using switch case
    public void repentanceRegen() 
    {
        switch (repentance)
        {

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
            handleDeath();
        }
    }

    //script to handle game over/player reset, maybe respawn enemies
    public void handleDeath() 
    { 

    }

    public void addRepentance()
    {

    }
}
