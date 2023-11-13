using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrailScript : MonoBehaviour
{
    private Color theColorToAdjust;
    // Start is called before the first frame update
    void Start()
    {
        theColorToAdjust = GetComponent<Renderer>().material.color;
        theColorToAdjust.a = 1f; // completely opaque
    }

    // Update is called once per frame
    void Update()
    {
        theColorToAdjust.a -= Time.deltaTime;
        if (theColorToAdjust.a < .4f)
        {
            Destroy(this.gameObject);
            Debug.Log("destroying!");
        }
    }
}