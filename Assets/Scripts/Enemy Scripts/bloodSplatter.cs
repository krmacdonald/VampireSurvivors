using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSplatter : MonoBehaviour
{

    private float bloodLast = .3f;
    private float bloodTimer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bloodTimer += Time.deltaTime;
        if(bloodTimer > bloodLast)
        {
            Destroy(this.gameObject);
        }
    }
}
