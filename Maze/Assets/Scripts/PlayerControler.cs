using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float velocity;

    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private bool moving;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        if (gameObject.activeSelf)
        {
            movementDirection.x = Input.GetAxis("Horizontal");
            movementDirection.y = Input.GetAxis("Vertical");
        }
	}

    private void FixedUpdate()
    {
            rb.AddForce(movementDirection.normalized * velocity);
    }
}
