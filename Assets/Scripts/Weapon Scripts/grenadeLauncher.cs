using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float firerate;
    private float firerateTimer = 0;
    private GameObject instantiatedGrenade;
    private playerLifeManager healthGetter;
    public float grenadeLaunchSpeed;
    private Rigidbody grenadeRigidbody;
    public Transform camTrans;
    public AudioSource m_shootingsound;


    void Start()
    {
        firerateTimer = 0;
        healthGetter = GameObject.Find("Player").GetComponent<playerLifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        firerateTimer += Time.deltaTime;
        if (healthGetter.isAlive)
        {
            if (firerateTimer > firerate)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    m_shootingsound.Play();
                    fireGrenade();
                    firerateTimer = 0;
                }
            }
        }
    }
    
    void fireGrenade()
    {
        instantiatedGrenade = Instantiate(grenadePrefab, this.transform.position + new Vector3(0, .2f, 0) + this.transform.forward + (this.transform.right/8), this.transform.rotation);
        grenadeRigidbody = instantiatedGrenade.GetComponent<Rigidbody>();
        grenadeRigidbody.AddForce((camTrans.forward + new Vector3(0, .23f, 0)) * grenadeLaunchSpeed);
    }
}
