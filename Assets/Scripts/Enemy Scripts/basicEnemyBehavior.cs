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
    public void takeDamage(float playerDamage)
    {
        this.enemyHealth -= playerDamage;
        if(this.enemyHealth <= 0){
            handleDeath();
        }
    }

    public void handleDeath()
    {
        Destroy(this.gameObject);
    }
}
