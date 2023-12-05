using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public GameObject explosionPrefab;
    private bool hasMade = false;
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        if (hasMade == false)
        {
            Instantiate(explosionPrefab, position, rotation);
            hasMade = true;
        }
        Destroy(gameObject);
    }
}
