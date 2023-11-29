using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float timeToExplode;
    private float explodeDelay = 0;
    private bool canExplode = false;
    public GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        explodeDelay += Time.deltaTime;
        if(explodeDelay > timeToExplode)
        {
            canExplode = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (canExplode)
        {
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(explosionPrefab, position, rotation);
            Destroy(gameObject);
        }
    }
}
