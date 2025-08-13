using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 30f;
    private Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement = Vector2.left;
            transform.localScale = new Vector3(-1.632849f, 1.632849f, 1.632849f);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Vector2.right;
            transform.localScale = new Vector3(1.632849f, 1.632849f, 1.632849f);
            anim.SetBool("Walk", true);
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movement = Vector2.up;
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = Vector2.down;
            anim.SetBool("Walk", true);
        }
        else
        {
            movement = Vector2.zero;
            anim.SetBool("Walk", false);
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
