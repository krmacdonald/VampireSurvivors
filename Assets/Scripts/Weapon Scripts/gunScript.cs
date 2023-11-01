using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public Transform camTransform;
    public int gunDamage;
    public int gunFirerate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //m1 detection
        {
            RaycastHit rayHit; //sends out raycast
            if (Physics.Raycast(camTransform.position, camTransform.forward, out rayHit))
            {
                if (rayHit.collider.gameObject.tag == "Enemy")
                {
                    Destroy(rayHit.collider.gameObject); //destroys enemy when raycast hit
                }
            }
        }
    }
}
