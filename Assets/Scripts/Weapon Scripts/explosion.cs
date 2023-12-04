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
    public playerLifeManager playerLife;
    void Start()
    {
        
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
        if(other.tag == "Player")
        {
            launchDirection = transform.position - other.gameObject.transform.position;
        }else if(other.tag == "Enemy")
        {
            enemyScript = other.gameObject.GetComponent<basicEnemyBehavior>();
            playerLife.addRepentance(enemyScript.takeDamage(explosionDamage));
        }
    }
}
