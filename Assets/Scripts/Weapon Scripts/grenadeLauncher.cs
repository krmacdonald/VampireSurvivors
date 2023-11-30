using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float firerate;
    private float firerateTimer = 0;
    private GameObject instantiatedGrenade;
    public playerLifeManager healthGetter;
    public float grenadeLaunchSpeed;
    private Rigidbody grenadeRigidbody;
    public Transform camTrans;


    void Start()
    {
        firerateTimer = 0;
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
