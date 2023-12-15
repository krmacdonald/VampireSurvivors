using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    //Made by Bree :)
    //Cluster spawner! Made to spawn multiple enemies at random locations in random numbers
    //Uses a trigger to spawn the enemies.
    //GameObjects are used as spawn points and can be set in the inspector in any location provided. Manually place spawn points.

    //The method of spawning (random = choose a spawn point randomly; onebyone = spawn an object on spawnpoint #1 , the next will be spawned on spawnpoint #2 ,etc.)
    public enum SpawnType { Random, OneByOne }

    [Header("Main parameters")]
    public SpawnType spawnType;
    public GameObject[] spawnPoints;    //The array that will contain the different spawnpoints to call from
    public string toSpawnResourceName = "GameObject";
    public GameObject skeletonPrefab;

    [Header("Extra parameters")]
    public int numberOfObjectsToSpawnOnContact = 1;
    public int maxGameobjectsToSpawn = 2;

    private int nextSpawnPointIndex = 0;
    private int spawnedObjects = 0;
    private GameObject toSpawn;

   
    void Start()
    {
        toSpawn = Resources.Load(toSpawnResourceName) as GameObject;    //Load the gameobject to spawn from resources
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player") //Check for what you want about the collider here
        {
            SpawnAnObject();
        }
    }

    private void SpawnAnObject()
    {
        if (spawnedObjects >= maxGameobjectsToSpawn)    //If enough objects have spawned, then stop it from spawning more
            return;

        for (int i = 0; i < numberOfObjectsToSpawnOnContact; i++)
        {
            GameObject spawnPoint = spawnPoints[0]; //Sets a default spawnpoint so there arent any errors.

            if (spawnType == SpawnType.Random)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            }
            else if (spawnType == SpawnType.OneByOne)
            {
                spawnPoint = spawnPoints[nextSpawnPointIndex];
                nextSpawnPointIndex++;
                if (nextSpawnPointIndex >= spawnPoints.Length)
                    nextSpawnPointIndex = 0;
            }

            Instantiate(skeletonPrefab, spawnPoint.transform.position, Quaternion.identity);   //Spawn the wanted GameObject
            spawnedObjects++;       //Increment the number of spawned objects.
        }
    }
}
