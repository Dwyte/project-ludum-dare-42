using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileStorageMovement : MonoBehaviour {

    public float speed;
    public float infectedSpeed;
    public float startSpeed;

    public float dashTime;
    public float dashForce;
    public float startDashForce;
    public float infectedDashForce;
    private float dashTimeLeft;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startSpeed = speed;
        startDashForce = dashForce;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(dashTimeLeft > 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * dashForce, Input.GetAxis("Vertical") * dashForce);
            dashTimeLeft -= Time.deltaTime;
            return;
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTimeLeft = dashTime;
        }
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
