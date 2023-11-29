using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float firerate;
    private float firerateTimer = 0;


    void Start()
    {
        firerateTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
