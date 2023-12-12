using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject prefab1; 
    public GameObject prefab2; 
    public float spawnInterval = 2f;
    

    void Start()
    {
        
        InvokeRepeating("SpawnRandomPrefab", 0f, spawnInterval);
        
    }

    void SpawnRandomPrefab()
    {
        
        
              GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? prefab1 : prefab2;

        
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, GetRandomSpawnPosition(), Quaternion.identity);
        
      

        
        Destroy(spawnedPrefab, 3f);
    }

    Vector3 GetRandomSpawnPosition()
    {
        
        
            float spawnX = Random.Range(-5f, 5f);
            float spawnY = 0f;
            float spawnZ = Random.Range(-5f, 5f);

            return new Vector3(spawnX, spawnY, spawnZ);

        
        
    }

    

}
