using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public Transform[] enemySpawns;
    private float enemySpawnTimer = 0;
    public float enemySpawnDelay;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTimer += Time.deltaTime;
        if(enemySpawnTimer >= enemySpawnDelay)
        {
            enemySpawnTimer = 0;
            Instantiate(enemyPrefab, enemySpawns[(int)(Random.Range(0, 4))]);
            Debug.Log("spawning");
        }
    }
}
