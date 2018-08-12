using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
    
    public Transform bossSpawnPoint;
    public GameObject boss;
    public float spawnAfter;

    private void Start()
    {
        InvokeRepeating("SpawnBoss", spawnAfter, spawnAfter);
    }

    public void SpawnBoss()
    {
        if(FindObjectOfType<CrysisBoss>() != null)
        {
            return;
        }
        Instantiate(boss, bossSpawnPoint.position, transform.rotation);
    }

}
