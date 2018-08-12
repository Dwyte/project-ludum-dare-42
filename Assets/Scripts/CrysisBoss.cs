using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrysisBoss : MonoBehaviour {

    public GameObject mods;
    public Transform[] spawnPoints;
    public float spawnAfter;
    public float spawnRate;
    public float speed;
    Rigidbody2D rb;
    float changeTime = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnMods", spawnAfter, spawnRate);
        rb = GetComponent<Rigidbody2D>();
        Invoke("ChangeDirection", changeTime);
    }

    public void SpawnMods()
    {
        foreach(Transform t in spawnPoints)
        {
            Instantiate(mods, t.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * speed;
    }

    public void ChangeDirection()
    {
        speed *= -1;

        changeTime = Random.Range(1f, 5f);

        Invoke("ChangeDirection",changeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            speed *= -1;
        }
    }
}
