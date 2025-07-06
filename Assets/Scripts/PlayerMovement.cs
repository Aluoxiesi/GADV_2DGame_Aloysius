using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movement = Vector2.up;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement = Vector2.down;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (movement == Vector2.zero)
        {
            return;
        }
        rb.AddForce(movement * speed);
    }
}
