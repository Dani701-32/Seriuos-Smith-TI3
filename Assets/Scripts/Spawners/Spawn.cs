using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public GameObject objectSpawn;
    public GameObject objectToDestroy;
    float timeToSpawn = 3.0f;
    float currentTime;
    public Controller control;

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
        if(control.IsCutting)
        {
            ItemWorld.SpwanItemWorld((transform.position + new Vector3(Random.Range(-1.2f, 1.2f),1f,Random.Range(-1.2f, 1.2f))), new Item { itemType = Item.ItemType.Wood, amount = 1 });//Linha para spawnar item
            Instantiate(objectSpawn,transform.position, Quaternion.identity);
            control.IsCutting = false;
            Destroy(objectToDestroy);
            Debug.Log("asd");
        }
    }
}
