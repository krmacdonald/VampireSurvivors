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
        if (healthGetter.isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(fireSpeedDelay > fireSpeed)
                {
                    m_shootingsound.Play();
                    fireSpeedDelay = 0;
                }
            }
        }
    }
}
