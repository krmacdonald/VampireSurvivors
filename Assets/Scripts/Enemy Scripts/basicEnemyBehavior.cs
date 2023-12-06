using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Last edited by Kyle 11/8/23
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
    public float attackCooldown;
    private float attackCDCounter;
    public GameObject player;
    public GameObject blood;
    private Quaternion bloodRotate;
    private Vector3 bloodPos;
    private playerLifeManager playerLife;
    private winConditionCounter winCounter;
    private playerLifeManager playerAlive;
    public GameObject ragPrefab;
    private bool madeObject = false;
    [SerializeField] private NavMeshAgent agent;
    AudioSource m_shootingssound;

    // Start is called before the first frame update
    void Start()
    {
        m_shootingssound = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerAlive = player.GetComponent<playerLifeManager>();
        //winCounter = GameObject.Find("Win Manager").GetComponent<winConditionCounter>();
        foreach(Transform t in transform)
        {
            t.gameObject.tag = "Enemy";
        }
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive.isAlive)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 45f && attackCDCounter >= attackCooldown)
            {
                agent.SetDestination(player.transform.position);
            }
            if (Vector3.Distance(transform.position, player.transform.position) <= 3f && attackCDCounter >= attackCooldown)
            {
                attackPlayer();
                attackCDCounter = 0;
            }
            attackCDCounter += Time.deltaTime;
        }
    }

    //Causes the enemy to take damage, returns repentance value to the player.
    public float takeDamage(float playerDamage)
    {
        if((int)Random.Range(1,4) == 2)
        {
            m_shootingssound.Play();
        }
        totalRepentance = 0;
        this.enemyHealth -= playerDamage;
        totalRepentance += repentanceOnShot;
        bloodPos = this.transform.position;
        bloodRotate = this.transform.rotation;
        Instantiate(blood, bloodPos, bloodRotate);
        if (this.enemyHealth <= 0){
            totalRepentance += repentanceOnKill;
            handleDeath();
        }
        return totalRepentance;
    }

    public void attackPlayer()
    {
        playerLife = player.GetComponent<playerLifeManager>();
        playerLife.takeDamage(enemyDamage);

    }

    public void handleDeath()
    {
        //winCounter.addEnemies(1);
        if (madeObject == false)
        {
            madeObject = true;
            bloodPos = this.transform.position;
            bloodRotate = this.transform.rotation;
            Instantiate(ragPrefab, bloodPos, bloodRotate);
            Destroy(this.gameObject);
        }
    }
}
