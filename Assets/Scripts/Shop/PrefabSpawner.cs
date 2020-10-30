using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour

{
    public GameObject[] prefabs;
    public Transform spawnPos;
    int randomInt;
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
    }

    void SpawnRandom()
    {
        randomInt = UnityEngine.Random.Range(0, prefabs.Length);
        Instantiate(prefabs[randomInt], spawnPos.position, spawnPos.rotation);
        
    }
}
