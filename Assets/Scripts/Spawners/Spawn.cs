using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectSpawn;
    public GameObject objectToDestroy;
    float timeToSpawn = 3.0f;
    float currentTime;
    

    public void TimeSpawner() // Gambiarra praa n spawnar um monte de obj
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            SpawnObjec();
            currentTime = timeToSpawn;
        }
    }
    public void SpawnObjec() // Spawner
    {
        
    }
}
