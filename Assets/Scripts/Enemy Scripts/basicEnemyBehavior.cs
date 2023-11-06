using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Last edited by Kyle 11/5/23
 * Prerequisites
 *  - NavMeshAgent attached to enemy
 *  - Main object with collider tagged as "Enemy"
 */

public class basicEnemyBehavior : MonoBehaviour
{
    public float enemyHealth;
    public float enemyDamage;
    public float repentanceOnShot;
    public float repentanceOnKill;
    private float totalRepentance;
    public GameObject player;
    [SerializeField] private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in transform)
        {
            t.gameObject.tag = "Enemy";
        }
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    //Causes the enemy to take damage, returns repentance value to the player.
    public float takeDamage(float playerDamage)
    {
        totalRepentance = 0;
        this.enemyHealth -= playerDamage;
        totalRepentance += repentanceOnShot;
        if(this.enemyHealth <= 0){
            totalRepentance += repentanceOnKill;
            handleDeath();
        }
        return totalRepentance;
    }

    public void handleDeath()
    {
        Destroy(this.gameObject);
    }
}
