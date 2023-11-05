using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

/*
 * Last edited by Kyle 11/5/23
 * Prerequisites
 *  - A timeline director attached to the gun that handles the gun's muzzle flash
 *  - Stats set up in the editor
 *  - Gun is the child of the player prefab
 */

public class gunScript : MonoBehaviour
{
    public Transform camTransform;
    public float gunDamage;
    public float gunFirerate;
    private float gunDelay;
    public int magazine;
    public float reloadSpeed;
    private basicEnemyBehavior enemyScript;
    private playerLifeManager playerLife;
    public PlayableDirector director;

    void Start()
    {
        playerLife = GameObject.Find("Player").GetComponent<playerLifeManager>(); //Gets the health manager
    }
    // Update is called once per frame
    void Update()
    {
        
        if (gunDelay > gunFirerate) //Checks if gun is ready to fire
        {
            if (Input.GetMouseButtonDown(0)) //m1 detection
            {
                director.Stop(); //stops current timeline if still playing
                director.Play(); //creates muzzle flash
                RaycastHit rayHit; //sends out raycast
                Shake(3f, 5f); //camera shake (not functional)
                if (Physics.Raycast(camTransform.position, camTransform.forward, out rayHit)) 
                {
                    if (rayHit.collider.gameObject.tag == "Enemy")
                    {
                        enemyScript = rayHit.collider.gameObject.GetComponent<basicEnemyBehavior>(); //grabs the enemy's script
                        playerLife.addRepentance(enemyScript.takeDamage(gunDamage)); //broadcasts gundamage to enemy's takedamage method, returns repentance
                    }
                }
            }
        }
        else
        {
            gunDelay += Time.deltaTime;
        }
    }

    //Handles camera shake
    public void Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = camTransform.position;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camTransform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
        }

        camTransform.position = originalPosition;
    }
}
