using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileMovement : MonoBehaviour {

    public float speed;
    public Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
