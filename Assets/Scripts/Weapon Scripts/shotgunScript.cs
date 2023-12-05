using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
    public PlayableDirector flashDirector;
    AudioSource m_shootingsound;

    void Start()
    {
        m_shootingsound = GetComponent<AudioSource>();
        fireSpeedDelay = fireSpeed;
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
                    flashDirector.Stop(); //stops current timeline if still playing
                    flashDirector.Play(); //creates muzzle 
                    m_shootingsound.Play();
                    Instantiate(bulletsPrefab, invisBulletPrefab.transform.position, invisBulletPrefab.transform.rotation);
                    fireSpeedDelay = 0;
                    Debug.Log("Firing");
                }
            }
        }
    }
}
