using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float explosionDecay;
    private float explosionCounter;
    AudioSource m_shootingsound;

    void Start()
    {
        AudioSource m_shootingsound;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource m_shootingsound;
        explosionCounter += Time.deltaTime;
        if(explosionCounter > explosionDecay)
        {
            Destroy(this.gameObject);
        }
    }
}
