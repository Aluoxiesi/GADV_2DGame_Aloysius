using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 30f;
    private Animator anim;
   
   

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
        
    }

    

    

    void Update()
    {
        //When A is pressed, the zookeeper moves left, and sprite will transform to the following scale(flip)
        // and because the walk is set to true, the walk animation will play
        if (Input.GetKey(KeyCode.A)) 
        {
            movement = Vector2.left;
            transform.localScale = new Vector3(-1.632849f, 1.632849f, 1.632849f);
            anim.SetBool("Walk", true); 
        }
        //When D is pressed, the zookeeper moves left, and sprite will transform to the following scale(flip)
        else if (Input.GetKey(KeyCode.D))
        {
            movement = Vector2.right;
            transform.localScale = new Vector3(1.632849f, 1.632849f, 1.632849f);
            anim.SetBool("Walk", true);
            
        }
        //When W is pressed, the zookeeper moves up
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
