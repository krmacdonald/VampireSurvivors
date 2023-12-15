using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnRagdoll : MonoBehaviour
{
    public float despawnTimer;
    private float counter;

    void Update()
    {
        counter += Time.deltaTime;
        if(counter > despawnTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
