using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float velocity;


    public bool CanMove { get; set; }

    private Vector2 movementDirection;
    private Rigidbody2D rb;
	
	void Start ()
    {
        CanMove = true;
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        if (gameObject.activeSelf && CanMove)
        {
            movementDirection.x = Input.GetAxis("Horizontal");
            movementDirection.y = Input.GetAxis("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log(GetComponent<ObjectTilePosition>().CheckIfPathIsClear(Node.WalsDirection.left));
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Debug.Log(GetComponent<ObjectTilePosition>().CheckIfPathIsClear(Node.WalsDirection.top));
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Debug.Log(GetComponent<ObjectTilePosition>().CheckIfPathIsClear(Node.WalsDirection.right));
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log(GetComponent<ObjectTilePosition>().CheckIfPathIsClear(Node.WalsDirection.down));
        }
    }

    private void FixedUpdate()
    {
            rb.AddForce(movementDirection.normalized * velocity);
    }


}
