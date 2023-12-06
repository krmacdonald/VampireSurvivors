using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float explosionDamage;
    public float explosionDecay;
    private float explosionCounter;
    private basicEnemyBehavior enemyScript;
    private Vector3 launchDirection;
    private Rigidbody objectToLaunch;
    public playerLifeManager playerLife;
    public AudioSource m_shootingsound;
    private bool damagedPlayer = false;
    void Start()
    {
        m_shootingsound.Play();
        playerLife = GameObject.Find("Player").GetComponent<playerLifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionCounter += Time.deltaTime;
        if(explosionCounter > explosionDecay)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            launchDirection = transform.position - other.gameObject.transform.position;
            if (damagedPlayer == false)
            {
                playerLife.takeDamage(35);
                Debug.Log("player ouched");
                damagedPlayer = true;
            }
        }
        else if (other.tag == "Enemy")
        {
            enemyScript = other.gameObject.GetComponent<basicEnemyBehavior>();
            playerLife.addRepentance(enemyScript.takeDamage(explosionDamage));
            Debug.Log("Damaged");
        }
        else if(other.tag == "Ragdoll")
        {
            launchDirection = other.gameObject.transform.position - transform.position;
            objectToLaunch = other.gameObject.GetComponent<Rigidbody>();
            objectToLaunch.AddForce(launchDirection * 1000);
            Debug.Log("launching");
        }
    }
}
