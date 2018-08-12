using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSpawner : MonoBehaviour {

    public float spawnRate;
    public float timeDelayBeforeSpawning;
    public GameObject enemyFile;


    private void Start()
    {
        InvokeRepeating("PrepareTheFileToBeSpawned", timeDelayBeforeSpawning , spawnRate);
    }

    public void PrepareTheFileToBeSpawned()
    {
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);
        randX += Mathf.Sign(randX);
        randX += Mathf.Sign(randY);


        Instantiate(enemyFile, Camera.main.ViewportToWorldPoint(new Vector3(randX, randY, 10.0f)),transform.rotation);
    }
}
