using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class individualSGBullet : MonoBehaviour
{
    public playerLifeManager healthGetter;
    public float damage;
    private basicEnemyBehavior enemyScript;
    public PlayableDirector crossHair;
    void Start()
    {
        healthGetter = GameObject.Find("Player").GetComponent<playerLifeManager>();
        crossHair = GameObject.Find("Canvas").GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            crossHair.Stop();
            crossHair.Play();
            enemyScript = other.gameObject .GetComponent<basicEnemyBehavior>();
            healthGetter.addRepentance(enemyScript.takeDamage(damage)/3);
        }
    }
}
