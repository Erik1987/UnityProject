using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour

{
    public GameObject[] prefabs;
    private List<int> randomNumbers = new List<int>();
    public Transform spawnPos1;
    public Transform spawnPos2;
    public Transform spawnPos3;
    public Transform spawnPos4;
    private int randomInt;
    private int numberOfSpwaners = 4;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
    }

    void SpawnRandom()

    {

        for(int i = 0; i < numberOfSpwaners; i++)
        {
            while (true)
            {
                randomInt = UnityEngine.Random.Range(0, prefabs.Length);

                if (!randomNumbers.Contains(randomInt))
                {
                    randomNumbers.Add(randomInt);
                    UnityEngine.Debug.Log("rndm " + randomInt);
                    break;
                }
            }
        }

        GameObject item1 = Instantiate(prefabs[randomNumbers[0]], spawnPos1.position, spawnPos1.rotation);
        GameObject item2 = Instantiate(prefabs[randomNumbers[1]], spawnPos2.position, spawnPos2.rotation);
        GameObject item3 = Instantiate(prefabs[randomNumbers[2]], spawnPos3.position, spawnPos3.rotation);
        GameObject item4 = Instantiate(prefabs[randomNumbers[3]], spawnPos4.position, spawnPos4.rotation);

        item1.transform.parent = GameObject.Find("Spawn1").transform;
        item2.transform.parent = GameObject.Find("Spawn2").transform;
        item3.transform.parent = GameObject.Find("Spawn3").transform;
        item4.transform.parent = GameObject.Find("Spawn4").transform;


    }
}
