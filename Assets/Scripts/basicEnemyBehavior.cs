using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyBehavior : MonoBehaviour
{
    public float enemyHealth;
    public float enemyDamage;
    public float repentanceOnShot;
    public float repentanceOnKill;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int playerDamage)
    {
        this.enemyHealth -= playerDamage;
        if(this.enemyHealth <= 0){
            handleDeath();
        }
    }

    public void handleDeath()
    {

    }
}
