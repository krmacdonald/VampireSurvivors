using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public Transform camTransform;
    public float gunDamage;
    public float gunFirerate;
    public int magazine;
    public float reloadSpeed;
    private basicEnemyBehavior enemyScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //m1 detection
        {
            RaycastHit rayHit; //sends out raycast
            if (Physics.Raycast(camTransform.position, camTransform.forward, out rayHit))
            {
                if (rayHit.collider.gameObject.tag == "Enemy")
                {
                    enemyScript = rayHit.collider.gameObject.GetComponent<basicEnemyBehavior>(); //grabs the enemy's script
                    enemyScript.takeDamage(gunDamage); //broadcasts gundamage to enemy's takedamage method
                }
            }
        }
    }
}
