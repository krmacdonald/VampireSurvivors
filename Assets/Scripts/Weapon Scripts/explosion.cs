using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float explosionDecay;
    private float explosionCounter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explosionCounter += Time.deltaTime;
        if(explosionCounter > explosionDecay)
        {
            Destroy(this.gameObject);
        }
    }
}
