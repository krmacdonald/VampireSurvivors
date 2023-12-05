using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individualSGBullet : MonoBehaviour
{
    public playerLifeManager healthGetter;
    public float damage;
    private basicEnemyBehavior enemyScript;
    void Start()
    {
        healthGetter = GameObject.Find("Player").GetComponent<playerLifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyScript = other.gameObject .GetComponent<basicEnemyBehavior>();
            healthGetter.addRepentance(enemyScript.takeDamage(damage));
        }
    }
}
