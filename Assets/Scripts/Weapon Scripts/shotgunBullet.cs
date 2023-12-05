using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunBullet : MonoBehaviour
{
    public GameObject[] bullets = new GameObject[7];
    public Rigidbody[] bulletRBs = new Rigidbody[7];
    public GameObject[] targets = new GameObject[7];
    public float timeAlive;
    private float counter;

    void Start()
    {
        counter = 0;
        for(int i = 0; i < 7; i++)
        {
            bullets[i] = GameObject.Find("Bullet" + (i + 1));
            bulletRBs[i] = bullets[i].GetComponent<Rigidbody>();
            targets[i] = GameObject.Find("target" + (i + 1));
        }

        for (int i = 0; i < 7; i++)
        {
            bulletRBs[i].AddForce((targets[i].transform.position - bullets[i].transform.position) * 1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= timeAlive)
        {
            Destroy(this.gameObject);
        }
    }
}
