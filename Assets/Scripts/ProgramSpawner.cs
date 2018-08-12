using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramSpawner : MonoBehaviour {

    public GameObject[] programs;
    public Transform[] spawnPositions;
    public float spawnRate;

    private void Start()
    {
        InvokeRepeating("SpawnFolder",spawnRate,spawnRate);
    }

    public void SpawnAntiVirus()
    {
        int rand = Random.Range(0, spawnPositions.Length);
        foreach (Transform child in spawnPositions[rand].transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(programs[0], spawnPositions[rand]);
    }

    public void SpawnRecycleBin()
    {
        int rand = Random.Range(0, spawnPositions.Length);
        Instantiate(programs[1], spawnPositions[rand]);
    }

    public void SpawnFolder()
    {
        int rand = Random.Range(0, spawnPositions.Length);
        foreach (Transform child in spawnPositions[rand].transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(programs[2], spawnPositions[rand]);


        if (Random.Range(1, 11) == 1)
        {
            SpawnRecycleBin();
        }
    }
}
