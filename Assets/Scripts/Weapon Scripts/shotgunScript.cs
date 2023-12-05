using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunScript : MonoBehaviour
{
    public int bulletDamage;
    public int projectileAmount;
    public float fireSpeed;
    private float fireSpeedDelay;
    public AudioSource fireSound;
    public playerLifeManager healthGetter;
    public GameObject invisBulletPrefab;
    public GameObject bulletsPrefab;
    AudioSource m_shootingsound;

    void Start()
    {
        m_shootingsound = GetComponent<AudioSource>();
        fireSpeedDelay = 0;
        healthGetter = GameObject.Find("Player").GetComponent<playerLifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fireSpeedDelay += Time.deltaTime;
        if (healthGetter.isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(fireSpeedDelay > fireSpeed)
                {
                    m_shootingsound.Play();
                    Instantiate(bulletsPrefab, invisBulletPrefab.transform.position, invisBulletPrefab.transform.rotation);
                    fireSpeedDelay = 0;
                    Debug.Log("Firing");
                }
            }
        }
    }
}
