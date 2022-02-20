using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    Animator anim;

    [Header("移動參數")]
    public float speed;
    private float horizontalmove;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundMovement();
    }
    void Update()
    {
    }

    void GroundMovement(){
        horizontalmove = Input.GetAxisRaw("Horizontal");
        //print(horizontalmove);
        rb.velocity = new Vector2(horizontalmove * speed,rb.velocity.y);
        
        FilpDirection();
    }

    void FilpDirection()
    {
        if(horizontalmove <0 )
        {
            transform.localScale = new Vector2(-1,1);
        }
        else if(horizontalmove >0 )
        {
            transform.localScale = new Vector2(1,1);
        }
    }

}
