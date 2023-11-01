using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class basicEnemyBehavior : MonoBehaviour
{
    public float enemyHealth;
    public float enemyDamage;
    public float repentanceOnShot;
    public float repentanceOnKill;
    public GameObject player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
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
